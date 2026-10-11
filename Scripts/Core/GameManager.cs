using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Core References")]
    public GameSpawner spawner;
    public CarConfigSO playerCarConfig;
    public int totalLaps = 3;

    private List<CarEntity> activeCars = new List<CarEntity>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        StartRace();
    }

    public void StartRace()
    {
        if (spawner != null && playerCarConfig != null)
        {
            CarEntity player = spawner.SpawnCar(playerCarConfig, 0);
            activeCars.Add(player);
        }

        GameEvents.OnRaceStarted?.Invoke();
        Debug.Log("🏁 CUỘC ĐUA CHÍNH THỨC BẮT ĐẦU!");
    }
}
