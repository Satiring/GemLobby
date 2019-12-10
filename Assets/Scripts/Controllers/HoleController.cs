using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

[RequireComponent(typeof(BoxCollider2D),typeof(SpawnerComponent))]
public class HoleController : MonoBehaviour
{
    private BoxCollider2D _boxCollider2D;
    private SpawnerComponent _spawnerComponent; 

    // Start is called before the first frame update
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spawnerComponent = GetComponent<SpawnerComponent>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!_spawnerComponent.IsActive())
            _spawnerComponent.Activate();
    }

}    