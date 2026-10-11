using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    TopSpeed,
    Acceleration,
    DriftGrip,
    Health
}

[System.Serializable]
public class CarStat_Runtime
{
    public StatType statType;
    public float baseValue;
    private List<StatModifier> modifiers = new List<StatModifier>();

    public CarStat_Runtime(StatType type, float baseVal)
    {
        this.statType = type;
        this.baseValue = baseVal;
    }

    // Tính toán con số thực tế theo thời gian thực (Base + Flat + Percent):
    public float CurrentValue
    {
        get
        {
            float flatBonus = 0f;
            float percentBonus = 0f;

            for (int i = 0; i < modifiers.Count; i++)
            {
                if (modifiers[i].modType == StatModType.Flat)
                    flatBonus += modifiers[i].value;
                else if (modifiers[i].modType == StatModType.Percent)
                    percentBonus += modifiers[i].value;
            }

            float finalVal = (baseValue + flatBonus) * (1f + percentBonus);
            return Mathf.Max(0f, finalVal);
        }
    }

    public void AddModifier(StatModifier mod) => modifiers.Add(mod);
    public void RemoveModifier(StatModifier mod) => modifiers.Remove(mod);
    public void ClearModifiers() => modifiers.Clear();
}
