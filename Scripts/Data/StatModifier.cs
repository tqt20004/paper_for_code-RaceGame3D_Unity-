public enum StatModType
{
    Flat,       // Cộng/trừ số tuyệt đối (ví dụ: +20 tốc độ)
    Percent     // Cộng/trừ theo phần trăm (ví dụ: +30% tốc độ)
}

[System.Serializable]
public class StatModifier
{
    public float value;
    public StatModType modType;

    public StatModifier(float value, StatModType modType = StatModType.Flat)
    {
        this.value = value;
        this.modType = modType;
    }
}
