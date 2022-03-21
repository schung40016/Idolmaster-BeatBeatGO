using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // This class handles combos and score.
    public static ScoreManager instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TMPro.TextMeshPro scoreText;
    public TMPro.TextMeshPro pointText;
    public TMPro.TextMeshPro hitMissIndicator;
    public GameObject particles;
    static int comboScore;
    static int pointScore;
    static string currentIndicator = "";

    private void Start()
    {
        instance = this;
        comboScore = 0;
        pointScore = 0;
    }

    public static void Hit()
    {
        comboScore += 1;
        pointScore += (comboScore * 5 + 50);
        currentIndicator = "PERFECT!";
        instance.hitSFX.Play();
    }

    public static void Miss()
    {
        comboScore = 0;
        currentIndicator = "MISS!";
        instance.missSFX.Play();
    }

    private void Update()
    {
        scoreText.text = comboScore.ToString();
        pointText.text = pointScore.ToString();
        hitMissIndicator.text = currentIndicator;

        if (comboScore > 49)
        {
            particles.SetActive(true);
        }
        else
        {
            particles.SetActive(false);
        }
    }
}
