using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Arrow arrow;
    public Action HitTheBlock;

    private Vector3 _direction;
    private Vector3 _startPossitionBall;

    private Rigidbody _rigidbody;
    private float _speed = 2;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();      
    }

    private void Start() {
        arrow.ReadyShoot += CourseBoll;
        _startPossitionBall = transform.position;
    }

    void Update() {
        Shoot();
        if(gameObject.transform.position.z <= 1)
        {
            DefaultPossition();
        }
    }

    private void CourseBoll(Vector3 course, float powerShoot) {
        _speed = powerShoot;
        _direction = course;
    }

    public void DefaultPossition() {
        transform.position = _startPossitionBall;
        _direction = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.identity;
    }

    private void Shoot() {
        _rigidbody.velocity = _direction.normalized * _speed;
    }

    
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.CompareTag("Border")) _direction.x = -_direction.x;

        else if(collision.collider.CompareTag("TopBorder")) _direction.z = -_direction.z;

        else if(collision.collider.CompareTag("Block"))
        {
            HitTheBlock?.Invoke();
            DefaultPossition();
        }
    }
}
