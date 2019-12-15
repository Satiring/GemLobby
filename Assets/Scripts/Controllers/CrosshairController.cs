using System;
using System.Collections;
using System.Collections.Generic;
using Ju;
using UnityEngine;

public class Crosshair : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }

    private void updatePosition()
    {
        Vector2 cameraPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cameraPoint;
    }
    
}
