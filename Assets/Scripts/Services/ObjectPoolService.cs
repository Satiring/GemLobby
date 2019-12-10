using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolService : IObjectPoolService
{
    private Dictionary<string, Pool> poolDictionary = new Dictionary<string, Pool>();
    private PoolInfoData[] poolInfo;
    
    public void Setup()
    {
        Log.Debug( this.GetType().ToString() + " - Ejecuto el setup");
    }

    public void Start()
    {
        Log.Debug( this.GetType().ToString() + " - Ejecuto el Start");
        //check for duplicate names
        CheckForDuplicatePoolNames();
        
        // Set pools
        poolInfo = Core.Data.ListGet<PoolInfoData>().ToArray();
        
        //create pools
        CreatePools();
    }

    public GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation)
    {
        GameObject result = null;

        if (poolDictionary.ContainsKey(poolName))
        {
            Pool pool = poolDictionary[poolName];
            result = pool.NextAvailableObject(position, rotation);
            //scenario when no available object is found in pool
            if (result == null)
            {
                Debug.LogWarning("No object available in pool. Consider setting fixedSize to false.: " + poolName);
            }
        }
        else
        {
            Debug.LogError("Invalid pool name specified: " + poolName);
        }

        return result;
    }

    public void ReturnObjectToPool(GameObject go)
    {
        PoolObject po = go.GetComponent<PoolObject>();
        if (po == null)
        {
            Debug.LogWarning("Specified object is not a pooled instance: " + go.name);
        }
        else
        {
            if (poolDictionary.ContainsKey(po.poolName))
            {
                Pool pool = poolDictionary[po.poolName];
                pool.ReturnObjectToPool(po);
            }
            else
            {
                Debug.LogWarning("No pool available with name: " + po.poolName);
            }
        }
    }
    
    
    private void CheckForDuplicatePoolNames()
    {
        for (int index = 0; index < poolInfo.Length; index++)
        {
            string poolName = poolInfo[index].poolName;
            if (poolName.Length == 0)
            {
                Debug.LogError(string.Format("Pool {0} does not have a name!", index));
            }

            for (int internalIndex = index + 1; internalIndex < poolInfo.Length; internalIndex++)
            {
                if (poolName.Equals(poolInfo[internalIndex].poolName))
                {
                    Debug.LogError(string.Format("Pool {0} & {1} have the same name. Assign different names.", index,
                        internalIndex));
                }
            }
        }
    }
    
    private void CreatePools()
    {
        foreach (PoolInfoData currentPoolInfo in poolInfo)
        {
            Pool pool = new Pool(currentPoolInfo.poolName, currentPoolInfo.prefab,
                currentPoolInfo.poolSize, currentPoolInfo.fixedSize);


            Debug.Log("Creating pool: " + currentPoolInfo.poolName);
            //add to mapping dict
            poolDictionary[currentPoolInfo.poolName] = pool;
        }
    }
    
}