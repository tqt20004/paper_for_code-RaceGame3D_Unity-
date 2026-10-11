using UnityEngine;

public class CarEntity : MonoBehaviour
{
    [Header("Core Subsystems")]
    public CarStats stats;
    public MoveComponent movement;
    public CarItemHolder itemHolder;
    public CarEffectReceiver effectReceiver;

    [Header("Spawn Points")]
    public Transform shootPoint;
    public Transform dropPoint;

    public CarConfigSO CurrentConfig { get; private set; }

    private void Awake()
    {
        if (stats == null) stats = GetComponent<CarStats>() ?? gameObject.AddComponent<CarStats>();
        if (movement == null) movement = GetComponent<MoveComponent>() ?? gameObject.AddComponent<MoveComponent>();
        if (itemHolder == null) itemHolder = GetComponent<CarItemHolder>() ?? gameObject.AddComponent<CarItemHolder>();
        if (effectReceiver == null) effectReceiver = GetComponent<CarEffectReceiver>() ?? gameObject.AddComponent<CarEffectReceiver>();
    }

    public void Init(CarConfigSO config)
    {
        this.CurrentConfig = config;
        stats.Init(config);
        movement.Init(this);
        itemHolder.Init(this);
        effectReceiver.Init(this);
    }
}
