using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    [Required]
    public SpawnData spawnData;

    public bool isLooped = false;
    
    private bool isActive;
    private bool isFinished;
    private int itemSpawned;
    private float elapsedTime; 
    

    public void Start()
    {
        isActive = false;
    }

    public bool IsActive()
    {
        return isActive;
    }

    
    public void Activate()
    {
        if (!isActive)
        {
            isActive = true;
            isFinished = false;
            itemSpawned = 0;
            elapsedTime = 0;
        }
    }
    
    
    public void DeActivate()
    {
        if (isActive)
        {
            isActive = false;
        }
    }

    public void Finish()
    {
        isFinished = true;
    }
    
    
    public void Update()
    {
        if (isActive&&!isFinished)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > spawnData.spawnRate)
            {
                elapsedTime = 0;
                Generate();
                if (!isLooped)
                {
                    isFinished = (itemSpawned > spawnData.spawnItemsTotal);
                }

            }
        }
    }
    

    private void Generate()
    {
        for (int e = 0; e < spawnData.spawnNumber; e++)
        {
                    
            Instantiate(
                    spawnData.spawnItems[Random.Range(0, spawnData.spawnItems.Count)]
                    , transform.position, Quaternion.identity)
                .GetComponent<ISpawneable>()
                .Activate();
            itemSpawned++;
        }
    }
    
    
}