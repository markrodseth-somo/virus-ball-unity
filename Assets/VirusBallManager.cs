using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VirusBallManager
{
    public enum GameStatus
    {
        Started = 0,
        Stopped = 1, 
        Paused = 3
    }

    public static GameStatus CurrentGameStatus = GameStatus.Stopped;
    public static float NumberOfBalls = 0;
    public static float NumberOfRedBalls = 0;
    public static float NumberOfGreenBalls = 0;
    public static GameObject healthBar;
    public static GameObject score;

    public static List<VirusBall> Balls { get; set; }

    public static void Initialise()
    {
        healthBar = GameObject.Find("HealthBarBackground");
        score = GameObject.Find("Score");
        Balls = new List<VirusBall>();
    }

    public static void UpdateHealthBar()
    {
        int count = 0; 
        int countItems = 20;
        float countRedItems = countItems * PercentageRedBalls / 100;
        float countGreenItems = countItems * PercentageGreenBalls / 100;

        foreach (Transform child in healthBar.transform)
        {
            var image = child.GetComponent<Image>();
            image.color = (count < countGreenItems) ? Color.green : Color.red;
            count++;
        }

        var text = score.GetComponent<Text>();
        text.text = VirusBallManager.NumberOfBalls.ToString();

        if (PercentageRedBalls == 100)
        {
            VirusBallManager.CurrentGameStatus = GameStatus.Stopped;

            foreach (VirusBall child in Balls)
            {
                Rigidbody2D rigidbody = child.GetComponent<Rigidbody2D>();
                rigidbody.velocity = new Vector2(0,0);
            }
        }

    }

    public static void AddBall(VirusBall virusBall)
    {
        Balls.Add(virusBall);

        VirusBallManager.NumberOfBalls++;

        if (virusBall.IsVirus)
            VirusBallManager.NumberOfRedBalls++;
        else
            VirusBallManager.NumberOfGreenBalls++;

        UpdateHealthBar();
    }

    public static void InfectBall()
    {
        VirusBallManager.NumberOfRedBalls++;
        VirusBallManager.NumberOfGreenBalls--;

        UpdateHealthBar();


    }

    public static void HealBall()
    {
        VirusBallManager.NumberOfRedBalls--;
        VirusBallManager.NumberOfGreenBalls++;

        UpdateHealthBar();


    }

    public static float PercentageRedBalls
    {
        get
        {
            if (VirusBallManager.NumberOfBalls == 0)
                return 0; 

            float percentageOfRedBalls = (VirusBallManager.NumberOfRedBalls / VirusBallManager.NumberOfBalls) * 100;
            return percentageOfRedBalls;
        }


    }

    public static float PercentageGreenBalls
    {
        get
        {
            if (VirusBallManager.NumberOfBalls == 0)
                return 0;

            float percentageOfRedBalls = (VirusBallManager.NumberOfGreenBalls / VirusBallManager.NumberOfBalls) * 100;
            return percentageOfRedBalls;
        }


    }

}
