using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private CharacterController controller;

    public AudioSource audioSource;
    public AudioClip clip;

    [Space]
    [SerializeField] VisualEffect sparksVFX;
    [SerializeField] Light lanternLight;
    [SerializeField] public bool readyToStun;
    [SerializeField] public AudioSource stunSound;

    [Space]
    public Rigidbody rb;
    public Animator playerAnimator;

    [Space]
    public GameObject Raycast;

    #region Movement
    [Header("Movement Settings")]
    [Space]
    public float movement;
    private Vector3 move;
    public bool lockMovements;

    public bool isCrouching = false;

    [Space]
    public float speed = 5f;
    public float speedDefault;
    public float speedValue;

    [Space]
    private float moveSmoothTime = 0.2f;
    public Vector3 currentMoveVelocity;
    private Vector3 moveDampVelocity;

    [Space]
    #endregion

    #region Jump
    [Header("Jump Settings")]
    [Space]
    public float jumpSpeed = 8f;
    public float jumpDefault;
    public float jumpHeight = 1f;

    public bool canJump;
    public bool isJumping;

    private float gravity = 9.8f;
    private Vector3 velocity;

    //Trampoline settings
    [SerializeField] private float trampolineForce = 16f;

    public bool canTrampo = false;
    #endregion

    [Space]
    public GameObject Interract;

    [Space]
    public bool isPulling = false;
    public bool PushPullTrigger;

    [Space]
    public float SpamRequire;
    public bool SpamActive = false;
    public bool SpamEND = false;

    #region Light
    [Space]
    public GameObject LightLantern;
    public float LightTime;

    [Space]
    public float cooldownDuration = 3f;  // Duration of the cooldown in seconds
    public float currentCooldown = 0f;  // Current cooldown progress
    public bool isCooldown = false;  // Flag to check if the cooldown is active

    [Space]
    public float NombrePression;
    #endregion

    private void Awake()
    {
        if (Instance) Destroy(this);
        else Instance = this;

        controller = GetComponent<CharacterController>();
        speedValue = speed;

        LightLantern = GameObject.Find("LightHitBox");

        Raycast = GameObject.Find("RayCast");

        rb = GetComponent<Rigidbody>();

        playerAnimator = GetComponentInChildren<Animator>();

        sparksVFX = GetComponentInChildren<VisualEffect>();
    }

    private void Start()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        speedDefault = speed;
        jumpDefault = jumpSpeed;

        Interract.SetActive(false);

        LightLantern.SetActive(false);

        isPulling = false;
        PushPullTrigger = false;

        Raycast.SetActive(false);

        velocity.y = -10f;
    }

    void Update()
    {
        Cooldown();

        if (!lockMovements)
        {
            if (!PushPullTrigger)
            {
                if (movement > 0) //going right
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (movement < 0) //going left
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                move = transform.right * Mathf.Abs(movement);
            }
            else
            {
                move = transform.right * movement;
            }

            currentMoveVelocity = Vector3.SmoothDamp(currentMoveVelocity, move * speedValue, ref moveDampVelocity, moveSmoothTime);
            controller.Move(currentMoveVelocity * Time.deltaTime);

            CheckJump();

            if (controller.isGrounded)
            {
                playerAnimator.SetBool("isJumping", false);
                isJumping = false;

                velocity.y = -10f;

                //print("Grounded");
            }

            if (movement != 0)
            {
                if (isCrouching)
                {
                    playerAnimator.SetBool("isCrouchWalking", true);
                }
                else
                {
                    playerAnimator.SetBool("isWalking", true);
                }
            }
            else
            {
                playerAnimator.SetBool("isWalking", false);
                playerAnimator.SetBool("isCrouchWalking", false);
            }
        }
    }

    void CheckJump()
    {
        if (canJump)
        {
            velocity.y = jumpSpeed * jumpHeight;

            canJump = false;

            playerAnimator.SetBool("isJumping", true);
            isJumping = true;

            //print("Mercy is for the WEAK");
        }
        else if (velocity.y > -20)
        {
            velocity.y -= gravity * Time.deltaTime * 2;
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
            }
        }
        else if (context.canceled)
        {
            canJump = false;
        }
    }

    public void Crouch(InputAction.CallbackContext context)
    {
        ///Speed/2, no Jump, no Interact, no Stun, no Pull/Push
        if (context.performed)
        {
            if (isCrouching && Raycastcrouch.Instance.CanStand)
            {
                isCrouching = false;

                speed = speedDefault;
                speedValue = speedDefault;

                Raycast.SetActive(false);

                controller.height = 1.75f;
                controller.center = new(0, 1f, 0);

                playerAnimator.SetBool("isCrouching", false);
                playerAnimator.SetBool("isCrouchWalking", false);
            }
            else if (Raycastcrouch.Instance.CanStand && !isPulling)
            {
                isCrouching = true;

                speed /= 2;
                speedValue /= 2;

                Raycast.SetActive(true);

                canJump = false;
                Interract.SetActive(false);

                controller.height = 1.2f;
                controller.center = new(0, 0.6f, 0); 

                playerAnimator.SetBool("isCrouching", true);
            }
        }
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 3) // not in menu or credits scenes
            {
                PauseMenu.Instance.PauseGame();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 0 && !Menu.Instance.isMenuActive) //in menu scene and menu is not active
            {
                PauseMenu.Instance.PauseGame();
            }
            else if (SceneManager.GetActiveScene().buildIndex == 3) //in credits scene
            {
                Credits.Instance.LoadMainMenu();
            }
        }
    }

    public void Pull(InputAction.CallbackContext context)
    {
        if (context.performed && !isCrouching)
        {
            isPulling = true;
            audioSource.PlayOneShot(clip);
        }
        else if (context.canceled && !isCrouching)
        {
            isPulling = false;
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

    public void Light(InputAction.CallbackContext context)
    {
        if (context.started && !isCrouching && !isCooldown && readyToStun)
        {
            if(FirstEncounter.Instance != null)
            FirstEncounter.Instance.Stun();

            LightLantern.SetActive(true);
            sparksVFX.Play();
            stunSound.Play();

            //Play Anmation, Be Carefull of the Moment Where The Light Cuts
            Invoke("LightStop", LightTime);

            StartCooldown();

            if (NombrePression >= SpamRequire)
            {
                SpamActive = true;
                SpamEND = true;
            }

            if(Spam.Instance.NoCD)
                Spam.Instance.StunSpamAnimator.SetTrigger("StunSpam");

            if (Spam.Instance.NoCD)
                NombrePression++;
        }
    }

    #region Cooldown
    public void Cooldown()
    {
        if (isCooldown)
        {
            //Rajoutez les actions qui se déroulent pendant le cooldown
            if(Spam.Instance != null && !Spam.Instance.NoCD)
            lanternLight.intensity += Time.deltaTime * 100;


            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {
                // Cooldown has finished
                isCooldown = false;
                currentCooldown = 0f;
                // Perform any actions you want to trigger after the cooldown finishes
            }
        }
    }

    public void StartCooldown()
    {
        if (!isCooldown)
        {
            isCooldown = true;
            currentCooldown = cooldownDuration;

            if (Spam.Instance != null && !Spam.Instance.NoCD)
                lanternLight.intensity = 0f;

            else if (Spam.Instance != null && Spam.Instance.NoCD)
                lanternLight.intensity += 300;
            // Rajoutez les actions qui se déroulent au début du cooldown
        }
    }
    #endregion
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
            velocity.y -= gravity * 2 * Time.deltaTime;

            //print("Roof Hit");
        }

        if (collision.CompareTag("Trampoline") && collision.GetComponent<BoxCollider>().enabled)
        {
            if (isCrouching)
            {
                jumpSpeed = trampolineForce / 2;

                canJump = true;

                //Character Controller size

                //print("crouch trampoline");
            }
            else if (controller.isGrounded && !canJump)
            {
                jumpSpeed = trampolineForce;

                canJump = true;

                collision.GetComponent<JumpFeedbackClass>().ReturnFeedback();

                //print("trampoline");
            }
        }
    }
}
