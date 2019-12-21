using UnityEngine;

public class GameService  : MonoBehaviour, IGameService
{
    private GameData _gameData;
    private StateMachine _gameStateMachine;


    public void Setup()
    {
        _gameStateMachine = new StateMachine();
        _gameData = Resources.Load<GameData>("defaultData");
        if(_gameData)
            Log.Debug("Game Data Loaded");
    }

    public void Start()
    {
        LoadPools();
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
        _gameStateMachine.ChangeState(new TestState());
        //Core.SceneService.RestartScenes();
        //Core.Music.PlayMenuSong();
    }

    private void LoadPools()
    {
        // Initiate All the pools
    }

    private void LoadGameData()
    {
        Core.Data.Set(_gameData,"gameData");
    }
}