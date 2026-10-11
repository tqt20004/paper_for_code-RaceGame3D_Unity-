using System.Collections.Generic;
using UnityEngine;

public class CarEffectReceiver : MonoBehaviour
{
    private CarEntity owner;
    private List<EffectBase> activeEffects = new List<EffectBase>();

    public void Init(CarEntity entity)
    {
        this.owner = entity;
    }

    // Nhận hiệu ứng từ thế giới bên ngoài (dẫm chuối, ăn tên lửa, dính nitro):
    public void ApplyEffect(EffectBase effect)
    {
        // 1. Kiểm tra Khiên bảo vệ:
        if (effect.isHarmful && HasEffect<ShieldEffect>())
        {
            RemoveEffect<ShieldEffect>();
            Debug.Log($"[{owner.name}] 🛡️ KHIÊN ĐÃ CHẶN ĐÒN ĐÁNH TỪ: {effect.GetType().Name}!");
            return;
        }

        // 2. Nạp effect vào danh sách và kích hoạt:
        effect.Init(owner, effect.duration, effect.isHarmful);
        activeEffects.Add(effect);
    }

    private void Update()
    {
        // Nuôi các Effect bằng Time.deltaTime của Unity:
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            activeEffects[i].OnUpdate(Time.deltaTime);

            if (activeEffects[i].remainingDuration <= 0f)
            {
                activeEffects.RemoveAt(i);
            }
        }
    }

    public bool HasEffect<T>() where T : EffectBase
    {
        return activeEffects.Exists(e => e is T);
    }

    public void RemoveEffect<T>() where T : EffectBase
    {
        var eff = activeEffects.Find(e => e is T);
        if (eff != null)
        {
            eff.OnRemove();
            activeEffects.Remove(eff);
        }
    }

    public void ClearAll()
    {
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            activeEffects[i].OnRemove();
        }
        activeEffects.Clear();
    }
}
