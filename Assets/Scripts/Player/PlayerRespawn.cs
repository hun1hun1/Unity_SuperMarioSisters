using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float fallLimitY = -10.0f;

    private Vector3 respawnPosition;
    private Rigidbody2D playerBody;
    private PlayerHealth playerHealth;

    private int respawnCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        respawnPosition = transform.position;
        playerBody = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckFall();
        PassiveRespawn();
        PrintRespawnPosition();
    }

    void CheckFall()
    {
        if (transform.position.y <= fallLimitY)
        {
            // 리스폰.
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = respawnPosition;
        // 기존 이동 멈춤.
        StopVelocity();

        playerHealth.ResetHealth();
        respawnCount++;
        Debug.Log("리스폰 횟수: " + respawnCount);
    }

    void StopVelocity()
    {
        playerBody.linearVelocity = Vector2.zero;
    }

    public void SetCheckPoint(Vector3 checkpointPosition)
    {
        respawnPosition = checkpointPosition;
    }

    void PassiveRespawn()
    {
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            Respawn();
        }
    }

    void PrintRespawnPosition()
    {
        if (Input.GetKeyDown(KeyCode.C) == true)
        {
            Debug.Log("현재 체크포인트 위치: " + respawnPosition);
        }
    }
}
