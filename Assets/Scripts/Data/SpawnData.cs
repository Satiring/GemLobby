using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/Spawn"))]
public class SpawnData : ScriptableObject
{
    public string poolName;
    public List<GameObject> spawnItems;
    public float spawnRate;
    public int spawnItemsTotal;
    public int spawnNumber;
    
    
    // Sequence Spawn Options
    [Range(0f,5f)]
    public float sequenceItemsIncrements;

    [Range(0f,10f)]
    public float sequenceRateIncrement;
}