using System;
using UnityEngine;

namespace SecondTask.Camera
{
    public class CameraMovement: MonoBehaviour
    {
        [SerializeField] private Rigidbody2D player;
        [SerializeField] private float lerp;
        
        private void Update()
        {
            var tr = transform.position;
            var move = Vector2.Lerp(tr, player.position, lerp);
            transform.position = new Vector3(move.x, move.y, tr.z);
        }
    }
}