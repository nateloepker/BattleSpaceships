﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject poi;
    public GameObject[] panels;
    public float scrollSpeed = -30f;
    public float motionMult = .25f;
 
    private float panelHt;
    private float depth;

    // Start is called before the first frame update
    void Start()
    {
        panelHt = panels[0].transform.localScale.y;
        depth = panels[0].transform.position.z;

        // Set initial positions of panels
        panels[0].transform.position = new Vector3(0,0,depth);
        panels[1].transform.position = new Vector3(0,panelHt,depth);        
    }

    // Update is called once per frame
    void Update()
    {
        float tY = 0;
        float tX = 0;

        if(poi != null)
        {
            tX = -poi.transform.position.x * motionMult;
        }

        // Position panels[0]
        panels[0].transform.position = new Vector3(tX, tY, depth);
     
        // Then position panels[1] where needed to make a continuous starfield
        if(tY >= 0)
        {
            panels[1].transform.position = new Vector3(tX, tY-panelHt, depth);
        }
        else
        {
            panels[1].transform.position = new Vector3(tX, tY+panelHt, depth);   
        }   
    }
}
