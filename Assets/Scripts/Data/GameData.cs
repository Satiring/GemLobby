using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Config/Game Data")]
public class GameData : ScriptableObject
{
   
   public MusicGameData MusicGameData;
   public SceneGameData SceneGameData;
   public List<PoolInfoData> ListPoolInfoData;
}