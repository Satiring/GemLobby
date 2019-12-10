using UnityEngine;

public class GameService  : IGameService
{
    private GameData _gameData;
    
    public void Setup()
    {
       
    }

    public void Start()
    {
        LoadPools();
    }


    public void LoadGameData(GameData gameData)
    {
        Log.Debug("Se produce la llamada al Game service");
        if (gameData != null)
        {
            _gameData = gameData;
            
            Core.Music.Initiate(gameData.MusicGameData);
            Core.SceneService.Initiate(_gameData.SceneGameData);
        }
        
    }

    public void StartGame()
    {
        Debug.Log("Inicializacion Game");
        //Core.SceneService.RestartScenes();
        Core.Music.PlayMenuSong();
    }

    private void LoadPools()
    {
        // Initiate All the pools
    }
}