using System;
using System.Collections;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer),typeof(Animator),typeof(Rigidbody2D))]
public class GemController : MonoBehaviour, ISpawneable, IRecolectable
{
    [SerializeField][Required]
    public GemData gemdata;
    
    
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;

    public AudioClip gemSoundPickup;

    private float timeLeft;
    

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = gemdata.gemSprite;
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _boxCollider2D.enabled = false;
        timeLeft = gemdata.jumpDuration;
    }

    private void Update()
    {
        Debug.Log("TimeLeft: " + timeLeft);
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            Log.Debug("Gema Activada");
            _boxCollider2D.enabled = true;
        }
    }

    public void Activate()
    {
        Vector2 actualPosition = transform.position;
        var nextPosition = Tools.GetPointOnRing(2,gemdata.landingRadius);
        var landPoint = actualPosition + (nextPosition);
        Tween land = transform.DOJump(
            landPoint, gemdata.jumpPower, 0, gemdata.jumpDuration, false);
        Destroy(gameObject, gemdata.maxLifeTime);
    }

    public void PickUp()
    {
        _spriteRenderer.material.SetFloat("_FlashAmount", 1);
        transform.DOScale(2f, 0.2f);
        Core.Fx.Play(gemSoundPickup);
        Destroy(gameObject,0.3f);
    }
}
