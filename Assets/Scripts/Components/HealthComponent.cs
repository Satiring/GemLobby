using System;
using Ju;
using UnityEngine;

class HealthComponent : Component, IHealth
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

    public void SubscribeHealth(Action<int> action)
    {
        //_actualHealth.Subscribe(action);
    }
}