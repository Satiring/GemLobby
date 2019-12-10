using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Config/Music Game")]
public class MusicGameData : ScriptableObject
{
    public AudioClip menuSong;
    public List<AudioClip> desertSongList;

}