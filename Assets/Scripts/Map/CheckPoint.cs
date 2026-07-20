using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool oneTimeOnly = true;

    private bool isUsed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isUsed == true) return;

        PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
        if (playerRespawn == null)
        {
            return;
        }

        playerRespawn.SetCheckPoint(transform.position);

        if (oneTimeOnly == true)
        {
            isUsed = true;
        }    
    }
}
