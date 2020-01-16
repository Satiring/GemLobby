using System;
using Ju;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/SharedHealth")]
public class HealthSharedData : ScriptableObject, IHealth
{
    private int _maxHealth;

    private int _actualHealth;

    public void DoDamage(int damage)
    {
        _actualHealth -= damage;
    }

    public void Initialize(int maxHealth)
    {
        _maxHealth = maxHealth;
        _actualHealth = maxHealth;
    }
    
    public void Restore()
    {
        _actualHealth = _maxHealth;
    }

    public void AddHealth(int health)
    {
        _actualHealth += health;
    }

    public int GetHealth()
    {
        return _actualHealth;
    }
    
}