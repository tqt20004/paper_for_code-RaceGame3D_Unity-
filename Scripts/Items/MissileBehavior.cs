using UnityEngine;

public class MissileBehavior : IItemBehavior
{
    private GameObject missilePrefab;

    public MissileBehavior(GameObject prefab = null)
    {
        this.missilePrefab = prefab;
    }

    public void Execute(CarEntity user)
    {
        // 1. Quét tìm xe đối thủ phía trước trong góc nhìn:
        CarEntity target = FindTargetAhead(user);

        Vector3 spawnPos = user.shootPoint != null 
            ? user.shootPoint.position 
            : user.transform.position + user.transform.forward * 2f;

        Quaternion spawnRot = user.transform.rotation;

        if (missilePrefab != null)
        {
            GameObject missileObj = Object.Instantiate(missilePrefab, spawnPos, spawnRot);
            // Có thể gắn logic bay đuổi target vào Prefab tên lửa
        }

        Debug.Log($"[{user.name}] 🚀 Bắn Tên Lửa! Mục tiêu: {(target != null ? target.name : "Thẳng về phía trước")}");
    }

    // Thuật toán đơn giản tìm xe đối thủ phía trước:
    private CarEntity FindTargetAhead(CarEntity user)
    {
        CarEntity[] allCars = Object.FindObjectsByType<CarEntity>(FindObjectsSortMode.None);
        CarEntity bestTarget = null;
        float closestDist = float.MaxValue;

        foreach (var other in allCars)
        {
            if (other == user) continue;

            Vector3 toOther = other.transform.position - user.transform.position;
            float dot = Vector3.Dot(user.transform.forward, toOther.normalized);

            // Xe nằm phía trước (dot > 0.4) và gần nhất:
            if (dot > 0.4f && toOther.magnitude < closestDist)
            {
                closestDist = toOther.magnitude;
                bestTarget = other;
            }
        }
        return bestTarget;
    }
}
