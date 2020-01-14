using System;
using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using Com.LuisPedroFonseca.ProCamera2D.TopDownShooter;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Animations;

public class WeaponHandlerComponent : MonoBehaviour
{
    [Range(0, 10)] public float speed;
    
    [SerializeField]
    private GameObject _crosshair;
    
    [SerializeField]
    private WeaponData actualWeapon;

    [SerializeField]
    private GameObject _pivot;

    [SerializeField]
    private Transform _initialPoint;

    [SerializeField]
    private GameObject WeaponHolder;

    [ShowInInspector]
    private bool isActive = true;

    private bool isRightFace;
    private SpriteRenderer sprite;


    private void Awake()
    {
        sprite = WeaponHolder.GetComponent<SpriteRenderer>();
    }

    public void Shoot()
    {
        Vector2 direction = _crosshair.transform.position - transform.position;
        if (actualWeapon != null)
        {
            IDirigible bullet = (Instantiate(actualWeapon.bulletPrefab, _initialPoint.position, Quaternion.identity)).GetComponent<IDirigible>();
            bullet.SetDirection(direction);
            
            
            // TODO
            // Core.Camera.Shake(actualWeapon.preset);
            ProCamera2DShake.Instance.Shake("PistolBullet");
        }
    }

    public void setFlipY(bool flipY)
    {
        if (sprite)
        {
            sprite.flipY = flipY;
        }
            
    }


    void Update()
    {
        if (isActive)
        {
            WeaponLookAtCrosshair();
            if (Core.InputService.IsShootPress())
            {
                Shoot();
            }
        }
    }

    private void WeaponLookAtCrosshair()
    {

        
        Vector2 direction = _crosshair.transform.position - WeaponHolder.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        

        
        WeaponHolder.transform.rotation = Quaternion.Slerp(WeaponHolder.transform.rotation, rotation, speed * Time.deltaTime);
    }

    public void setWeaponActive(bool b)
    {
        isActive = b;
    }


    public Vector2 GetCrosshairPosition()
    {
        return _crosshair.transform.position;
    }
    
    public bool isRightFaced()
    {
        return (_crosshair.gameObject.transform.position.x > _pivot.gameObject.transform.position.x);
    }
}