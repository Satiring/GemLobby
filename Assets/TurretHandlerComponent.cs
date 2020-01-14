using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TurretHandlerComponent : MonoBehaviour
{

    public GameObject AttackTurretPrefab;
    private GameObject Turret;
    private bool isDesployAllowedInPosition = false;
    private TweenCallback landFinish;
    
    
    public void Deploy(Vector2 _transform)
    {
        StartCoroutine(LaunchTorret(_transform));
    }

    private IEnumerator LaunchTorret(Vector2 _transform)
    {
        if (Turret == null)
        {
            CheckWall(_transform);
            if (isDesployAllowedInPosition)
            {
                Turret = Instantiate(AttackTurretPrefab, gameObject.transform.position, Quaternion.identity);
                Tween land = Turret.transform.DOJump(
                    _transform, 2, 0, 1, false);
                yield return land.WaitForCompletion();
                Turret.GetComponent<TurretController>().Activate();
            }
        }
        
    }

    private void CheckWall(Vector2 _transform)
    {
        Collider2D[] ray = Physics2D.OverlapCircleAll(_transform,1f);
        bool isWallorWater = false;
        
        foreach (var var in ray)
        {
            if (var.GetComponent<WallController>()||var.GetComponent<WaterController>())
            {
                isWallorWater = true;
            }
        }

        if (!isWallorWater)
        {
            isDesployAllowedInPosition = true;
        }
        else
        {
            isDesployAllowedInPosition = false;
        }
    }
}
