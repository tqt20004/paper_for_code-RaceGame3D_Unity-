using UnityEngine;

public class BananaBehavior : IItemBehavior
{
    private GameObject bananaPrefab;

    public BananaBehavior(GameObject prefab = null)
    {
        this.bananaPrefab = prefab;
    }

    public void Execute(CarEntity user)
    {
        Vector3 spawnPos = user.dropPoint != null 
            ? user.dropPoint.position 
            : user.transform.position - user.transform.forward * 2.5f;

        if (bananaPrefab != null)
        {
            Object.Instantiate(bananaPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.Log($"[{user.name}] 🍌 Đã thả Vỏ Chuối tại tọa độ: {spawnPos}");
        }
    }
}
