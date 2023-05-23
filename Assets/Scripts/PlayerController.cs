using UnityEngine.InputSystem;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private CharacterController controller;

    public bool lockMovements;

    [Header("Movement Settings")]
    [Space]
    [SerializeField] public float speed = 5f;
    [SerializeField] public float speedDefault;
    [SerializeField] private float moveSmoothTime = 0.2f;
    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;
    private float speedValue;
    [Space]
    [Header("Jump Settings")]
    [Space]
    [SerializeField] public float jumpSpeed = 8.0f;
    [SerializeField] public float jumpDefault;
    [SerializeField] private float gravity = 10.0f;
    [SerializeField] private bool isJumping;
    private float verticalVelocity;


    float movement;

    private void Start()
    {
        speedDefault = speed;
        jumpDefault = jumpSpeed;
    }
    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        controller = GetComponent<CharacterController>();
        speedValue = speed;
    }

    void Update()
    {
        if (!lockMovements)
        {
            float x = movement;

            Vector3 move = transform.right * x;

            currentMoveVelocity = Vector3.SmoothDamp(currentMoveVelocity, move * speedValue, ref moveDampVelocity, moveSmoothTime);

            controller.Move(currentMoveVelocity * Time.deltaTime);

            CheckJump();
        }
    }

    void CheckJump()
    {
        if (isJumping)
        {
            float jumpHeight = Mathf.Clamp01(20);
            verticalVelocity = jumpSpeed * jumpHeight;

            if (verticalVelocity >= jumpSpeed)
                isJumping = false;
        }
        else
        {
            verticalVelocity -= gravity * 2 * Time.deltaTime;
        }

        controller.Move(Vector3.up * verticalVelocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb != null && !rb.isKinematic)
        {
            Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            rb.velocity = pushDirection * 10f;
        }
    }

    #region Input

    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<float>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started) 
        { 
            if (controller.isGrounded)
            {
                isJumping = true;
            }
        }
        else if (context.canceled)
        {
            isJumping = false;
        }

    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseMenu.Instance.PauseGame();
        }
    }

    #endregion
}
