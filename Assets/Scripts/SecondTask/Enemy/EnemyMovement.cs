using UnityEngine;

namespace SecondTask.Enemy
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class EnemyMovement: MonoBehaviour
    {
        [SerializeField] private Transform firstWaypoint;
        [SerializeField] private Transform secondWaypoint;

        [SerializeField] private float speed;

        [SerializeField] private bool moveRight;
        
        private SpriteRenderer _renderer;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.position.x <= firstWaypoint.position.x && !moveRight ||
                 secondWaypoint.position.x <= _rigidbody.position.x && moveRight)
            {
                moveRight = !moveRight;
            }
            // Вызывается каждый, потому что
            // 1) Игрок может его сдвинуть
            // 2) Изменение значения в runtime
            Move();
        }

        private void Move()
        {
            var velocity = _rigidbody.velocity;
            velocity.x = (moveRight ? Vector2.right.x : Vector2.left.x) * speed;
            
            _renderer.flipX = !moveRight;
            _rigidbody.velocity = velocity;
        }
    }
}