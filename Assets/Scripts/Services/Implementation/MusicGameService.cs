using UnityEngine;

public class MusicGameService :  IMusicGameService
{
    private MusicGameData _data;
    private GameObject _musicPlayer;
    private AudioSource _audioSource;

    public void Setup()
    {
        _musicPlayer = new GameObject();
        _musicPlayer.AddComponent<AudioSource>();
        _musicPlayer.name = "Music Player from MusicPlayerService";

        _audioSource = _musicPlayer.GetComponent<AudioSource>();
    }

    public void Start()
    {
        // 
        Debug.Log("Music Game Service Started");
    }


    public void Initiate(MusicGameData musicGameData)
    {
        _data = musicGameData;
    }

    public void PlayMenuSong()
    {
       Play(_data.menuSong);
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