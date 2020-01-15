using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(menuName = "Config/Scene Game Data")]
public class SceneGameData : ScriptableObject
{
   public bool isActive = false;
   public int initialSceneNumber;
   public List<SceneSetup> sceneSetupList;

   [System.Serializable]
   public class SceneSetup
   {
      public string sceneName;
      public int sceneNumber;
   }
   
}