using UnityEngine;

namespace SecondTask.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement: MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        [SerializeField] private KeyCode right;
        [SerializeField] private KeyCode left;
        [SerializeField] private KeyCode jump;

        [SerializeField] private float speed;
        [SerializeField] private float jumpVelocity;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void FixedUpdate()
        {
            var velocity = new Vector2(0, 0);
            
            if (Input.GetKey(right))
            {
                velocity += Vector2.right;
            }

            if (Input.GetKey(left))
            {
                velocity += Vector2.left;
            }

            if (Input.GetKey(jump))
            {
                velocity += Vector2.up;
            }

            MoveHorizontal(velocity.x * (speed * Time.deltaTime));
            Jump(velocity.y * (jumpVelocity * Time.deltaTime));
        }

        private void MoveHorizontal(float velocity)
        {
            var oldVelocity = _rigidbody2D.velocity;
            _rigidbody2D.velocity = new Vector2(velocity, oldVelocity.y);
        }

        private void Jump(float velocity)
        {
            var oldVelocity = _rigidbody2D.velocity;
            _rigidbody2D.velocity = new Vector2(oldVelocity.x, velocity);
        }
    }
}