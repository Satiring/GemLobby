using Ju;
using UnityEngine;

public interface IObjectPoolService : IService
{
    GameObject GetObjectFromPool(string poolName, Vector3 position, Quaternion rotation);
    void ReturnObjectToPool(GameObject go);
}
