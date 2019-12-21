using UnityEngine;

[CreateAssetMenu(menuName = "Player/Prefab Data")]
public class PlayerData : ScriptableObject
{
    
    [Range(0, 3f)] public float movementSpeed = 2f;
    [Range(10, 50f)] public int maxHealth = 10;
    
}