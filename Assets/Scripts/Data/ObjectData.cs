using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = ("Data/Destructible Object"))]
public class ObjectData : ScriptableObject
{
    public int healthPoint;
    public Sprite objectSprite;
}