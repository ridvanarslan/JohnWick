using UnityEngine;

namespace Player
{
    public class PlayerLookController : MonoBehaviour
    {
        [SerializeField] private float mouseSensivity = 100f;
        [SerializeField] private Transform characterBody;

        private float _xRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        private void LateUpdate()
        {
            Look();
        }


        private void Look()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -35, 35);
            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            characterBody.Rotate(Vector3.up * mouseX);
        }
    }
}
