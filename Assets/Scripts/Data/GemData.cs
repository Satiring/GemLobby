using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = ("Data/Gem"))]
public class GemData : ScriptableObject
{
    public Sprite gemSprite;
    public string gemName;
    
    [SerializeField][Range(1,25)]
    public int landingRadius;

    [SerializeField] [Range(1, 10)] public int maxLifeTime = 3;
    
    public float jumpPower;
    public float jumpDuration;
}