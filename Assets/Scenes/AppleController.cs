using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = Random.Range(6f, 18f); // —лучайна€ скорость падени€ €блока
    }

    void Update()
    {
        // ƒвигаем €блоко вниз
        rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);

        // ≈сли €блоко вышло за пределы экрана, уничтожаем его
        if (rb.position.y < -6f)
        {
            Destroy(gameObject);

            // ”меньшаем кол-во жизней
            GameManager.Instance.LostLive();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ”ничтожаем €блоко
            Destroy(gameObject);

            // ”величиваем счет в GameManager
            GameManager.Instance.IncreaseScore();
        }
    }
}
