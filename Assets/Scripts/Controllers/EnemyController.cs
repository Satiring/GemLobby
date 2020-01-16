using System.Collections;
using DG.Tweening;
using Ju;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class EnemyController : MonoBehaviour, IDamageable, ISpawneable, ITargeteable, IDamageDealer
{
    // Cache Reference
    [ShowInInspector]
    private Transform _target;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _collider2D;

    private TurretController _turret;

    // Data Info
    // TODO Refactor Data Unification
    [Required]
    public EnemyData enemyData;

    // Class Vars
    private int actual_health;
    [ShowInInspector]
    private bool isMoving,isDead;

    private bool _isTargetNotNull;

    private void Start()
    {
        _isTargetNotNull = _target != null;
        isMoving = true;
        isDead = false;
        actual_health = enemyData.health;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.SetBool("isMoving", true);
        _collider2D = GetComponent<CircleCollider2D>();

    }

    void Update()
    {
        MoveEnemy();

        CheckLookDirection();
    }

    private void CheckLookDirection()
    {
        if (_target)
        {
            if (transform.position.x > _target.position.x)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
    }

    private void MoveEnemy()
    {
        if (!isDead && isMoving && _isTargetNotNull)
        {
            
            //move towards the Target
            isEnemyMoving(true);
            Vector3 actualPosition = transform.position;
            Vector2 direction = _target.position - actualPosition;
            Vector2 nextPosition = Tools.GetNextStep(direction, actualPosition, enemyData.moveSpeed);
            transform.position = new Vector3(nextPosition.x, nextPosition.y, actualPosition.z);
        }
    }
    
    
    private void ProcessDeath()
    {
        if (_turret != null)
        {
            Log.Debug("Aviso a la torreta de que busque nuevo objetivo.");
            _turret.TargetDown();
            
        }
            
        
        
        isEnemyDead(true);
        _collider2D.enabled = false;
        
        Destroy(gameObject, 0.3f);
        
    }

    public void ProcessHit(int damage)
    {
        actual_health -= damage;
        Tools.FlashSprite(_spriteRenderer);
        if (actual_health <= enemyData.health)
        {
            ProcessDeath();
        }
    }

    private void isEnemyMoving(bool b)
    {
        isMoving = b;
        _animator.SetBool("isMoving", b);
    }

    private void isEnemyDead(bool b)
    {
        isDead = b;
        _animator.SetBool("isDead", b);
    }

    public void Activate()
    {
        Vector2 actualPosition = transform.position;
        var nextPosition = Tools.GetPointOnRing(0, 1);
        var landPoint = actualPosition + (nextPosition);
        Tween land = transform.DOMove(
            landPoint, 0.5f, false);
        
        DetectTarget();
    }

    private void SetTarget(Transform playerTransform)
    {
        if (playerTransform != null)
        {
            _target = playerTransform;
            _isTargetNotNull = true;
            isMoving = true;
        }

    }

    private void DetectTarget()
    {
        
        // TODO REFACTOR COLMENA
        PlayerController player = Core.Data.Get<PlayerController>("player");
        if (player)
        {
            SetTarget(player.transform);
        }
    }
    
    
    public GameObject GetTarget()
    {
        return gameObject;
    }

    public void SetTurret(TurretController turret)
    {
        _turret = turret;
    }

    public int Damage()
    {
        return enemyData.damage;
    }
}
