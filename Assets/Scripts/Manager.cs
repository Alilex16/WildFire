using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject badGuysPlaceholder;

    public Text levelText;
    public Text roundText;
    public Text timePlayed;

    private float timerRound;
    public int roundNumber;
    private int roundNumberMax = 3;
    private int roundNumberMaxBoss = 5;
    private int timePerRound = 10; // in seconds // original round is 60 seconds

    public static float delayBeforeStart;

    private void Awake()
    {
        float startingDelayedTimer = badGuysPlaceholder.GetComponentInChildren<BadGuy>().delayStartTimer;
        timerRound = startingDelayedTimer; // -2 // variable to starting timer
        delayBeforeStart = startingDelayedTimer;
        //roundNumber = 1;
        UpdateTexts();
    }
    
    private void UpdateTexts()
    {
        levelText.GetComponentInChildren<Text>().text = ManagerScenes.levelChosenNumberStatic.ToString(); // **
        timePlayed.GetComponentInChildren<Text>().text = timerRound.ToString("00.00");

        if (roundNumber >= 1)
        {
            roundText.GetComponentInChildren<Text>().text = roundNumber.ToString("0"); // **
        }
    }

    private void FixedUpdate()
    {
        timerRound += Time.deltaTime;
        roundNumber = Mathf.FloorToInt(1 + (timerRound / timePerRound)); // if !boss, highest roundNumber = 3, else is 5
        
        var isBoss = badGuysPlaceholder.GetComponentInChildren<BadGuy>().isBoss;

        if (isBoss) //Debug.Log("Is a boss -> Allows rounds to go up to level 5.");
        {
            if (roundNumber > roundNumberMaxBoss)
            {
                roundNumber = roundNumberMaxBoss;
            }
        }
        else //Debug.Log("Is NOT a boss -> Allows rounds to go only up to level 3.");
        {
            if (roundNumber > roundNumberMax)
            {
                roundNumber = roundNumberMax;
            }
        }

        UpdateTexts(); // really only the timePlayed should be updated every tick, not the other text. Better to split?
    }
}

