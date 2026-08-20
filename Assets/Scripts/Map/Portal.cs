using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform outPortal;
    //public float yOffset = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player == null) return;

        if (!player.CanUsePortal()) return;

        player.SetPortalCooldown();

        player.transform.position = new Vector3(outPortal.position.x, outPortal.position.y, outPortal.position.z);
    }
}
