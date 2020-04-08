using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float SPEED = 4, SPRINT_SPEED = 2;
    private const int JUMP = 15;
    private const float GRAVITY = 10;
    private bool isPlayerOnGround = true;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController controller;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                moveDirection = new Vector3(0, 0, 1);
                if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
                {
                    moveDirection *= SPEED * SPRINT_SPEED;
                    animator.SetBool("walk", false);
                    animator.SetBool("run", true);
                }
                else
                {
                    moveDirection *= SPEED;
                    animator.SetBool("walk", true);
                    animator.SetBool("run", false);
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveDirection = new Vector3(0, 0, -1);
                moveDirection *= SPEED;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = new Vector3(1, 0, 0);
                moveDirection *= SPEED;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                moveDirection = new Vector3(-1, 0, 0);
                moveDirection *= SPEED;
            }
            else
            {
                animator.SetBool("walk", false);
                animator.SetBool("run", false);
                moveDirection = Vector3.zero;
            }

            //Player Jump
            if (Input.GetKey(KeyCode.Space))
            {
                if (isPlayerOnGround)
                {
                    isPlayerOnGround = false;
                    moveDirection += new Vector3(0, 1, 0);
                    moveDirection *= JUMP;
                }
            }

            if (moveDirection.z == 0)
            {
                isPlayerOnGround = true;
            }

            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= GRAVITY * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
