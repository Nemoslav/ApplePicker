using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject applePrefab; // ������ ��� ������
    public float spawnInterval = 2f; // �������� ��������� �����
    public float startDelay = 1f; // �������� ����� ������� ������

    private int score = 0; // ������� ���� ������
    public Text scoreText; // ������ �� UI ����� ��� ����������� �����

    void Awake()
    {
        // ��������, ��� � ��� ���� ������ ���� ��������� GameManager
        if (Instance == null)
        {
            Instance = this; // ������������� ������� ������ ��� ��������� Singleton
            DontDestroyOnLoad(gameObject); // �� ���������� GameManager ��� ������������ ����
        }
        else
        {
            Destroy(gameObject); // ���������� ������������� ���������� GameManager
        }
    }

    void Start()
    {
        // �������� ����� �������� ��� ������ �����
        StartCoroutine(SpawnApples());
    }

    IEnumerator SpawnApples()
    {
        // �������� ����� ������� ������
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            // �������� ��������� ������� ��� ��������� ������
            float randomX = Random.Range(-6f, 6f);
            Vector2 spawnPosition = new Vector2(randomX, 6f);

            // ������� ������
            GameObject apple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);

            // ���� �� ���������� ������
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void IncreaseScore()
    {
        score++; // ����������� ����
        UpdateScoreText(); // ��������� ����������� �����
    }

    void UpdateScoreText()
    {
        // ���������, ��� UI ����� ��� ����������� ����� ����������
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}