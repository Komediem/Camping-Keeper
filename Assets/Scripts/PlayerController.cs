using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private CharacterController controller;

    public Rigidbody rb;

    public Animator playerAnimator;

    [SerializeField] public GameObject LightLantern;

    public float LightTime;

    #region Movement
    [Header("Movement Settings")]
    [Space]
    float movement;
    public bool lockMovements;

    public bool isCrouching = false;
    [Space]
    public float speed = 5f;
    public float speedDefault;
    public float speedValue;

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

    [SerializeField] public bool canJump;
    [SerializeField] private bool isJumping;
    [SerializeField] private float gravity = 9.8f;

    private Vector3 velocity;

    //Trampoline settings
    [SerializeField] private float trampolineForce = 16f;

    public bool canTrampo = false;
    #endregion

    [Space]
    public GameObject Interract;

    public bool isPulling = false;

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        controller = GetComponent<CharacterController>();
        speedValue = speed;

        LightLantern = GameObject.Find("LightHitBox");


        rb = GetComponent<Rigidbody>();

        playerAnimator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        speedDefault = speed;
        jumpDefault = jumpSpeed;

        Interract.SetActive(false);
        LightLantern.SetActive(false);
        isPulling = false;
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

            if (movement != 0)
            {
                playerAnimator.SetBool("isWalking", true);
            }
            else
            {
                playerAnimator.SetBool("isWalking", false);
            }
        }
    }

    void CheckJump()
    {
        if (canJump)
        {
            velocity.y = jumpSpeed * jumpHeight;

            canJump = false;

            print("Mercy is for the WEAK");
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
        if (context.started)
        {
            if (controller.isGrounded && !isCrouching && !isPulling)
            {
                canJump = true;
                isJumping = true;
            }
        }
        else if (context.canceled)
        {
            canJump = false;
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

                speed = speedDefault;
                speedValue = speedDefault;

                playerAnimator.SetBool("isCrouching", true);
            }
            else
            {
                if (!isPulling)
                {
                    isCrouching = true;

                    speed /= 2;
                    speedValue /= 2;

                    canJump = false;
                    Interract.SetActive(false);

                    playerAnimator.SetBool("isCrouching", false);

                    //needs to be unable to stun
                    //collider gets smaller
                }
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
            speed /= 2;
            speedValue /= 2;

            canJump = false;
            isCrouching = false;

            Interract.SetActive(false);

            isPulling = true;
        }
        else if (context.canceled && !isCrouching)
        {
            speed = speedDefault;
            speedValue = speedDefault;

            isPulling = false;
        }
    }
    public void Light(InputAction.CallbackContext context)
    {
        if (context.started && !isCrouching)
        {
            LightLantern.SetActive(true);
            //play animation faire attention au moment ou la light se coupe
            Invoke("LightStop", LightTime);
        }
    }

    #endregion

    private void InteractStop()
    {
        Interract.SetActive(false);
    }
    private void LightStop()
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

        if (collision.CompareTag("Trampoline"))
        {
            if (isCrouching)
            {
                jumpSpeed = trampolineForce / 2;

                canJump = true;

                print("Redacted");
            }
            else if (controller.isGrounded && !canJump)
            {
                jumpSpeed = trampolineForce;

                canJump = true;

                print("WeeWoo");
            }
        }
    }
}