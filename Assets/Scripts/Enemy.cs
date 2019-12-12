using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    void OnAwake();
    bool IsActive();
    void Activate();
    void Deactivate();
    void SetUp(Vector2 position, Quaternion rotation);
    Vector2 GetPosition();
    void SetTarget(Transform target);
}
