using UnityEngine;

public class MusicGameService :  IMusicGameService
{
    private MusicGameData _data;
    private GameObject _musicPlayer;
    private AudioSource _audioSource;

    public void Setup()
    {
        //
        _data = Core.Data.Get<GameData>("gameData").MusicGameData;
    }

    public void Start()
    {
        _musicPlayer = new GameObject();
        _musicPlayer.AddComponent<AudioSource>();
        _audioSource = _musicPlayer.GetComponent<AudioSource>();

        if(_data)
            _musicPlayer.name = "Music Player from MusicPlayerService";
    }

    public void PlayMenuSong()
    {
       Play(_data.menuSong);
    }

    public void PlayRandom()
    {
        Play(_data.desertSongList[0]);
    }

    public void Play(AudioClip clip)
    {
        if (_data != null && _audioSource != null)
        {
            _audioSource.clip = clip;
            _audioSource.Play();

        }
    }
    

    public void Play(string key)
    {
        // TO IMPLEMENT
    }
}