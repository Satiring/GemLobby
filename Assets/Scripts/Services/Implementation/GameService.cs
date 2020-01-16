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

        gameStateShared = _gameData.gameStateSharedData;
        gameStateShared.gemsPicked = 0;
    }

    public void Start()
    {
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
        Restart();
        Core.SceneService.LoadScene(1);
    }

    public void FinishGame()
    {
        Core.SceneService.LoadScene(2);
    }

    public void Restart()
    {
        gameStateShared.gemsPicked = 0;
        Core.Data.Get<PlayerController>("player").InitializeHealth();
    }

    private void LoadGameData()
    {
        Core.Data.Set(_gameData,"gameData");
    }
    
}