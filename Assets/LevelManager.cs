using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int score;
    //score counter
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
}
