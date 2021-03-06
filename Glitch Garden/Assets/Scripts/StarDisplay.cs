﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    public enum Status { SUCCESS, FAILURE}
    private Text text;
    private int stars = 100;
	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
        text.text = stars.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public Status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return Status.SUCCESS;
        }
        return Status.FAILURE;

    }

    private void UpdateDisplay()
    {
        text.text = stars.ToString();
    }

}
