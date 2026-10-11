public abstract class EffectBase
{
    public CarEntity owner;
    public float duration;
    public float remainingDuration;
    public bool isHarmful = false; // Phân biệt hiệu ứng xấu để check Khiên

    public virtual void Init(CarEntity target, float duration, bool isHarmful = false)
    {
        this.owner = target;
        this.duration = duration;
        this.remainingDuration = duration;
        this.isHarmful = isHarmful;

        OnApply(); // Vừa dính là thực thi ngay
    }

    public abstract void OnApply();

    public virtual void OnUpdate(float deltaTime)
    {
        remainingDuration -= deltaTime;
        if (remainingDuration <= 0f)
        {
            OnRemove();
        }
    }

    public abstract void OnRemove();
}
