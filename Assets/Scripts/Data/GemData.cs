using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = ("Data/Gem"))]
public class GemData : ScriptableObject
{
    public Sprite gemSprite;
    public string gemName;
    
    [SerializeField][Range(1,25)]
    public int landingRadius;

    public float jumpPower;
    public float jumpDuration;
}