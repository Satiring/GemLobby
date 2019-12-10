using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneUnityService : ISceneService
{
    private SceneGameData _data;
    private int _actualScene;
    
    public void Setup()
    {
       
    }

    public void Start()
    {
    }

    public void LoadScene(int sceneNumber)
    {
        string scene;
        if (sceneNumber < _data.sceneSetupList.Count)
        {
            SceneManager.LoadScene(sceneNumber);
            _actualScene = sceneNumber;
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
    

    // INNEFICIENT. Dont Save the _actualScene
    public void LoadScene(string scene)
    {
        // TO IMPLEMENT
    }

    public void Initiate(SceneGameData sceneData)
    {
        _data = sceneData;
    }
}