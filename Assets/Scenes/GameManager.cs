using System.Collections;
using System.Collections.Generic;
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
    public Text scoreText; // Ссылка на UI текст для отображения счета

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

    IEnumerator SpawnApples()
    {
        // Задержка перед началом спауна
        yield return new WaitForSeconds(startDelay);

        while (true)
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
            scoreText.text = "Score: " + score.ToString();
        }
    }
}