using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;
    public static int lives = 3;
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public GameObject gameOverText;
    public AudioClip gameOverSound;
    public GameObject spawner;


    private void Update()
    {
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        if (lives<=0)
        {
            AudioSystem.Play(gameOverSound);
            gameOverText.SetActive(true);
            Destroy(spawner);
            lives = 3;
            score = 0;
        }
    }
}
