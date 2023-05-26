using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private CharacterController controller;

    #region Movement
    [Header("Movement Settings")]
    [Space]
    float movement;
    public bool lockMovements;

    public bool isCrouching = false;
    [Space]
    public float speed = 5f;
    public float speedDefault;
    private float speedValue;

    [SerializeField] private float moveSmoothTime = 0.2f;
    private Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;
    [Space]
    #endregion

    #region Jump
    [Header("Jump Settings")]
    [Space]
    public float jumpSpeed = 8f;
    public float jumpDefault;
    public float jumpHeight = 1f;
    
    [SerializeField] private bool isJumping;
    [SerializeField] private float gravity = 9.8f;
    

    private Vector3 velocity;

    [SerializeField] private float trampolineForce = 16f;
    #endregion

    [Space]
    [SerializeField]
    private GameObject Interract;

    [Header("PushPull/Pull")]
    public bool IsPulling = false;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        controller = GetComponent<CharacterController>();
        speedValue = speed;
    }

    private void Start()
    {
        speedDefault = speed;
        jumpDefault = jumpSpeed;

        Interract.SetActive(false);
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
            velocity.y = jumpSpeed * jumpHeight;
            
            isJumping = false;
        }
        else
        {
            velocity.y -= gravity * 2 * Time.deltaTime;
        } 
        
        controller.Move(velocity * Time.deltaTime);

        jumpSpeed = jumpDefault;
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
        ///Speed/2, no jump, no interact, no stun, no pull/push
        if (context.performed)
        {
            if (isCrouching)
            {
                isCrouching = false;

                speed *= 2;
                speedValue *= 2;
            }
            else
            {
                isCrouching = true;

                speed /= 2;
                speedValue /= 2;

                isJumping = false;
                Interract.SetActive(false);

                //needs to be unable to stun
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

    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.started && !isCrouching)
        {
            Interract.SetActive(true);
            Invoke("InteractStop", 0.2f);
        }
    }

    public void Pull(InputAction.CallbackContext context)
    {
        if (context.performed && !isCrouching)
        {
            IsPulling = true;
        }
        else if (context.canceled)
        {
            IsPulling = false;
        }
    }
    #endregion

    private void InteractStop()
    {
        Interract.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Roof"))
        {
            velocity.y -= gravity;

            print("wawawa");
        }
        else if (collision.CompareTag("Trampoline"))
        {
            if (isCrouching)
            {
                jumpSpeed = trampolineForce / 2;
                isJumping = true;
            }
            else if (controller.isGrounded && !isJumping)
            {
                jumpSpeed = trampolineForce;

                isJumping = true;

                print("WeeWoo");
            }
        }
    }
}