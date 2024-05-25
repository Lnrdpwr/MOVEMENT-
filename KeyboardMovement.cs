using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float _speed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Используйте Input.GetAxis() для плавного передвижения
        float _horInput = Input.GetAxisRaw("Horizontal");
        float _vertInput = Input.GetAxisRaw("Vertical");

        Vector2 velocity = new Vector2(_horInput, _vertInput).normalized * _speed;
        //normalized возвращает вектор с длиной 1. Благодаря этому при движении по диагонали игрок не ускоряется

        _rb.velocity = velocity;
    }
}