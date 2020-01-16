using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    [Required]
    public SpawnData spawnData;

    public int gemsToActivate = 0;
    public GameStateSharedData gameStateShared;
    
    public bool isTemporized = false; 
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
        if (isTemporized)
        {
            if (gameStateShared.gemsPicked >= gemsToActivate)
            {
                Activate();
                isTemporized = false;
            }
            else
            {
                isActive = false;
            }
        }
        else
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
       
    }
    

    private void Generate()
    {
        for (int e = 0; e < spawnData.spawnNumber; e++)
        {
            //GameObject gc = Core.Pool.GetObjectFromPool(spawnData.poolName, transform.position, Quaternion.identity);
            Instantiate(
                    spawnData.spawnItems[0], transform.position, Quaternion.identity).GetComponent<ISpawneable>().Activate();
            itemSpawned++;
        }
    }
    
    
}