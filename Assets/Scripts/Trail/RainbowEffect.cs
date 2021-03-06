﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class RainbowEffect : MonoBehaviour {

    [SerializeField]
    private float fadeTime = 0.5f;

    [SerializeField]
    private int superModeExtraSpeedMultiplier = 10;

    private List<Vector3> colors = new List<Vector3>() {
        new Vector3(1,0,0),
        new Vector3(0.875f,0.125f,0),
        new Vector3(0.75f,0.25f,0),
        new Vector3(0.625f,0.425f,0),
        new Vector3(0.5f,0.5f,0),
        new Vector3(0.425f, 0.875f,0),
        new Vector3(0.25f,0.75f,0),
        new Vector3(0.125f,0.875f,0),

        new Vector3(0,1,0),
        new Vector3(0,1,0.125f),
        new Vector3(0,1,0.25f),
        new Vector3(0,1,0.425f),
        new Vector3(0,1,0.5f),
        new Vector3(0,1,0.625f),
        new Vector3(0,1,0.75f),
        new Vector3(0,1,0.875f),

        new Vector3(0,1,1),
        new Vector3(0,0.875f,1),
        new Vector3(0,0.75f,1),
        new Vector3(0,0.625f,1),
        new Vector3(0,0.5f,1),
        new Vector3(0,0.425f,1),
        new Vector3(0,0.25f,1),
        new Vector3(0,0.125f,1),

        new Vector3(0,0,1),
        new Vector3(0.125f,0,1),
        new Vector3(0.25f,0,1),
        new Vector3(0.425f,0,1),
        new Vector3(0.5f,0,1),
        new Vector3(0.625f,0,1),
        new Vector3(0.75f,0,1),
        new Vector3(0.875f,0,1),


        new Vector3(1,0,1),
        new Vector3(1,0,0.875f),
        new Vector3(1,0,0.75f),
        new Vector3(1,0,0.625f),
        new Vector3(1,0,0.5f),
        new Vector3(1,0,0.425f),
        new Vector3(1,0,0.25f),
        new Vector3(1,0,0.125f),

    };

    private Vector3 colorCodes;

    private Vector3 velocity;

    [SerializeField]
    private int colorIndex = 1;

    private bool isUI;

    private SpriteRenderer sprite;

    private Image image;

    void Awake()
    {
        if (GetComponent<SpriteRenderer>() != null)
            sprite = GetComponent<SpriteRenderer>();
        else
        {
            isUI = true;
            image = GetComponent<Image>();
        }
    }
    
    void FixedUpdate () {
        
        if (!isUI)
            sprite.color = GetColor();
        else
            image.color = GetColor();
            
    }

    public void StartColor(int _attachedTrailColorIndex) {
        //set the start color right, so it fits in with the other colors
        colorIndex = _attachedTrailColorIndex - 1;
        if (colorIndex < 0)
            colorIndex = colors.Count - 1;
    }

    private Color GetColor() {

        int nextColorIndex = colorIndex + 1;
        if (nextColorIndex >= colors.Count)
            nextColorIndex = 0;

        //our next color in vector3
        colorCodes = Vector3.SmoothDamp(colorCodes, colors[nextColorIndex], ref velocity, fadeTime / GameSpeed.SpeedMultiplier - (GameSpeed.ExtraSpeed * superModeExtraSpeedMultiplier));

        //when we should go to the next color
        if (Vector3.Distance(colorCodes, colors[nextColorIndex]) < 0.1f) {
            colorIndex = nextColorIndex;
        }

        return new Color(colorCodes.x,colorCodes.y,colorCodes.z, 1);
    }

    public int ColorIndex {
        get { return colorIndex; }
    }
}
