using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlockingComponent : MonoBehaviour
{
    // SRC: https://github.com/RafaelKuebler/Flocking
    // Edited to deleted the rotation and added a Data for the config Vars

    public FlockingData flockingData;

    private bool isActive;


    [Range(0, 3)] public float separationAmount = 1f;

    [Range(0, 3)] public float cohesionAmount = 1f;

    [Range(0, 3)] public float alignmentAmount = 1f;

    private Vector2 _acceleration;
    private Vector2 _velocity;

    private Vector2 Position
    {
        get { return gameObject.transform.position; }
        set { gameObject.transform.position = value; }
    }

    private void Start()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        _velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        if (flockingData)
        {
            isActive = false;
        }
    }

    private void Update()
    {
        var boidColliders = Physics2D.OverlapCircleAll(Position, flockingData.neighborhoodRadius);
        var boids = boidColliders.Select(o => o.GetComponent<FlockingComponent>()).ToList();
        boids.Remove(this);

        Flock(boids);
        UpdateVelocity();
        UpdatePosition();
        WrapAround();
    }

    private void Flock(IEnumerable<FlockingComponent> boids)
    {
        var alignment = Alignment(boids);
        var separation = Separation(boids);
        var cohesion = Cohesion(boids);

        _acceleration = alignmentAmount * alignment + cohesionAmount * cohesion + separationAmount * separation;
    }

    public void UpdateVelocity()
    {
        _velocity += _acceleration;
        _velocity = LimitMagnitude(_velocity, flockingData.maxSpeed);
    }

    private void UpdatePosition()
    {
        Position += _velocity * Time.deltaTime;
    }

    private Vector2 Alignment(IEnumerable<FlockingComponent> boids)
    {
        var velocity = Vector2.zero;
        if (!boids.Any()) return velocity;

        foreach (var boid in boids)
        {
            velocity += boid._velocity;
        }

        velocity /= boids.Count();

        var steer = Steer(velocity.normalized * flockingData.maxSpeed);
        return steer;
    }

    private Vector2 Cohesion(IEnumerable<FlockingComponent> boids)
    {
        if (!boids.Any()) return Vector2.zero;

        var sumPositions = Vector2.zero;
        foreach (var boid in boids)
        {
            sumPositions += boid.Position;
        }

        var average = sumPositions / boids.Count();
        var direction = average - Position;

        var steer = Steer(direction.normalized * flockingData.maxSpeed);
        return steer;
    }

    private Vector2 Separation(IEnumerable<FlockingComponent> boids)
    {
        var direction = Vector2.zero;
        boids = boids.Where(o => DistanceTo(o) <= flockingData.neighborhoodRadius / 2);
        if (!boids.Any()) return direction;

        foreach (var boid in boids)
        {
            var difference = Position - boid.Position;
            direction += difference.normalized / difference.magnitude;
        }

        direction /= boids.Count();

        var steer = Steer(direction.normalized * flockingData.maxSpeed);
        return steer;
    }

    private Vector2 Steer(Vector2 desired)
    {
        var steer = desired - _velocity;
        steer = LimitMagnitude(steer, flockingData.maxForce);

        return steer;
    }

    private float DistanceTo(FlockingComponent boid)
    {
        return Vector3.Distance(boid.transform.position, Position);
    }

    private Vector2 LimitMagnitude(Vector2 baseVector, float maxMagnitude)
    {
        if (baseVector.sqrMagnitude > maxMagnitude * maxMagnitude)
        {
            baseVector = baseVector.normalized * maxMagnitude;
        }

        return baseVector;
    }

    private void WrapAround()
    {
        if (Position.x < -14) Position = new Vector2(14, Position.y);
        if (Position.y < -8) Position = new Vector2(Position.x, 8);
        if (Position.x > 14) Position = new Vector2(-14, Position.y);
        if (Position.y > 8) Position = new Vector2(Position.x, -8);
    }
}