using Ju;
using UnityEngine;

public interface ISFXService : IService
{
    void LoadFxData(SFXGameData fx);
    void Play(AudioClip clip);
    void Play(string clip);
    void Stop();
}