using System;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

namespace SecondTask.Player
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator))]
    public class PlayerMovement: MonoBehaviour
    {
        private static readonly int HorizontalMovement = Animator.StringToHash("HorizontalMovement");

        private Transform _transform;
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
            _transform = GetComponent<Transform>();
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
        }

        private void FixedUpdate()
        {
            MoveHorizontal(_velocity.x);
            
            if (_jumped)
            {
                Jump();
                _jumped = false;
            }
        }

        private void MoveHorizontal(float direction)
        {
            var y = _rigidbody.velocity.y;
            _rigidbody.velocity = new Vector2(direction * speed, y);
            
            var rotation = _transform.localRotation;
            rotation.y = direction switch
            {
                < 0 => 180f,
                > 0 => 0f,
                _ => rotation.y
            };
            
            _transform.localRotation = rotation;
            
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
        private PlayerMovement _playerMovement;

        protected PlayerState(PlayerMovement playerMovement)
        {
            _playerMovement = playerMovement;
        }
        
        public abstract void Update();
    }

    internal class WalkState : PlayerState
    {
        public WalkState(PlayerMovement playerMovement): base(playerMovement) {}

        public override void Update()
        {
            
        }
    }

    internal class JumpState: PlayerState
    {
        public JumpState(PlayerMovement playerMovement): base(playerMovement) {}
        
        public override void Update()
        {
            
        }
    }
}