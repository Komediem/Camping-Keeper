using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private CharacterController controller;

    [SerializeField] public Rigidbody rb;

    public bool lockMovements;

    public bool isCrouching = false;

    [Header("Movement Settings")]
    [Space]
    public float speed = 5f;
    public float speedDefault;
    [SerializeField] private float moveSmoothTime = 0.2f;
    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;
    private float speedValue;
    [Space]

    [Header("Jump Settings")]
    [Space]
    public float jumpSpeed = 8f;
    public float jumpDefault;
    float jumpHeight = 1f;

    public GameObject Interract;

    [SerializeField] private float gravity = 10.0f;
    [SerializeField] private bool isJumping;

    private Vector3 verticalVelocity;
    public float trampolineForce = 16f;
    [Space]
    float movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        speedDefault = speed;
        jumpDefault = jumpSpeed;

        Interract.SetActive(false);
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

            jumpSpeed = jumpDefault;
        }
    }

    void CheckJump()
    {
        if (isJumping)
        {
            verticalVelocity.y = jumpSpeed * jumpHeight;
            
            isJumping = false;
        }
        else
        {
            verticalVelocity.y -= gravity * 2 * Time.deltaTime;
        } 
        
        controller.Move(verticalVelocity * Time.deltaTime);
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
            if (controller.isGrounded && !isCrouching)
            {
                isJumping = true;
            }
        }
        else if (context.canceled)
        {
            isJumping = false;
        }
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        ///Speed/2, no jump, no stun, no pull/push, no interact
        if (context.performed)
        {
            if (isCrouching)
            {
                isCrouching = false;

                speed *= 2;
            }
            else
            {
                isCrouching = true;

                speed /= 2;

                isJumping = false;
                Interract.SetActive(false);

                //anim crouch & collider gets smaller
            }
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseMenu.Instance.PauseGame();
        }
    }

    public void Interraction(InputAction.CallbackContext context)
    {
        if (context.started && !isCrouching)
        {
            Interract.SetActive(true); 
        }
        else if (context.canceled || context.performed)
        {
            Interract.SetActive(false);
        }
    }
    #endregion

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Roof")
        {
            verticalVelocity.y -= gravity;
        }

        if (collision.gameObject.tag == "Trampoline")
        {
            if (controller.isGrounded)
            {
                jumpSpeed = trampolineForce;

                isJumping = true;

                //CheckJump();

                print("WeeWoo");
            }
        }
    }
}
