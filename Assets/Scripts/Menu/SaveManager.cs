using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int score;
    private static string scoreKey = "PLAYER_SCORE";
    public void Save()
    {
        PlayerPrefs.SetInt(scoreKey, score);
        PlayerPrefs.Save();
    }
    public int Load()
    {
        if (PlayerPrefs.HasKey(scoreKey))
        {
            score = PlayerPrefs.GetInt(scoreKey);
            return score;
        }
        else return 0;
    }

    public void SetScore(int Score)
    {
        score = Score;
    }

}
