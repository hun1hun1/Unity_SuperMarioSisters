using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float invincibleTime = 1f;
    public GameManager gameManager;

    bool isDead = false;
    bool isInvincible = false;
    float invincibleTimer = 0f;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInvincibleTimer();
    }

    public void TakeDamage(int damageAmount)
    {
        if (isInvincible == true)
        {
            Debug.Log("무적 상태라서 데미지를 무시합니다.");
            return;
        }

        gameManager.ChangePlayerHp(damageAmount);

        if (isDead == false)
        {
            StartInvincible();
        }
    }

    //public void TakeDamage(int damageAmount)
    //{
    //    if (isInvincible == true)
    //    {
    //        Debug.Log("무적 상태라서 데미지를 무시합니다.");
    //        return;
    //    }

    //    gameManager.ChangePlayerHp(damageAmount);

    //    StartCoroutine(DamageCoroutine());
    //}

    //IEnumerator DamageCoroutine()
    //{
    //    isInvincible = true;

    //    float timer = 0.0f;

    //    while (timer < invincibleTimer)
    //    {
    //        spriteRenderer.enabled = !spriteRenderer.enabled;

    //        timer += Time.deltaTime;

    //        yield return null;
    //    }

    //    spriteRenderer.enabled = true;
    //    isInvincible = false;
    //}

    void StartInvincible()
    {
        isInvincible = true;
        invincibleTimer = invincibleTime;
        Debug.Log("잠시 무적 상태가 되었습니다.");
    }

    void UpdateInvincibleTimer()
    {
        if (isInvincible == false)
        {
            return;
        }

        spriteRenderer.enabled = !spriteRenderer.enabled;
        invincibleTimer = invincibleTimer - Time.deltaTime;

        if (invincibleTimer <= 0f)
        {
            spriteRenderer.enabled = true;
            isInvincible = false;
            Debug.Log("무적 시간이 끝났습니다.");
        }
    }

    //public void ResetHealth()
    //{
    //    currentHp = maxHp;
    //    isDead = false;
    //    isInvincible = false;

    //    invincibleTimer = 0.0f;
    //    Debug.Log("체력이 초기화되었습니다.");
    //}
}
