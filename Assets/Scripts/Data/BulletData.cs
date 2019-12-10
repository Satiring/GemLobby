using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = ("Data/Bullet"))]
public class BulletData : ScriptableObject
{
    public float speed;
    public Sprite bulletSprite;
    public int damage;
    public bool isBounce;
    [Range(1f,10f)]
    public int bounceDecrementFactor;
}