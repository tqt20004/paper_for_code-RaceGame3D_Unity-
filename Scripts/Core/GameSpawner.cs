using UnityEngine;

public class GameSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    // Nhận CarConfigSO để tạo xe lên đường đua:
    public CarEntity SpawnCar(CarConfigSO config, int spawnIndex)
    {
        Transform sp = (spawnPoints != null && spawnIndex < spawnPoints.Length) 
            ? spawnPoints[spawnIndex] 
            : transform;

        GameObject carObj = null;
        if (config.carPrefab != null)
        {
            carObj = Instantiate(config.carPrefab, sp.position, sp.rotation);
        }
        else
        {
            carObj = new GameObject(config.carName);
            carObj.transform.position = sp.position;
            carObj.transform.rotation = sp.rotation;
        }

        CarEntity car = carObj.GetComponent<CarEntity>() ?? carObj.AddComponent<CarEntity>();
        car.Init(config);

        GameEvents.OnCarSpawned?.Invoke(car);
        Debug.Log($"[GameSpawner] 🏁 Đã tạo thành công xe: {config.carName}");
        return car;
    }
}
