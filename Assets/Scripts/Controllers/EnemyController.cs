using System.Collections;
using DG.Tweening;
using Ju;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class EnemyController : MonoBehaviour, IDamageable, ISpawneable, ITargeteable
{
    // Cache Reference
    [ShowInInspector]
    private Transform _target;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _collider2D;
    

    // Data Info
    [Required]
    public EnemyData enemyData;

    // Class Vars
    private int actual_health;
    [ShowInInspector]
    private bool isMoving,isDead;

    private void Start()
    {
        isMoving = true;
        isDead = false;
        actual_health = enemyData.health;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator.SetBool("isMoving", true);
        _collider2D = GetComponent<CircleCollider2D>();
        AddToPool();
    }

    private void AddToPool()
    {
        // añade a la poool
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
        if (!isDead && isMoving && _target != null)
        {
            //move towards the Target
            Vector3 actualPosition = transform.position;
            Vector2 direction = _target.position - actualPosition;
            Vector2 nextPosition = Tools.GetNextStep(direction, actualPosition, enemyData.moveSpeed);
            transform.position = new Vector3(nextPosition.x, nextPosition.y, actualPosition.z);
        }
    }
    
    
    private void ProcessDeath()
    {
        isEnemyDead(true);
        _collider2D.enabled = false;
        Destroy(this.gameObject, 0.3f);
    }

    public void ProcessHit(int damage)
    {
        StartCoroutine(FlashSprite());
        actual_health -= damage;
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

    private IEnumerator FlashSprite()
    {
        isEnemyMoving(false);
        _spriteRenderer.material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.2f);
        _spriteRenderer.material.SetFloat("_FlashAmount", 0);
        isEnemyMoving(true);
    }

    public void Activate()
    {
        Vector2 actualPosition = transform.position;
        var nextPosition = Tools.GetPointOnRing(0, 1);
        var landPoint = actualPosition + (nextPosition);
        Tween land = transform.DOMove(
            landPoint, 0.5f, false);
        
        PlayerMovement player = Core.Data.Get<PlayerMovement>("player");
        if (player)
        {
            setTarget(player.transform);
        }
    }

    private void setTarget(Transform playerTransform)
    {
        _target = playerTransform;
        isMoving = true;
    }

    public Transform GetTarget()
    {
        return transform;
    }
}
