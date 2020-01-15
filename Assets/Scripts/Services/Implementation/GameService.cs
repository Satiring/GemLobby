using System;
using UnityEngine;

public class GameService  : MonoBehaviour, IGameService
{
    private GameData _gameData;
    private StateMachine _gameStateMachine;
    public GameStateSharedData gameStateShared;

    private void Update()
    {
        if (gameStateShared)
        {
            if (gameStateShared.gemsPicked >= _gameData.totalGemsTopick)
            {
                
                FinishGame();
            }    
        }
        
    }

    public void Setup()
    {
       
        _gameStateMachine = new StateMachine();
        _gameData = Resources.Load<GameData>("defaultData");
        if(_gameData)
            Log.Debug("Game Data Loaded");
        
        gameStateShared = _gameData.gameStateSharedData;
        gameStateShared.gemsPicked = 0;
    }

    public void Start()
    {
        StartGame();
        LoadGameData();
    }


    public void LoadGameData(GameData gameData)
    {
        if (gameData != null)
        {
            _gameData = gameData;
        }
    }
    
    public void StartGame()
    {
        Debug.Log("START GAME");
       // _gameStateMachine.ChangeState(new TestState());
       Core.Music.PlayRandom();
    }

    public void FinishGame()
    {
        Log.Debug("Terminado el juego");
        Core.SceneService.LoadScene(2);
    }

    public void Restart()
    {
        gameStateShared.gemsPicked = 0;
    }

    private void LoadGameData()
    {
        Core.Data.Set(_gameData,"gameData");
    }
    
}