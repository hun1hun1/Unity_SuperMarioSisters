using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public string playerName = "Hero";
    public int playerHp = 10;
    public bool canMove = true;

    public float jumpPower = 7.0f;
    public int totalScore = 0;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    float moveDirection = 0.0f;

    bool isGrounded = false;

    Rigidbody2D playerBody;
    Collider2D playerCollider;
    Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        PrintGroundState();
        CheckInput();
        CheckGround();

        if (canMove == true)
        {
            Jump();
        }
        else
        {
            Debug.Log("이동 불가능한 상태입니다.");
        }

        if (canMove == true)
        {
            Move();
        }
        else
        {
            Debug.Log("이동 불가능한 상태입니다.");
        }

        UpdateAnimation();

        //if (transform.position.x > 5.0f)
        //{
        //    Vector3 currentPosition = transform.position;
        //    currentPosition.x = 5.0f;
        //    transform.position = currentPosition;
        //}
        //else if (transform.position.x < -5.0f)
        //{
        //    Vector3 currentPosition = transform.position;
        //    currentPosition.x = -5.0f;
        //    transform.position = currentPosition;
        //}
    }

    void CheckInput()
    {
        moveDirection = 0.0f;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) == true)
        {
            moveDirection = 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) == true)
        {
            moveDirection = -1.0f;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("현재 위치: " + transform.position);
        }
    }

    void UpdateAnimation()
    {
        if (playerAnimator == null)
        {
            return;
        }

        bool isMoving = false;
        if (moveDirection != 0.0f)
        {
            isMoving = true;
        }

        playerAnimator.SetBool("IsMoving", isMoving);
        playerAnimator.SetBool("IsGrounded", isGrounded);
    }

    void Move()
    {
        playerBody.linearVelocity = new Vector2(moveDirection * moveSpeed, playerBody.linearVelocity.y);

        //if (moveDirection > 0.0f)
        //{
        //    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //}

        //if (moveDirection < 0.0f)
        //{
        //    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //}

        //Vector3 currentPosition = transform.position;
        //currentPosition.x += moveDirection * moveSpeed * Time.deltaTime;
        //transform.position = currentPosition;

        //Vector3 move = new Vector3(moveDirection, 0.0f, 0.0f);
        //transform.position += move * moveSpeed * Time.deltaTime;

        //if (Input.GetKey(KeyCode.LeftShift) == true)
        //{
        //    transform.position += move * runSpeed * Time.deltaTime;
        //}
        //else
        //{
        //    transform.position += move * moveSpeed * Time.deltaTime;
        //}
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (isGrounded == true)
            {
                Vector2 velocity;
                velocity = playerBody.linearVelocity;

                velocity.y = jumpPower;
                playerBody.linearVelocity = velocity;

                isGrounded = false;
            }
        }
    }

    void CheckGround()
    {
        Collider2D ground;
        ground = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (ground != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void PrintGroundState()
    {
        if (Input.GetKeyDown(KeyCode.G) == true)
        {
            Debug.Log("바닥에 닿아 있는가: " + isGrounded);
            Debug.Log("현재 y 속도: " + playerBody.linearVelocity.y);
        }

    }
}
