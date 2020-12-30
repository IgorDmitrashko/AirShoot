using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Action Rejoice;
    public float _speed;

    [SerializeField] private EnemyСharacteristics _enemyСharacteristics;
    private Transform _target;  
    private Vector3 _moveOnlyX;
    private Ball ball;

    void Start() {
        _target = GameObject.FindGameObjectWithTag("Ball").GetComponent<Transform>();
        _moveOnlyX = transform.position;
        _speed = _enemyСharacteristics.moovementSpeed;
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.tag == "Ball")
        {
            ball = collision.collider.gameObject.GetComponent<Ball>();
            if(ball != null)
            {
                Rejoice?.Invoke();
                ball.DefaultPossition();
            }
        }
    }   

    void Update() {
        if(_target != null)
        {
            _moveOnlyX.x = _target.position.x;
            transform.position = Vector3.MoveTowards(transform.position, _moveOnlyX, _speed * Time.deltaTime);
        }
    }
}
