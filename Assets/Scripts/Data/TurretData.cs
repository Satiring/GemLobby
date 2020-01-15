using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = ("Data/Turret"))]
public class TurretData : ScriptableObject
{
    public GameObject bulletPrefab;
    
    [Range(0, 10)] 
    public float speed;
    
    [Range(0f,20f)]
    public float detectRadius = 1f;

    [Range(0.001f, 2f)] public float delayBetweenShoots = 1f;
}
