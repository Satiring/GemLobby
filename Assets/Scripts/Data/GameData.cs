using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Config/Game Data")]
public class GameData : ScriptableObject
{
   public int totalGemsTopick = 10;
   public GameStateSharedData gameStateSharedData;
   public UIData UIData;
   public MusicGameData MusicGameData;
   public SceneGameData SceneGameData;
}