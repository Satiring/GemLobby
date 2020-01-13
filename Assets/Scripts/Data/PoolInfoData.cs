using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Data/PoolInfo")]
public class PoolInfoData : ScriptableObject
{
    public string poolName;
    public GameObject prefab;
    public int poolSize;
    public bool fixedSize;
}