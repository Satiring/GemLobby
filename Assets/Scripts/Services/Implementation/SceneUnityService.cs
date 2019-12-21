using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneUnityService : ISceneService
{
    private SceneGameData _data;
    private int _actualScene;
    
    public void Setup()
    {
        _data = Core.Data.Get<GameData>("gameData").SceneGameData;
    }

    public void Start()
    {
        if (_data)
            _actualScene = _data.initialSceneNumber;
        SceneManager.LoadScene(_actualScene);
    }

    public void LoadScene(int sceneNumber)
    {
        string scene;
        if (sceneNumber < _data.sceneSetupList.Count)
        {
            _actualScene = sceneNumber;
            SceneManager.LoadScene(_actualScene);
        }
        else
        {
            Log.Error("La escena no existe.");
        }
    }

    public void RestartScenes()
    {
        if (_data)
        {
            LoadScene(_data.initialSceneNumber);
        }

        
    }
    

    // TODO INNEFICIENT. Dont Save the _actualScene
    public void LoadScene(string scene)
    {
       throw new NotImplementedException();
    }
}