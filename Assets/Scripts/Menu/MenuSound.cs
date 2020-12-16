using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public GameObject menuSound;

    void Start()
    {
        Instantiate(menuSound, transform.position, Quaternion.identity);
    }


}
