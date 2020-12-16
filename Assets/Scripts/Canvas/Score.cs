using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    private int score=0;
    public void Update()
    {
       text.text = "Score " + score.ToString();
    }
    public int AddScore(int scr)
    {
        score += scr;
        return score;
    }

}
