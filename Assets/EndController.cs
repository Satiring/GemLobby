﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void StartGame()
    {
        Core.SceneService.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
}