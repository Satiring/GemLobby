using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using DG.Tweening.Core.Easing;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class MovementComponent : MonoBehaviour
{
    // Cache Reference
    private PlayerController _player;

    private void Awake()
    {
        _player = GetComponent<PlayerController>();
    }


    public void move(float inputX, float inputY, float speed)
    {
        Vector3 actualPosition = transform.position;
        // Hay movimiento
        var direction = new Vector2(inputX, inputY);
        Vector2 nextPosition = Tools.GetNextStep(direction, actualPosition, speed);
        transform.position = new Vector3(nextPosition.x, nextPosition.y, actualPosition.z);
        
    }
}