﻿using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using DG.Tweening.Core.Easing;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(Animator),typeof(BoxCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] [Range(0, 3f)] float movementSpeed = 2f;

    // Cache Reference
    private Rigidbody2D _rb2D;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;
    private CircleCollider2D _circleCollider;
    private bool isDead;
    private int totalGems;
    
    private float _radius;
    
    private WeaponHandler _weaponHandler;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _weaponHandler = GetComponentInChildren<WeaponHandler>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
        Core.Data.Set(this,"player");
        totalGems = 0;
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            _animator.SetBool("isDead", true);
            StartCoroutine(FlashSprite());
            ProCamera2DShake.Instance.Shake("Basic");
            Destroy(this.gameObject, 5f);
            isDead = true;
            _weaponHandler.setWeaponActive(!isDead);
        }
        else
        {
            IRecolectable gem = other.gameObject.GetComponent<IRecolectable>();

            if (gem !=null)
            {
                totalGems++;
                gem.PickUp();
                Destroy(other.gameObject,0.1f);
            }
                
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isDead)
        {
            MovementProcess();    
        }
        
        
    }

    private void MovementProcess()
    {
        float inputX = Core.InputService.GetXAxisValue();
        float inputY = Core.InputService.GetYAxisValue();
        Vector3 actualPosition = transform.position;
        if (inputX != 0f || inputY != 0f)
        {
            // Hay movimiento
            _animator.SetBool("isMoving",true);
            var direction = new Vector2(inputX, inputY);
            Vector2 nextPosition = GetNextStep(direction, actualPosition);
            transform.position = new Vector3(nextPosition.x,nextPosition.y, actualPosition.z);;
        }
        else
        {
            _animator.SetBool("isMoving",false);    
        }
        
        if (!_weaponHandler.isRightFaced())
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
        
    }

    private Vector2 GetNextStep(Vector2 direction, Vector2 actualPosition)
    {
        Vector2 nextStep = new Vector2();
        nextStep = actualPosition + (direction * movementSpeed * Time.deltaTime);
        return nextStep;
    }
    
    private IEnumerator FlashSprite()
    {
        _spriteRenderer.material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.25f);
        _spriteRenderer.material.SetFloat("_FlashAmount", 0);
    }

    public int GetTotalGems()
    {
        return totalGems;
    }
    
}
