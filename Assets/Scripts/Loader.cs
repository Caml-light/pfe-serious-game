﻿using UnityEngine;
using System.Collections;
public class Loader : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject global;

    void Awake()
    {
        Debug.Log("Loader start");

            
        if (Global.instance == null)
        {
            Instantiate(global);
        }

        if (GameManager.instance == null)
        {
            Instantiate(gameManager);
        }

        Debug.Log("Loader finished");
    }


    
}