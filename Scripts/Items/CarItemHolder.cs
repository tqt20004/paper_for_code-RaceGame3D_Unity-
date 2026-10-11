using UnityEngine;

public class CarItemHolder : MonoBehaviour
{
    private CarEntity owner;
    public IItemBehavior CurrentItem { get; private set; }
    public Sprite CurrentItemIcon { get; private set; }

    public void Init(CarEntity entity)
    {
        this.owner = entity;
    }

    public void ReceiveItem(IItemBehavior item, Sprite icon = null)
    {
        this.CurrentItem = item;
        this.CurrentItemIcon = icon;
        GameEvents.OnItemSlotUpdated?.Invoke(owner, icon);
        Debug.Log($"[{owner.name}] 🎁 Đã nhận được Đạo cụ: {item.GetType().Name}");
    }

    private void Update()
    {
        // Bắt phím Space hoặc Ctrl để dùng đồ:
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            UseItem();
        }
    }

    public void UseItem()
    {
        if (CurrentItem == null) return;

        CurrentItem.Execute(owner);

        // Dùng xong thì dọn sạch ô chứa
        CurrentItem = null;
        CurrentItemIcon = null;
        GameEvents.OnItemSlotUpdated?.Invoke(owner, null);
    }
}
