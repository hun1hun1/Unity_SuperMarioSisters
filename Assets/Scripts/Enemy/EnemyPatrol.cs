using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveDistance = 3.0f;

    private Rigidbody2D enemyBody;
    private Vector3 startPosition;
    private float moveDirection = 1.0f;
    private Animator enemyAnimator;

    public SpriteRenderer enemyRenderer;
    public bool spriteRight = true;
    public PlayerScore playerScore;

    public int scoreAmount = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 현재 설정된 방향으로 이동.
        Move();
        // 이동 범위를 벗어났는지 확인.
        CheckTurn();
        UpdateDirectionView();

        PrintStatus();

        UpdateAnimation();
    }

    public void DieProcess()
    {
        playerScore.CheckScore(scoreAmount);
        gameObject.SetActive(false);
    }

    void Move()
    {
        if (enemyBody == null)
        {
            return;
        }

        Vector2 velocity = enemyBody.linearVelocity;
        velocity.x = moveDirection * moveSpeed;
        enemyBody.linearVelocity = velocity;
    }

    void CheckTurn()
    {
        float distanceFromStart = transform.position.x - startPosition.x;
        if (distanceFromStart >= moveDistance)
        {
            moveDirection = -1.0f;
        }

        if (distanceFromStart <= -moveDistance)
        {
            moveDirection = 1.0f;
        }
    }

    void PrintStatus()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Debug.Log("현재 위치: " + transform.position);
            Debug.Log("시작 위치: " + startPosition);
            Debug.Log("이동 방향: " + moveDirection);
        }
    }

    void UpdateAnimation()
    {
        if (enemyAnimator == null)
        {
            return;
        }

        bool isMoving = false;
        if (moveDirection != 0.0f)
        {
            isMoving = true;
        }

        enemyAnimator.SetBool("IsMoving", isMoving);
    }

    void UpdateDirectionView()
    {
        if (spriteRight == true)
        {
            if (enemyRenderer == null)
            {
                return;
            }

            if (moveDirection > 0.0f)
            {
                enemyRenderer.flipX = false;
            }
            else if (moveDirection < 0.0f)
            {
                enemyRenderer.flipX = true;
            }
        }
        else
        {
            if (enemyRenderer == null)
            {
                return;
            }

            if (moveDirection > 0.0f)
            {
                enemyRenderer.flipX = true;
            }
            else if (moveDirection < 0.0f)
            {
                enemyRenderer.flipX = false;
            }
        }
    }
}
