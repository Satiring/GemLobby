using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = ("Data/Config/Flocking"))]
public class FlockingData : ScriptableObject
{
    [Range(1, 10)] public float neighborhoodRadius = 3f;
        
    [Range(0, 10)] public float maxSpeed = 1f;

    [Range(.1f, .5f)] public float maxForce = .03f;
}