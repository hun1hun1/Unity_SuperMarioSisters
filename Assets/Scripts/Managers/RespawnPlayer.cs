using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Rigidbody2D playerBody;
    public Transform playerTransform;

    private Vector3 respawnPosition;
    private CheckPoint currentCheckPoint;
    private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        respawnPosition = transform.position;
    }

    public void RespawnP()
    {
        playerTransform.position = respawnPosition;
        StopVelocity();
        gameManager.HpRespawn();
    }

    void StopVelocity()
    {
        playerBody.linearVelocity = Vector2.zero;
    }

    public void RegisterCheckPoint(CheckPoint newCheckPoint)
    {
        if (currentCheckPoint != null)
        {
            currentCheckPoint.SetActiveCheckpoint(false);
        }

        currentCheckPoint = newCheckPoint;
        respawnPosition = currentCheckPoint.transform.position;
        currentCheckPoint.SetActiveCheckpoint(true);
    }
}
