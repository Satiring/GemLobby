using Ju;


public interface ISceneService : IService
{
    void LoadScene(int sceneNumber);
    void RestartScenes();
    void LoadScene(string scene);
    void Initiate(SceneGameData sceneData);
}