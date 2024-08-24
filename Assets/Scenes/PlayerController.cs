using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Скорость перемещения корзины
    public float moveLimit = 6f; // Лимит перемещения по горизонтали

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { while (GameManager.Instance.Game)
        {
            // Получаем ввод по горизонтали (движение влево и вправо)
            float moveInput = Input.GetAxisRaw("Horizontal");

            // Вычисляем новую позицию корзины
            float newPositionX = rb.position.x + moveInput * speed * Time.deltaTime;

            // Ограничиваем движение корзины в пределах экрана
            newPositionX = Mathf.Clamp(newPositionX, -moveLimit, moveLimit);

            // Устанавливаем новую позицию корзины
            rb.MovePosition(new Vector2(newPositionX, rb.position.y));
        }
    }
}
