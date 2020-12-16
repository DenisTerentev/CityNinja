using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Player player;
    public Text text;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    void Update()
    {
        text.text = player.health.ToString();
    }
}
