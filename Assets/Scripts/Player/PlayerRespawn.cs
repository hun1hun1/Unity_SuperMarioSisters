using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float fallLimitY = -20.0f;
    public RespawnPlayer respawnPlayer;

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
    }

    void CheckFall()
    {
        if (transform.position.y <= fallLimitY)
        {
            // ¸®½ºÆù.
            Respawn();
        }
    }

    //public void Respawn()
    //{
    //    transform.position = respawnPosition;
    //    // ±âÁ¸ ÀÌµ¿ ¸ØÃã.
    //    StopVelocity();

    //    //playerHealth.ResetHealth();
    //    respawnCount++;
    //    Debug.Log("¸®½ºÆù È½¼ö: " + respawnCount);
    //}

    public void Respawn()
    {
        respawnPlayer.RespawnP();
        respawnCount++;
        Debug.Log("¸®½ºÆù È½¼ö: " + respawnCount);
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
}
