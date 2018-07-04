﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {
    private Text text;
    public static int score = 0;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
        text.text = score.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    public void Score(int points)
    {
        score += points;
        text.text = score.ToString();
    }

    public static void Reset()
    {
        score = 0;        
    }
}
