using UnityEngine;

public class HandleTouchingComponent : MonoBehaviour
{
    public enum TouchType
    {
        ItemBox,    // Hộp quà ngẫu nhiên
        BananaTrap, // Bẫy vỏ chuối
        Hazard      // Chướng ngại vật
    }

    [Header("Type Config")]
    public TouchType touchType = TouchType.ItemBox;

    private void OnTriggerEnter(Collider other)
    {
        CarEntity car = other.GetComponent<CarEntity>() ?? other.GetComponentInParent<CarEntity>();
        if (car == null) return;

        switch (touchType)
        {
            case TouchType.ItemBox:
                // Tặng ngẫu nhiên một đạo cụ cho xe:
                IItemBehavior randomItem = RollRandomItem();
                car.itemHolder.ReceiveItem(randomItem);

                // Ẩn hộp quà đi (chờ hồi sinh sau 5s):
                gameObject.SetActive(false);
                break;

            case TouchType.BananaTrap:
                // Gây hiệu ứng mất lái cho xe đạp trúng:
                car.effectReceiver.ApplyEffect(new BananaSlipEffect(1.5f));

                // Bẫy dẫm trúng thì biến mất:
                Destroy(gameObject);
                break;
        }
    }

    private IItemBehavior RollRandomItem()
    {
        int r = Random.Range(0, 3);
        if (r == 0) return new NitroBehavior(3f, 30f);
        if (r == 1) return new BananaBehavior(null);
        return new ShieldItemBehavior();
    }
}

// Item behavior cho Khiên:
public class ShieldItemBehavior : IItemBehavior
{
    public void Execute(CarEntity user)
    {
        user.effectReceiver.ApplyEffect(new ShieldEffect(10f));
    }
}
