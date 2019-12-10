using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHeadController : MonoBehaviour
{
    public SpriteRenderer _turretHeadSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        _turretHeadSprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void FlipSprite(bool b)
    {
        _turretHeadSprite.flipY = b;
    }
    
    
}
