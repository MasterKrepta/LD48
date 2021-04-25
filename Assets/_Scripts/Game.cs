using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public  class Game : MonoBehaviour

{
    public static TMP_Text txtRescued, txtTrapped;

    
    private static int _numTrapped;


    private void Start()
    {
        txtRescued = GameObject.Find("txtRescued").GetComponent<TMP_Text>();
        txtTrapped = GameObject.Find("txtTrapped").GetComponent<TMP_Text>();
        UpdateUI();
        

    }
    public static int NumTrapped
    {
        get { return _numTrapped; }
        set 
        { 
            _numTrapped = value;
            UpdateUI();
        }
    }


    private static int _numRescued;

    public static int NumRescued
    {
        get { return _numRescued; }
        set 
        { 
            _numRescued = value;
            UpdateUI();
            CheckGameOver();
        }
    }

    private static void CheckGameOver()
    {
        if (NumTrapped == 0 )
        {
            SceneManager.LoadScene(2);
        }
    }


    
    static void UpdateUI()
    {
        if (txtRescued != null && txtTrapped != null)
        {
            txtTrapped.text = $"Miners Trapped: {_numTrapped}";
            txtRescued.text = $"Miners Rescued: {_numRescued}";
        }
        
    }



}
