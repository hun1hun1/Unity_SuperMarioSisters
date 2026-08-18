using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool oneTimeOnly = false;
    public Color activeColor = Color.green;
    public Color inactiveColor = Color.red;
    public RespawnPlayer respawnPlayer;

    private bool isUsed = false;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isUsed == true) return;

        PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
        if (playerRespawn == null)
        {
            return;
        }

        respawnPlayer.RegisterCheckPoint(this);

        if (oneTimeOnly == true)
        {
            isUsed = true;
        }    
    }

    public void SetActiveCheckpoint(bool active)
    {
        if (active)
        {
            spriteRenderer.color = activeColor;
        }
        else
        {
            spriteRenderer.color = inactiveColor;
        }
    }
}
