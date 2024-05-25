using System.Collections;
using UnityEngine;

public class CoursorMovement : MonoBehaviour
{
    public GameObject _effect;
    public float _speed;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;//Находим координаты курсора в пикселях
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);//Переводим пиксели в юниты
            mousePos.z = 0;//Для создания стрелки

            Vector2 direction = (mousePos - transform.position).normalized;//Определяем направление движения

            //Считаем, сколько времени должен идти игрок по формуле t = S/V
            float distance = Vector2.Distance(transform.position, mousePos);
            float time = distance / _speed;

            Instantiate(_effect, mousePos, Quaternion.identity);//Создаём стрелку

            StopAllCoroutines();//На случай, если игрок уже двигается
            StartCoroutine(Move(direction, time));
        }
    }

    IEnumerator Move(Vector3 direction, float time)
    {
        _rb.velocity = direction * _speed;        

        yield return new WaitForSeconds(time);

        _rb.velocity = Vector2.zero;
    }
}