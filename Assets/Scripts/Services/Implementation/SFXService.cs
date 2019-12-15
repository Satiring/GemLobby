﻿using UnityEngine;

public class SFXService : ISFXService
{
    private SFXGameData _data;
    private GameObject _fxPlayer;
    private AudioSource _audioSource;
    
    public void Setup()
    {
        _fxPlayer = new GameObject();
        _fxPlayer.AddComponent<AudioSource>();
        _fxPlayer.name = "FX Player from FXService";
        _audioSource = _fxPlayer.GetComponent<AudioSource>();
        if (_audioSource)
        {
            Log.Debug("_audiosource in PlayerFX listo");
        }
    }

    public void Start()
    {
        Log.Debug("Fx Service Started");
    }

    public void LoadFxData(SFXGameData fx)
    {
        _data = fx;
    }

    public void Play(AudioClip clip)
    {
        if (_audioSource)
        {
            if (clip)
            {
                setClip(clip);
                _audioSource.Play();
            }
            
        }
    }

    public void PlayHit()
    {
        Play(_data.hitSound);
    }
    
    public void Play(string clip)
    {
        // TO IMPLEMENT
    }

    private void setClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
    }

    public void Stop()
    {
        // TO IMPLEMENT
    }
}