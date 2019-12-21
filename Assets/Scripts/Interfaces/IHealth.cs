using System;

public interface IHealth
{
    void DoDamage(int damage);
    void Initialize(int maxHealth);
    void Restore();
    void AddHealth(int health);

    void SubscribeHealth(Action<int> action);

}