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
        speed = Random.Range(6f, 18f); // ��������� �������� ������� ������
    }

    void Update()
    {
        // ������� ������ ����
        rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);

        // ���� ������ ����� �� ������� ������, ���������� ���
        if (rb.position.y < -6f)
        {
            Destroy(gameObject);

            // ��������� ���-�� ������
            GameManager.Instance.LostLive();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���������� ������
            Destroy(gameObject);

            // ����������� ���� � GameManager
            GameManager.Instance.IncreaseScore();
        }
    }
}
