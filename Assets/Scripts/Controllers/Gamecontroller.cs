
using Sirenix.OdinInspector;
using UnityEngine;


public class Gamecontroller : MonoBehaviour
{
    [Required]
    public GameData gameData;
    
    private void Awake()
    {
        Core.Game.LoadGameData(gameData);
        Debug.Log("GameData Cargado.");
        Core.Game.StartGame();
    }
}
