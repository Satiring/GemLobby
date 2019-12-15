using Ju;

public interface IMusicGameService : IService
{
    void Initiate(MusicGameData _data);
    void Play(string key);
    void PlayMenuSong();
}