using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Diagnostics;


[RequireComponent(typeof(SpriteRenderer),typeof(Animator))]
public class TurretController : MonoBehaviour
{

    // Config Data // Public
    [Required]
    public TurretData _data;
    
    // Cache Reference
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private CircleCollider2D _collider;
    
    
    // Parts Components
    public SpriteRenderer grabIcon;
    [Required]
    public Transform shootTransform;
    private TurretHeadController _head;
    
    
    
    // Useful
    private bool isDeploy;
    private bool isPlayerNear;
    private ITargeteable _target;
    private float delay;


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
        delay = _data.delayBetweenShoots;
    }
    
    private void WeaponLookAtTarget()
    {
        Vector2 direction = _target.GetTarget().position - _head.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            _head.transform.rotation = Quaternion.Slerp(_head.transform.rotation, rotation, _data.speed * Time.deltaTime);
    }

    private void ShootToTarget()
    {
        Vector2 direction = _target.GetTarget().position - transform.position;
        IDirigible bullet = (Instantiate(_data.bulletPrefab, shootTransform.position, Quaternion.identity)).GetComponent<IDirigible>();
        bullet.SetDirection(direction);
    }
    
    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _data.detectRadius);
    }
    
    private void DetectTarget()
    {
        Debug.Log("Detectando Objetivos");
        Collider2D[] ray = Physics2D.OverlapCircleAll(gameObject.transform.position,_data.detectRadius);
        ITargeteable targetSelected = null;
        float minDistance = 9999999999f;
        
        foreach (var var in ray)
        {
            ITargeteable targetAux = var.GetComponent<ITargeteable>();
            if (targetAux!=null)
            {
                float distance = Vector3.Distance (transform.position, targetAux.GetTarget().position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    targetSelected = targetAux;
                }
            }
        }

        _target = targetSelected;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDeploy)
        {
            if (_target != null)
            {
                WeaponLookAtTarget();
                delay -= Time.deltaTime;
                if (delay <= 0)
                {
                    ShootToTarget();
                    delay = _data.delayBetweenShoots;
                }                                    
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            isPlayerNear = false;
            grabIcon.enabled = false;
        }
    }
}
