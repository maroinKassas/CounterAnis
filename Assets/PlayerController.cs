using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float rotateAmountX;
    float rotateAmountY;
    float mouseSensitivity = 5;
    Vector3 rotatePlayer;

    float speed = 4;
    float sprintSpeed = 2;
    float gravity = 8;
    bool isPlayerOnGround = true;
    Vector3 moveDirection = Vector3.zero;

    CharacterController controller;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        Movement();
        Attacking();
    }

    void RotateCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotateAmountX = mouseX * mouseSensitivity;
        rotateAmountY = mouseY * mouseSensitivity;

        rotatePlayer = this.transform.rotation.eulerAngles;

        /*rotatePlayer.x -= rotateAmountY;
        rotatePlayer.z = 0;*/
        rotatePlayer.y += rotateAmountX;

        this.transform.rotation = Quaternion.Euler(rotatePlayer);
    }

    void Movement()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                moveDirection = new Vector3(0, 0, 1);
                if (Input.GetKey(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
                {
                    moveDirection *= speed * sprintSpeed;
                    animator.SetBool("walk", false);
                    animator.SetBool("run", true);
                } 
                else
                {
                    moveDirection *= speed;
                    animator.SetBool("walk", true);
                    animator.SetBool("run", false);
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveDirection = new Vector3(0, 0, -1);
                moveDirection *= speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = new Vector3(1, 0, 0);
                moveDirection *= speed;
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                moveDirection = new Vector3(-1, 0, 0);
                moveDirection *= speed;
            }
            else
            {
                StopMovementAnimation();
                moveDirection = Vector3.zero;
            }

            //Player Jump
            if (Input.GetKey(KeyCode.Space))
            {
                if (isPlayerOnGround)
                {
                    isPlayerOnGround = false;
                    moveDirection += new Vector3(0, 10, 0);

                    //Jump Animation
                    //animator.SetTrigger("jump");

                    //Stop Run Sound
                    //AudioScript.runSoundStop();
                    //Play jump Sound
                    //AudioScript.jumpSoundPlay();
                }
            }

            if (moveDirection.z == 0)
            {
                isPlayerOnGround = true;
            }

            moveDirection = transform.TransformDirection(moveDirection);
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void StopMovementAnimation()
    {
        animator.SetBool("walk", false);
        animator.SetBool("run", false);
    }

    void Attacking()
    {
        if (Input.GetMouseButton(0))
        {
            StopMovementAnimation();
            animator.SetBool("attack", true);
        } else
        {
            animator.SetBool("attack", false);
        }
    }
}
