﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public int LevelToLoad;

    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            gm.inputText.text = ("[E] to Enter");
            if (Input.GetKeyDown("e"))
            {
                //Debug.Log("SaveRupees");
                SaveRupees();
                Application.LoadLevel(LevelToLoad);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKeyDown("e"))
            {
                //Debug.Log("SaveRupees TriggerStay");
                SaveRupees();
                Application.LoadLevel(LevelToLoad);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gm.inputText.text = ("[E] to Enter");
        }
    }

    void SaveRupees()
    {
        //Debug.Log("SaveRupees() func");
        //Saves rupees when going to new level
        PlayerPrefs.SetInt("Rupees", gm.rupees);
    }
}
