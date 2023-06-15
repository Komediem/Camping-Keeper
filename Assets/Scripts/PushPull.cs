using UnityEngine;
using UnityEngine.InputSystem;

public class PushPull : MonoBehaviour
{
    [Header("Don't need to assign :")]
    [SerializeField] private GameObject Player;
    [SerializeField] private Rigidbody rb;

    [Space]
    public bool isPushable = false;
    public bool obstacle = false;

    private void Awake()
    {
        Player = GameObject.Find("Player");

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckCollisions();

        if (isPushable && !PlayerController.Instance.lockMovements && !PlayerController.Instance.isCrouching && PlayerController.Instance.PushPullTrigger)
        {
            Pull();
        }
    }

    public void Pull()
    {
        if (PlayerController.Instance.isPulling && !PlayerController.Instance.isCrouching) ///if button is pressed && isn't crouching
        {
            gameObject.transform.SetParent(Player.transform); //Sets "Player" as the new parent of the child GameObject.

            PlayerController.Instance.canJump = false;
            PlayerController.Instance.isCrouching = false;

            if (PlayerController.Instance.movement == 0) //no movement
            {
                //Anim : Idle Push/Pull
                PlayerController.Instance.playerAnimator.SetBool("isPushAndPull", true);

                PlayerController.Instance.playerAnimator.SetBool("isPushing", false);
                PlayerController.Instance.playerAnimator.SetBool("isPulling", false);
                //

                InputSystem.ResetHaptics();
            }
            else if (PlayerController.Instance.movement > 0) //positive movement, to the right
            {
                //anim : push
                PlayerController.Instance.playerAnimator.SetBool("isPushing", true);

                PlayerController.Instance.playerAnimator.SetBool("isPushAndPull", false);
                PlayerController.Instance.playerAnimator.SetBool("isPulling", false);
                //

                Gamepad.current.SetMotorSpeeds(0.2f, 0.5f);
            }
            else if (PlayerController.Instance.movement < 0) //negative movement, to the left
            {
                //anim : pull
                PlayerController.Instance.playerAnimator.SetBool("isPulling", true);

                PlayerController.Instance.playerAnimator.SetBool("isPushAndPull", false);
                PlayerController.Instance.playerAnimator.SetBool("isPushing", false);
                //

                Gamepad.current.SetMotorSpeeds(0.5f, 0.2f);
            }
        }
        else
        {
            gameObject.transform.SetParent(null); //Setting the parent to "null" unparents the GameObject and turns child into a top-level object in the hierarchy

            //Resets Push/Pull Animation
            PlayerController.Instance.playerAnimator.SetBool("isPushAndPull", false);
            PlayerController.Instance.playerAnimator.SetBool("isPushing", false);
            PlayerController.Instance.playerAnimator.SetBool("isPulling", false);
            //

            InputSystem.ResetHaptics();
        }
    }

    public void CheckCollisions()
    {
        if (/*PlayerController.Instance.isPulling &&*/ isPushable)
        {
            if (obstacle)
            {
                rb.isKinematic = true;

                if (PlayerController.Instance.movement > 0)
                {
                    // Set the position of the pushable object to its previous position
                    rb.MovePosition(rb.position);

                    // Disable player movement while pushing against an obstacle
                    PlayerController.Instance.lockMovements = true;
                }
                else if (PlayerController.Instance.movement < 0 || PlayerController.Instance.movement == 0)
                {
                    // Enable player movement when they are pulling (going bacwards)
                    PlayerController.Instance.lockMovements = false;

                    rb.isKinematic = false;

                    if (PlayerController.Instance.movement == 0)
                    {
                        PlayerController.Instance.currentMoveVelocity = Vector3.zero;
                    }
                }
            }
            else
            {
                rb.isKinematic = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPushable = true;

            PlayerController.Instance.PushPullTrigger = true;

            PlayerController.Instance.speed /= 2;
            PlayerController.Instance.speedValue /= 2;

            PlayerController.Instance.Interract.SetActive(false);
        }

        if (collision.CompareTag("Obstacle"))
        {
            obstacle = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPushable = false;

            PlayerController.Instance.PushPullTrigger = false;

            PlayerController.Instance.speed = PlayerController.Instance.speedDefault;
            PlayerController.Instance.speedValue = PlayerController.Instance.speedDefault;
        }

        if (collision.CompareTag("Obstacle"))
        {
            obstacle = false;
        }
    }
}
