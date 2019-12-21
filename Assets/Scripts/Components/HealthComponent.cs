using System;
using Ju;
using UnityEngine;

class HealthComponent : Component, IHealth
{
    private int _maxHealth;

    private Observable<int> _actualHealth;

    public void DoDamage(int damage)
    {
        _actualHealth.Value -= damage;
    }

    public void Initialize(int maxHealth)
    {
        _maxHealth = maxHealth;
        _actualHealth = new Observable<int>(maxHealth);
    }
    
    public void Restore()
    {
        _actualHealth.Value = _maxHealth;
    }

    public void AddHealth(int health)
    {
        _actualHealth.Value += health;
    }

    public void SubscribeHealth(Action<int> action)
    {
        _actualHealth.Subscribe(action);
    }
}