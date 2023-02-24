using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace SecondTask.Player
{
    [RequireComponent(
         typeof(SpriteRenderer), 
         typeof(Rigidbody2D), 
         typeof(Animator))]
    public class PlayerMovement: MonoBehaviour
    {
        private static readonly int HorizontalMovement = Animator.StringToHash("HorizontalMovement");
        private static readonly int VerticalMovement = Animator.StringToHash("VerticalMovement");
        private static readonly int Jumped = Animator.StringToHash("Jumped");

        private const float Eps = 2f;

        private SpriteRenderer _renderer;
        private Rigidbody2D _rigidbody;
        private Animator _animator;

        [SerializeField] private KeyCode leftKey;
        [SerializeField] private KeyCode rightKey;
        [SerializeField] private KeyCode jumpKey;

        [SerializeField] private float speed;

        [SerializeField] private float jumpTiles;
        
        private bool _jumped;
        
        private readonly Vector2[] _velocities = {Vector2.zero, Vector2.zero};
        

        private Vector2 _velocity => _velocities[0];

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _velocities[1] = Vector2.zero;

            if (Input.GetKey(leftKey))
            {
                _velocities[1] += Vector2.left;
            }
            else if (Input.GetKey(rightKey))
            {
                _velocities[1] += Vector2.right;
            }

            if (Input.GetKeyDown(jumpKey))
            {
                _jumped = true;
            }

            _velocities[0] = _velocities[1];
            
            _animator.SetFloat(VerticalMovement, _rigidbody.velocity.y);
        }

        private void FixedUpdate()
        {
            MoveHorizontal(_velocity.x);
            
            if (_jumped)
            {
                Jump();
                _animator.SetBool(Jumped, true);
                _jumped = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (Mathf.Abs(_rigidbody.velocity.y) < Eps)
            {
                _animator.SetBool(Jumped, false);
            }
        }

        private void MoveHorizontal(float direction)
        {
            var y = _rigidbody.velocity.y;
            _rigidbody.velocity = new Vector2(direction * speed, y);

            _renderer.flipX = direction < 0;

            _animator.SetBool(HorizontalMovement, direction != 0);
        }

        private void Jump()
        {
            var x = _rigidbody.velocity.x;
            var jumpVelocity = Mathf.Sqrt(
                2 * jumpTiles * Mathf.Abs(Physics2D.gravity.y) * _rigidbody.gravityScale);
            _rigidbody.velocity = new Vector2(x, jumpVelocity);
        }
    }

    internal abstract class PlayerState
    {
        private Animator _animator;
        private Rigidbody2D _rigidbody;
        private Renderer _renderer;
        
        private PlayerMovement _movement;
        
        
        protected PlayerState(PlayerMovement movement)
        {
            _movement = movement;
        }
        
        public abstract void Update();
    }

    internal class WalkState : PlayerState
    {
        public WalkState(PlayerMovement movement): base(movement) {}

        public override void Update()
        {
            
        }
    }

    internal class JumpState: PlayerState
    {
        public JumpState(PlayerMovement movement): base(movement) {}
        
        public override void Update()
        {
            
        }
    }
}