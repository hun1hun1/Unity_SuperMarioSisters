using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float moveDistance = 3.0f;
    public bool moveX = true;
    public bool moveY = false;
    public float stopTime = 2.0f;
    public bool onPlayerMove = false;
    public bool rightFirst = true;

    private Vector3 startPosition;
    private float moveDirectionX = 1.0f;
    private float moveDirectionY = 1.0f;
    //private float timer = 0.0f;
    private bool isOnPlayer = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        if (rightFirst != true) moveDirectionX = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (onPlayerMove == true)
        {
            if (isOnPlayer == true)
            {
                if (moveX == true)
                {
                    // 발판 이동 처리.
                    MovePlatformX();
                    // 방향 전환 처리.
                    CheckTurnPointX();
                }

                if (moveY == true)
                {
                    MovePlatformY();
                    CheckTurnPointY();
                }
            }
        }
        else
        {
            if (moveX == true)
            {
                // 발판 이동 처리.
                MovePlatformX();
                // 방향 전환 처리.
                CheckTurnPointX();
            }

            if (moveY == true)
            {
                MovePlatformY();
                CheckTurnPointY();
            }
        }
    }

    void MovePlatformX()
    {
        Vector3 moveAmount = Vector3.right * moveDirectionX * moveSpeed * Time.deltaTime;

        transform.position = transform.position + moveAmount;
    }

    void CheckTurnPointX()
    {
        float distanceFromStart = transform.position.x - startPosition.x;

        if (distanceFromStart > moveDistance)
        {
            moveDirectionX = -1.0f;

        }
        else if (distanceFromStart < -moveDistance)
        {
            moveDirectionX = 1.0f;
        }
    }

    void MovePlatformY()
    {
        Vector3 moveAmount = Vector3.up * moveDirectionY * moveSpeed * Time.deltaTime;

        transform.position = transform.position + moveAmount;
    }

    void CheckTurnPointY()
    {
        float distanceFromStart = transform.position.y - startPosition.y;

        if (distanceFromStart > moveDistance)
        {
            moveDirectionY = -1.0f;

        }
        else if (distanceFromStart < -moveDistance)
        {
            moveDirectionY = 1.0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 게임 오브젝트의 Tag가 인자로 전달한 문자열과 일치하는지 체크하는 함수.
        if (collision.gameObject.CompareTag("Player") == true)
        {
            // SetParent : 인자로 전달한 트랜스폼을 부모로 설정하는 함수.
            collision.gameObject.transform.SetParent(transform);
            isOnPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.transform.SetParent(null);
            isOnPlayer = false;
        }
    }
}
