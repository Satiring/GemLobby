using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndController : MonoBehaviour
{
    
    public Transform startGame;
    public Transform quitGame;
    public Transform message;
    
    private void Start()
    {
        if (message)
        {
            message.DOMoveY(message.position.y - 30, 1, false).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);   
        }
        
        if (startGame)
        {
            startGame.DOMoveY(startGame.position.y - 30, 1, false).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);
        }

        if (quitGame)
        {
            quitGame.DOMoveY(quitGame.position.y - 30, 1, false).SetEase(Ease.OutSine).SetLoops(-1, LoopType.Yoyo);   
        }
    }

    public void StartGame()
    {
        Core.Game.StartGame();
       
    }

    public void QuitGame(){
        Application.Quit();
    }
}
