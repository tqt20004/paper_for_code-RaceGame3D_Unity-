using UnityEngine;

[CreateAssetMenu(fileName = "NewCarConfig", menuName = "ZingSpeed/CarConfig")]
public class CarConfigSO : ScriptableObject
{
    [Header("General Info")]
    public string carName = "Default Kart";
    public GameObject carPrefab;

    [Header("Core Performance Stats")]
    public float topSpeed = 30f;
    public float acceleration = 12f;
    public float driftGrip = 5f;
    public int maxHealth = 100;
}
