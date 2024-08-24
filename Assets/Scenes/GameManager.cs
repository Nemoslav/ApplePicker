using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
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
    public TMP_Text scoreText; // ������ �� UI ����� ��� ����������� �����

    private int lives = 3;
    public TMP_Text livesText;

   public bool Game = true;

   public GameObject MenuPunel;
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

    void Menu()
    {

    }

    IEnumerator SpawnApples()
    {
        // �������� ����� ������� ������
        yield return new WaitForSeconds(startDelay);

        while (Game)
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
            scoreText.text = score.ToString();
        }
    }

    public void LostLive()
    {
        if(lives <= 0)
        {
            Game = false;
        }
        if (lives > 0)
        {
            lives--; // ��������� ���-�� ������
            UpdateLivesText(); // ��������� ����������� �����
        }
    }


    void UpdateLivesText()
    {
        // ���������, ��� UI ����� ��� ����������� ����� ����������
        if (livesText != null)
        {
            livesText.text = lives.ToString();
        }
    }
}