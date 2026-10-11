public class NitroSpeedEffect : EffectBase
{
    private StatModifier speedBonus;

    public NitroSpeedEffect(float duration = 3f, float bonus = 25f)
    {
        this.duration = duration;
        this.isHarmful = false; // Là hiệu ứng có lợi
        this.speedBonus = new StatModifier(bonus, StatModType.Flat);
    }

    public override void OnApply()
    {
        // Nhét Modifier tăng tốc vào CarStats:
        owner.stats.AddModifier(StatType.TopSpeed, speedBonus);
    }

    public override void OnRemove()
    {
        // Hết giờ: Rút Modifier ra khỏi CarStats:
        owner.stats.RemoveModifier(StatType.TopSpeed, speedBonus);
    }
}
