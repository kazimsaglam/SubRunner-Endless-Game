using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameManager gameManager;

    public enum Direction{ Left, Mid, Right }
    public Direction direction = Direction.Mid;

    public float moveSpeed = 5f;
    public float accelerationRate = 0.1f;
    public float dodgeSpeed = 7f;
    public float xPos;

    private float originalCenterY;
    private float originalHeight;
    private bool isSlide;

    #region Jump

    public float jumpPower = 5f;

    // Internal Variables
    private bool isGrounded = false;
    private Vector3 velocity;

    #endregion

    public GameObject blinkEffect;
    public bool isDamaged = false;

    private CharacterController characterController;
    private Animator anim;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        originalHeight = characterController.height;
        originalCenterY = characterController.center.y;
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void Update()
    {
        CheckInput();
        CheckGround();  
    }

    private void MoveCharacter()
    {
        if(moveSpeed <= 50)
        {
            moveSpeed += accelerationRate * Time.deltaTime;
        }

        characterController.Move(Vector3.forward * moveSpeed * Time.deltaTime);


        if (direction == Direction.Left)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(-xPos, transform.position.y, transform.position.z), Time.deltaTime * dodgeSpeed);
        }
        else if (direction == Direction.Right)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(xPos, transform.position.y, transform.position.z), Time.deltaTime * dodgeSpeed);
        }
        else if (direction == Direction.Mid)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0f, transform.position.y, transform.position.z), Time.deltaTime * dodgeSpeed);
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (direction == Direction.Mid)
            {
                direction = Direction.Left;
            }
            else if (direction == Direction.Right)
            {
                direction = Direction.Mid;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (direction == Direction.Mid)
            {
                direction = Direction.Right;
            }
            else if (direction == Direction.Left)
            {
                direction = Direction.Mid;
            }
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            Jump();
        }

        // Slide
        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }
    }

    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.2f);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        velocity.y += -30f * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpPower * -2f * -30f);
            anim.SetTrigger("JumpTrigger");
            isGrounded = false;
        }
    }

    private void Slide()
    {
        if(!isSlide && isGrounded)
        {
            anim.SetTrigger("SlideTrigger");
            StartCoroutine(SlideCooldown());
        }
    }

    private IEnumerator SlideCooldown()
    {
        isSlide = true;
        characterController.center = new Vector3(0, originalCenterY / 2f, 0);
        characterController.height = originalHeight / 2.5f;
        yield return new WaitForSeconds(0.5f);
        characterController.center = new Vector3(0, originalCenterY, 0);
        characterController.height = originalHeight;
        isSlide = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && !isDamaged)
        {
            gameManager.TakeDamage();
            StartCoroutine(CharacterBlink());
        }
    }

    private IEnumerator CharacterBlink()
    {
        isDamaged = true;
        for (int i = 0; i < 10; i++)
        {
            if (blinkEffect.activeInHierarchy)
            {
                blinkEffect.SetActive(false);
            }
            else
            {
                blinkEffect.SetActive(true);
            }
            yield return new WaitForSeconds(0.25f);
        }
        isDamaged = false;
    }
}
