using UnityEngine;

public class JoystickMovement : MonoBehaviour
{
    public Joystick _joystick;
    public float _speed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float _horInput = _joystick.Horizontal;
        float _vertInput = _joystick.Vertical;

        Vector2 velocity = new Vector2(_horInput, _vertInput) * _speed;
        _rb.velocity = velocity;
    }
}