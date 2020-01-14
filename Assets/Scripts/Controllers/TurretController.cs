using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;


[RequireComponent(typeof(SpriteRenderer),typeof(Animator))]
public class TurretController : MonoBehaviour
{
    [Range(0f,20f)]
    public float detectRadius = 1f;
    
    
    private bool isDeploy;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    public SpriteRenderer grabIcon;

    private CircleCollider2D _collider;
    
    private TurretHeadController _head;
    private ITargeteable _target;

    private bool isPlayerNear;
    
    [Range(0, 10)] public float speed;

    public void Awake()
    {
        GetComponent<CircleCollider2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _head = GetComponentInChildren<TurretHeadController>();
        _collider = GetComponent<CircleCollider2D>();
        if (_head)
        {
            _head.gameObject.SetActive(false);
        }
        isDeployed(false);
        isPlayerNear = false;
        grabIcon.enabled = false;
    }
    
    private void WeaponLookAtTarget()
    {
        Vector2 direction = _target.GetTarget().position - _head.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _head.transform.rotation = Quaternion.Slerp(_head.transform.rotation, rotation, speed * Time.deltaTime);
    }

    private void DetectTarget()
    {
        Collider2D[] ray = Physics2D.OverlapCircleAll(gameObject.transform.position,detectRadius);
        bool isWallorWater = false;
        
        foreach (var var in ray)
        {
            if (var.GetComponent<WallController>()||var.GetComponent<WaterController>())
            {
                isWallorWater = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDeploy)
        {
            if (_target != null)
            {
                WeaponLookAtTarget();
                
            }
            else
            {
                DetectTarget();
            }


            if (isPlayerNear)
            {
                grabIcon.enabled = true;
            }
            else
            {
                grabIcon.enabled = false;
            }
            
        }
        
        
    }

    // Animation Event Call
    public void ActivateTurret()
    {
        isDeployed(true);
        _head.gameObject.SetActive(true);
    }


    public void Activate()
    {
        
        _animator.SetTrigger("Deploy");
        _collider.enabled = true;
    }
    
    public void isDeployed(bool b)
    {
        isDeploy = b;
        _animator.SetBool("isDeployed",b);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            isPlayerNear = true;
            grabIcon.enabled = true;
            Log.Debug("Player Entrando");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            isPlayerNear = false;
            grabIcon.enabled = false;
            Log.Debug("Player Saliendo");
        }
    }
}
