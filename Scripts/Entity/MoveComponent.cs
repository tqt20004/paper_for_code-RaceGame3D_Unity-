using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    private CarEntity car;
    public bool canControl = true;
    private Rigidbody rb;

    private float currentTurn;
    private float currentForwardSpeed;

    public void Init(CarEntity entity)
    {
        this.car = entity;
        rb = GetComponent<Rigidbody>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody>();
        rb.mass = 1000f;
        rb.linearDamping = 1f;
        rb.angularDamping = 3f;
    }

    private void Update()
    {
        if (!canControl) return;

        float inputV = Input.GetAxis("Vertical");   // Phím W/S
        float inputH = Input.GetAxis("Horizontal"); // Phím A/D

        // Lấy con số tốc độ thực tế từ CarStats:
        float targetSpeed = inputV * car.stats.GetValue(StatType.TopSpeed);
        float accel = car.stats.GetValue(StatType.Acceleration);
        currentForwardSpeed = Mathf.MoveTowards(currentForwardSpeed, targetSpeed, accel * Time.deltaTime);

        // Góc bẻ lái:
        currentTurn = inputH * 65f * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (!canControl) return;

        // Di chuyển tịnh tiến
        Vector3 moveVelocity = transform.forward * currentForwardSpeed;
        moveVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = moveVelocity;

        // Xoay đầu xe
        Quaternion deltaRotation = Quaternion.Euler(0f, currentTurn, 0f);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    // Hiệu ứng dính chuối/va đập: Xoay tròn 360 độ
    public void Spin360Degrees()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.AddTorque(Vector3.up * 6000f, ForceMode.Impulse);
        }
    }
}
