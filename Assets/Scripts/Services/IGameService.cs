using Ju;

public interface IGameService : IService
{
    void LoadGameData(GameData gameData);
    void StartGame();
}