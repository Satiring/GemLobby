using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(Animator),typeof(BoxCollider2D))]
public class ObjectController : MonoBehaviour, IDamageable
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private BoxCollider2D _collider2D;
    [SerializeField] private ObjectData _objectData;
    private int actual_health;
    private bool isActive;

    private void Start()
    {
        actual_health = _objectData.healthPoint;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _objectData.objectSprite;
        _collider2D = GetComponent<BoxCollider2D>();
        _collider2D.enabled = true;
        isActive = true;
    }
    

    public void ProcessHit(int damage)
    {
        StartCoroutine(FlashSprite());
        if (isActive)
        {
            ReceiveDamage(damage); 
        }
        
    }

    private void ReceiveDamage(int damage)
    {
        actual_health -= damage;
        if (actual_health <= 0)
        {
            _collider2D.enabled = false;
            ProcessDestroy();
            isActive = false;
        }
    }

    private void ProcessDestroy()
    {
        _animator.SetTrigger("isDestroy");
        Destroy(this.gameObject,0.3f);
    }
    

    private IEnumerator FlashSprite()
    {
        _spriteRenderer.material.SetFloat("_FlashAmount", 1);
        yield return new WaitForSeconds(0.1f);
        _spriteRenderer.material.SetFloat("_FlashAmount", 0);
    }
}