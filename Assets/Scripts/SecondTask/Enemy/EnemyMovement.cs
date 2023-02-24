using System;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace SecondTask.Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class EnemyMovement: MonoBehaviour
    {
        [SerializeField] private Transform firstWaypoint;
        [SerializeField] private Transform secondWaypoint;

        [SerializeField] private float speed;

        private SpriteRenderer _renderer;
        private Rigidbody2D _rigidbody;

        [SerializeField] private bool _moveRight;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.position.x <= firstWaypoint.position.x && !_moveRight ||
                 secondWaypoint.position.x <= _rigidbody.position.x && _moveRight)
            {
                _moveRight = !_moveRight;
            }
            Move();
        }

        private void Move()
        {
            var velocity = _rigidbody.velocity;
            velocity.x = (_moveRight ? Vector2.right.x : Vector2.left.x) * speed;
            
            _renderer.flipX = !_moveRight;
            _rigidbody.velocity = velocity;
        }
    }
}