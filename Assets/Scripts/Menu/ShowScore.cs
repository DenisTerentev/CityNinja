using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    public Text text;
    private SaveManager saveManager;
    public void Start()
    {
        saveManager = GetComponent<SaveManager>();
        text.text = saveManager.Load().ToString();
    }
}
