using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int score;
    //score counter
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    public GameObject GameOverScreen;
    void Start()
    {
        score = 0;
        //upewniam siê, ¿e gra wystartuje po za³adowaniu poziomu
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Punkty: " + score;
    }
    //funkcja, która dodaje nam zadan¹ iloœæ punktów do wyniku, domyœlnie 10
    public void AddPoints(int points = 10)
    {
        score += points;
    }
    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        //wystartuj czas
        Time.timeScale = 1;
        //pobierz nazwê sceny w której jesteœmy
        string sceneName = SceneManager.GetActiveScene().name;
        //prze³aduj scenê
        SceneManager.LoadScene(sceneName);
    }
}
