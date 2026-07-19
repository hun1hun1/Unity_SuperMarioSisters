using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth;
        playerHealth = other.GetComponent<PlayerHealth>();

        if (playerHealth == null)
        {
            return;
        }

        playerHealth.TakeDamage(damageAmount);
        Debug.Log("함정 데미지: " + damageAmount);
    }
}
