﻿using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D),typeof(BulletMovementComponent),typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour, IDirigible
{
    [Required][SerializeField]
    private BulletData bulletData;
    private BoxCollider2D _collider2D;
    private Rigidbody2D _rb2d;


    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if(hit!=null){
        
            hit.ProcessHit(bulletData.damage);
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        WallController wallController = other.gameObject.GetComponent<WallController>();
        IDamageable hit = other.gameObject.GetComponent<IDamageable>();
        if (wallController)
        {
            if (bulletData.isBounce)
            {
                GetComponent<BulletMovementComponent>().Bounce(other);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }else if (hit != null)
        {
            hit.ProcessHit(bulletData.damage);
            Destroy(gameObject);
        }
       
    }

    public int GetDecrementtFactor()
    {
        return bulletData.bounceDecrementFactor;
    }

    public void SetDirection(Vector2 direction)
    {
        GetComponent<BulletMovementComponent>().InitiateMove(direction, bulletData.speed);
    }
    
    public float getBulletDamage()
    {
        return bulletData.damage;
    }

    public float getBulletSpeed()
    {
        return bulletData.speed;
    }
}
