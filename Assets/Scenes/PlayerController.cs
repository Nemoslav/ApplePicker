using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // �������� ����������� �������
    public float moveLimit = 6f; // ����� ����������� �� �����������

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { while (GameManager.Instance.Game)
        {
            // �������� ���� �� ����������� (�������� ����� � ������)
            float moveInput = Input.GetAxisRaw("Horizontal");

            // ��������� ����� ������� �������
            float newPositionX = rb.position.x + moveInput * speed * Time.deltaTime;

            // ������������ �������� ������� � �������� ������
            newPositionX = Mathf.Clamp(newPositionX, -moveLimit, moveLimit);

            // ������������� ����� ������� �������
            rb.MovePosition(new Vector2(newPositionX, rb.position.y));
        }
    }
}
