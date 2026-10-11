using UnityEngine;

public class ShieldEffect : EffectBase
{
    public ShieldEffect(float duration = 10f)
    {
        this.duration = duration;
        this.isHarmful = false;
    }

    public override void OnApply()
    {
        Debug.Log($"[{owner.name}] 🛡️ KHIÊN BẢO VỆ ĐÃ KÍCH HOẠT (Thời hạn: {duration}s)!");
    }

    public override void OnRemove()
    {
        Debug.Log($"[{owner.name}] Khiên bảo vệ đã hết hạn.");
    }
}
