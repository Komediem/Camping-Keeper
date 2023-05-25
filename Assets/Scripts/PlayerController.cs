using UnityEngine.InputSystem;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private CharacterController controller;

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
    public float jumpSpeed = 8.0f;
    public float jumpDefault;
    float jumpHeight = Mathf.Clamp01(20);

    [SerializeField]
    private GameObject Interract;

    [SerializeField] private float gravity = 10.0f;
    [SerializeField] private bool isJumping;

    private Vector3 verticalVelocity;
    [Space]
    float movement;

    private void Start()
    {
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

    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.started && !isCrouching)
        {
            Interract.SetActive(true);
            Invoke("InteractStop", 0.2f);
        }
    }
    #endregion

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Roof")
        {
            verticalVelocity.y -= gravity;
        }
        else if (collision.tag == "Trampoline")
        {
            Vector3 Boom = new Vector3(0f,200f, 0f);

            controller.Move(Boom);
            

            print("weewoo");
        }
    }

    private void InteractStop()
    {
        Interract.SetActive(false);
    }
}
