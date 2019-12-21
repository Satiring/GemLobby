using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D),typeof(BulletController),typeof(BoxCollider2D))]
public class BulletMovementComponent : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private BoxCollider2D _boxCollider;
    private Vector2 _direction;
    private int counter;

    private float _speed;
    
   [ShowInInspectorAttribute]
   private bool isMoving; 
   
   
   
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        counter = 0;
    }

    public void InitiateMove(Vector2 dir, float speed)
    {
        _direction = dir;
        transform.rotation = Tools.getRotationToTarget(_direction);
        isMoving = true;
        _speed = speed;
    }


    public void FixedUpdate()
    {
        if (isMoving)
        {
            UpdatePosition();
        }   
            
    }

    private void UpdatePosition()
    {
        Vector2 position = transform.position;
        position += Time.deltaTime * _speed * _direction.normalized;
        _rb2d.MovePosition(position);
    }
    
    public void Bounce(Collision2D _collision)
    {
        var factor = GetComponent<BulletController>().GetDecrementtFactor();
        _direction = Vector2.Reflect(_direction, _collision.contacts[0].normal);
        transform.rotation = Tools.getRotationToTarget(_direction);
        counter++;
        if (counter > 3)
        {
            Destroy(gameObject);
        }
    }
    
}
