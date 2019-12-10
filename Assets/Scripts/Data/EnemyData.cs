using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = ("Data/Enemy"))]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float moveSpeed;
    public int health;
    public int damage;

}