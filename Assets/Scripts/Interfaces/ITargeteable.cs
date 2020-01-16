using UnityEngine;

public interface ITargeteable
{
    GameObject GetTarget();
    void SetTurret(TurretController turret);
}