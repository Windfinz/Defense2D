using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public Transform shield;
    private float dis = 1f;
    public FixedJoystick joystick;
    public float rotationSpeed = 5f;
    public float smoothing = 5f; 
    private Vector3 currentDirection = Vector3.zero;

    private void Update()
    {
        if (joystick.Direction.magnitude > 0)
        {
            Vector2 direction = joystick.Direction;

            currentDirection = Vector3.Lerp(currentDirection, direction, smoothing * Time.deltaTime);

            float rads = Mathf.Atan2(currentDirection.y, currentDirection.x);
            float degrees = rads * Mathf.Rad2Deg;

            shield.localPosition = new Vector3(Mathf.Cos(rads) * dis, Mathf.Sin(rads) * dis, 0);
            shield.localEulerAngles = new Vector3(0, 0, degrees - 90);
        }
    }
}
