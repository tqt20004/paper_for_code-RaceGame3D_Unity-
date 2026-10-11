using UnityEngine;

public class NitroBehavior : IItemBehavior
{
    private float boostDuration;
    private float speedBonus;

    public NitroBehavior(float duration = 3f, float bonus = 25f)
    {
        this.boostDuration = duration;
        this.speedBonus = bonus;
    }

    public void Execute(CarEntity user)
    {
        // Kích hoạt nạp NitroSpeedEffect vào mặt trận chịu trận của xe
        user.effectReceiver.ApplyEffect(new NitroSpeedEffect(boostDuration, speedBonus));
        Debug.Log($"[{user.name}] 🚀 Kích hoạt Nitro! +{speedBonus} Tốc độ trong {boostDuration}s!");
    }
}
