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

    public GameObject applePrefab; // Префаб для яблока
    public float spawnInterval = 2f; // Интервал появления яблок
    public float startDelay = 1f; // Задержка перед началом спауна

    private int score = 0; // Текущий счет игрока
    public TMP_Text scoreText; // Ссылка на UI текст для отображения счета

    private int lives = 3;
    public TMP_Text livesText;

   public bool Game = true;

   public GameObject MenuPunel;
    void Awake()
    {
        // Убедимся, что у нас есть только один экземпляр GameManager
        if (Instance == null)
        {
            Instance = this; // Устанавливаем текущий объект как экземпляр Singleton
            DontDestroyOnLoad(gameObject); // Не уничтожать GameManager при переключении сцен
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дублирующиеся экземпляры GameManager
        }
    }

    void Start()
    {
        // Начинаем вызов корутины для спауна яблок
        StartCoroutine(SpawnApples());
    }

    void Menu()
    {

    }

    IEnumerator SpawnApples()
    {
        // Задержка перед началом спауна
        yield return new WaitForSeconds(startDelay);

        while (Game)
        {
            // Получаем случайную позицию для появления яблока
            float randomX = Random.Range(-6f, 6f);
            Vector2 spawnPosition = new Vector2(randomX, 6f);

            // Создаем яблоко
            GameObject apple = Instantiate(applePrefab, spawnPosition, Quaternion.identity);

            // Ждем до следующего спауна
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    public void IncreaseScore()
    {
        score++; // Увеличиваем счет
        UpdateScoreText(); // Обновляем отображение счета
    }

   
    void UpdateScoreText()
    {
        // Проверяем, что UI текст для отображения счета существует
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
            lives--; // Уменьшаем кол-во жизней
            UpdateLivesText(); // Обновляем отображение счета
        }
    }


    void UpdateLivesText()
    {
        // Проверяем, что UI текст для отображения счета существует
        if (livesText != null)
        {
            livesText.text = lives.ToString();
        }
    }
}