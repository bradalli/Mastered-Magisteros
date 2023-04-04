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
        [SerializeField] float walkSpeed;
        [SerializeField] float runSpeed;
        Vector3 gravityVector;
        CharacterController characterController;
        bool isRunning;

        [Header("Jump and Gravity Variables")]
        [SerializeField] float gravityScale;
        [SerializeField] float jumpForce;
        Vector3 playerYVelocity;

        [Header("Camera Raycast Variables")]
        [SerializeField] float raycastDistance;
        [SerializeField] LayerMask raycastLayerMask;
        RaycastHit raycastHitResult;

        void Start()
        {
            playerCamera = gameObject.GetComponentInChildren<Camera>();
            characterController = GetComponent<CharacterController>();
            gravityVector = Physics.gravity;
        }

        void Update()
        {
            CameraLook();
            JumpAndGravity();
            Movement();
            CameraRaycast();
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

            characterController.Move((movementVector.normalized * (isRunning ? runSpeed : walkSpeed) + playerYVelocity) * Time.deltaTime);
        }
        void JumpAndGravity()
        {
            //Jump button pressed and player is grounded
            if (Input.GetButtonDown("Jump") && characterController.isGrounded)
            {
                Debug.Log("here");
                playerYVelocity.y = jumpForce;
            }

            playerYVelocity.y += (gravityVector.y * gravityScale);
            //characterController.Move(playerYVelocity * Time.deltaTime);
        }
        void CameraRaycast()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out raycastHitResult, raycastDistance, raycastLayerMask);
                if (raycastHitResult.collider) { Debug.Log("Object hit: " + raycastHitResult.collider.name + " of layer:" + raycastHitResult.collider.gameObject.layer); }
            }
        }
    }
}

