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
        //upewniam si�, �e gra wystartuje po za�adowaniu poziomu
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Punkty: " + score;
    }
    //funkcja, kt�ra dodaje nam zadan� ilo�� punkt�w do wyniku, domy�lnie 10
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
        //pobierz nazw� sceny w kt�rej jeste�my
        string sceneName = SceneManager.GetActiveScene().name;
        //prze�aduj scen�
        SceneManager.LoadScene(sceneName);
    }
}
