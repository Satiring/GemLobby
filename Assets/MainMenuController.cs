using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Transform startGame;
    public Transform quitGame;
    public float LogoDuration;
    public GameObject Logo;
    public int logoYOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        if (Logo)
        {
            Logo.transform.DOLocalMoveY( logoYOffset, LogoDuration, false).SetEase(Ease.InOutExpo);
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
        Core.SceneService.LoadScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }
    
}
