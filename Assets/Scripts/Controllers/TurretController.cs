﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer),typeof(Animator))]
public class TurretController : MonoBehaviour
{
    private bool isDeploy;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private TurretHeadController _head;
    private ITargeteable _target;
    
    [Range(0, 10)] public float speed;




    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _head = GetComponentInChildren<TurretHeadController>();
        if (_head)
        {
            _head.gameObject.SetActive(false);
        }
        isDeployed(false);
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
        /*Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("AddDamage");
            i++;
        }*/
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
    }
    
    public void isDeployed(bool b)
    {
        isDeploy = b;
        _animator.SetBool("isDeployed",b);
    }
    
}
