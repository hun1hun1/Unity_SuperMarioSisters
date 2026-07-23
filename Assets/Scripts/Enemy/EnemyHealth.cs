using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHp = 3;

    private int currentHp = 0;
    private bool isDead = false;
    private int lastDamage = 0;
    private bool debugHp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeHealth();
    }

    private void Update()
    {
        ChangeDebugMode();
        
        if (debugHp)
        {
            Debug.Log("적 현재 체력: " + currentHp);
        }
    }

    void InitializeHealth()
    {
        currentHp = maxHp;
        Debug.Log("적 체력 준비: " + currentHp);
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead == true)
        {
            return;
        }

        ReduceHealth(damageAmount);
        lastDamage = damageAmount;

        if (CheckDeath() == true)
        {
            // 사망 처리.
            Die();
            currentHp = 0;
        }
    }

    void Die()
    {
        isDead = true;
        gameObject.SetActive(false);
        Debug.Log("마지막으로 받은 데미지: " + lastDamage);
    }

    void ReduceHealth(int damageAmount)
    {
        currentHp -= damageAmount;
    }

    public bool CheckDeath()
    {
        return currentHp <= 0;
    }

    void ChangeDebugMode()
    {
        if (Input.GetKeyDown(KeyCode.H) == true)
        {
            debugHp = !debugHp;
        }
    }
}
