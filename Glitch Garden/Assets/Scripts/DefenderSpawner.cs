﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    private GameObject defenders;
    private StarDisplay starDisplay;
    // Use this for initialization
    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        defenders = GameObject.Find("Defenders");
        if (!defenders)
        {
            defenders = new GameObject("Projectiles");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        int cost = Button.selectedDefender.GetCost();
        if(starDisplay.UseStars(cost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender();
        }
        else
        {
            print("Insuficient Stars");
        }
    
            
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
        return worldPos;
    }

    Vector3 SnapToGrid(Vector2 position)
    {
        float x = Mathf.RoundToInt(position.x);
        float y = Mathf.RoundToInt(position.y);
        float z = -1f;
        return new Vector3(x, y, z);
    }

    private void SpawnDefender()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundPos = SnapToGrid(rawPos);
        Defender myDefender = Instantiate(Button.selectedDefender, roundPos, Quaternion.identity);
        myDefender.transform.parent = defenders.transform;
    }
}
