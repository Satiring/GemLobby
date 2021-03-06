﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator),typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    // TODO - Factory Task
    public PlayerData _playerData;
    public GameStateSharedData GameStateShared;
    
    // Cache Reference
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    // Private Components
    private MovementComponent _movementComponent;
    public HealthSharedData _healthPlayerShared;
    private WeaponHandlerComponent _weaponHandler;
    private TurretHandlerComponent _turretHandler;
    
    // Private References
        private int _actualHealth;
        
        
        // TODO - Implement with States
        private bool isDead = false;
        private bool isMoving = false;
    
    
    // COlliders
    private BoxCollider2D _boxCollider;
    private CircleCollider2D _circleCollider;
    


    // Start is called before the first frame update
    void Start()
    {
        
        // Set References
            // CACHE
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            
            // PRIVATE
            _weaponHandler = GetComponentInChildren<WeaponHandlerComponent>();
            _movementComponent = GetComponent<MovementComponent>();
            _turretHandler = GetComponent<TurretHandlerComponent>();
            
            
            InitializeHealth();


            // COLLIDERS
            _boxCollider = GetComponent<BoxCollider2D>();
            _circleCollider = GetComponent<CircleCollider2D>();



            // TODO - Factory Task
            Core.Data.Set(this,"player");
            //Core.Camera.AddTarget(transform);
            
            
        // Default
        isDead = false;
        isMoving = false;
        
        
    }

    public void InitializeHealth()
    {
        // Health Component

        _healthPlayerShared.Initialize(_playerData.maxHealth);
    }

    public int GetActualHealth()
    {
        return _healthPlayerShared.GetHealth();   
    }
    
    private void CheckLife()
    {
        if (_healthPlayerShared.GetHealth() <= 0)
            {
                PlayerDead();
            }

    }

    private void PlayerDead()
    {
        _boxCollider.enabled = false;
        Core.Camera.Shake("Basic");
        isDead = true;
        _weaponHandler.setWeaponActive(!isDead);
        _animator.SetBool("isDead", true);
        StartCoroutine(Tools.FlashSprite(_spriteRenderer));
        Destroy(this.gameObject, 5f);
        Core.Game.FinishGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            CheckLife();
            // TODO Refactor Input Manager
            float inputX = Core.InputService.GetXAxisValue();
            float inputY = Core.InputService.GetYAxisValue();
            if (inputX != 0 || inputY != 0)
            {
                if (!isMoving)
                {
                    isMoving = true;
                    _animator.SetBool("isMoving",true);
                }
                _movementComponent.move(inputX, inputY,_playerData.movementSpeed);
            }
            else
            {
                isMoving = false;
                _animator.SetBool("isMoving",false);
            }

            
            if (Core.InputService.IsDeployedPress())
            {
                Vector2 Direction = _weaponHandler.GetCrosshairPosition();
                _turretHandler.Deploy(Direction);
            }
            
            if (Core.InputService.isGrabPress())
            {
                Tools.FlashSprite(_turretHandler.Turret.GetComponent<SpriteRenderer>());
                DeleteTurret();
            }
            ChangeSpriteDirection();
            
            if (GameStateShared)
            {
                if (GameStateShared.gemsPicked >= 100)
                {
                
                    Core.Game.FinishGame();
                }    
            }
            
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        IRecolectable pickable = other.gameObject.GetComponent<IRecolectable>();
        if(pickable != null)
        {

                pickable.PickUp();
                GameStateShared.gemsPicked++;

        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        IDamageDealer DamageDealer = other.gameObject.GetComponent<IDamageDealer>();
        if (DamageDealer != null)
        {
            if (other.gameObject.GetComponent<EnemyController>() != null)
            {
                Tools.FlashSprite(_spriteRenderer);
                _healthPlayerShared.DoDamage(DamageDealer.Damage());
            }
            
        }
    }

    public void DeleteTurret()
    {
        Destroy(_turretHandler.Turret,0.3f);
        Core.UIService.IsTurretAvailable();
    }
    
    
    private void ChangeSpriteDirection()
    {
        if (!_weaponHandler.isRightFaced())
        {
            _spriteRenderer.flipX = true;
            _weaponHandler.setFlipY(true);
        }
        else
        {
            _spriteRenderer.flipX = false;
            _weaponHandler.setFlipY(false);
        }
    }
}
