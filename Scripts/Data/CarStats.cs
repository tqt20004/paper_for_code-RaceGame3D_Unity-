using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    private Dictionary<StatType, CarStat_Runtime> statsMap = new Dictionary<StatType, CarStat_Runtime>();

    public void Init(CarConfigSO config)
    {
        statsMap.Clear();
        statsMap[StatType.TopSpeed] = new CarStat_Runtime(StatType.TopSpeed, config.topSpeed);
        statsMap[StatType.Acceleration] = new CarStat_Runtime(StatType.Acceleration, config.acceleration);
        statsMap[StatType.DriftGrip] = new CarStat_Runtime(StatType.DriftGrip, config.driftGrip);
        statsMap[StatType.Health] = new CarStat_Runtime(StatType.Health, config.maxHealth);
    }

    public float GetValue(StatType type)
    {
        return statsMap.TryGetValue(type, out var stat) ? stat.CurrentValue : 0f;
    }

    public void AddModifier(StatType type, StatModifier mod)
    {
        if (statsMap.TryGetValue(type, out var stat)) stat.AddModifier(mod);
    }

    public void RemoveModifier(StatType type, StatModifier mod)
    {
        if (statsMap.TryGetValue(type, out var stat)) stat.RemoveModifier(mod);
    }
}
