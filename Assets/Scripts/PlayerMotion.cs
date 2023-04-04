using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mastered.Magisteros
{
    public class PlayerMotion : MonoBehaviour
    {
        [Header("Camera Look Variables")]
        [SerializeField] float lookSensitivity;
        [SerializeField] float minimumLookAngle, maximumLookAngle;
        Camera playerCamera;
        float mouseInputX, mouseInputY;

        [Header("Movement Variables")]
        [SerializeField] float gravityScale;
        [SerializeField] float walkSpeed, runSpeed;
        Vector3 gravityVector;
        CharacterController characterController;
        bool isRunning;

        [Header("Jump Variables")]
        [SerializeField] float jumpForce;

        // Start is called before the first frame update
        void Start()
        {
            playerCamera = gameObject.GetComponentInChildren<Camera>();
            characterController = GetComponent<CharacterController>();
            gravityVector = Physics.gravity;
        }

        // Update is called once per frame
        void Update()
        {
            CameraLook();
            Movement();
            JumpAndGravity();
        }

        void CameraLook()
        {
            Cursor.lockState = CursorLockMode.Locked;

            mouseInputX += Input.GetAxis("Mouse X") * lookSensitivity;
            mouseInputY += -Input.GetAxis("Mouse Y") * lookSensitivity;
            mouseInputY = Mathf.Clamp(mouseInputY, minimumLookAngle, maximumLookAngle);

            playerCamera.transform.localEulerAngles = new Vector3(mouseInputY, 0, 0);
            transform.eulerAngles = new Vector3(0, mouseInputX, 0);
        }

        void Movement()
        {
            Vector3 movementVector = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));
            isRunning = Input.GetButton("Run");

            characterController.Move((movementVector.normalized * (isRunning ? runSpeed : walkSpeed))* Time.deltaTime);
        }

        void JumpAndGravity()
        {

        }
    }
}

