using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 2.0f;
        [SerializeField] private float jumpHeight = 1.0f;
        [SerializeField] private float gravityValue = -9.81f;
        [SerializeField] private bool groundedPlayer;

        private Vector3 _playerVelocity;
        private CharacterController _controller;
        
        private void Awake()
        {
            _controller = gameObject.GetComponent<CharacterController>();
        }

        void Update()
        {
            groundedPlayer = _controller.isGrounded;
            
            if (groundedPlayer && _playerVelocity.y < 0)
            {
                _playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            
            move = transform.TransformDirection(move);
           
            _controller.Move(move * Time.deltaTime * playerSpeed);
           

            if (Input.GetButtonDown("Jump") && groundedPlayer)
            {
                _playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            }

            _playerVelocity.y += gravityValue * Time.deltaTime;
            _controller.Move(_playerVelocity * Time.deltaTime);
        }
    }
}
