using UnityEngine;

public class BananaSlipEffect : EffectBase
{
    public BananaSlipEffect(float duration = 1.5f)
    {
        this.duration = duration;
        this.isHarmful = true; // Là hiệu ứng xấu
    }

    public override void OnApply()
    {
        owner.movement.canControl = false; // Khóa tay lái
        owner.movement.Spin360Degrees();    // Xoay 360 độ
        Debug.Log($"[{owner.name}] 🍌 Trượt vỏ chuối! Mất lái trong {duration}s!");
    }

    public override void OnRemove()
    {
        owner.movement.canControl = true;  // Trả lại quyền lái xe
        Debug.Log($"[{owner.name}] Đã lấy lại quyền kiểm soát tay lái.");
    }
}
