using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 5;
    public TMP_Text hpText;
    public float invincibleTime = 1f;

    int currentHp = 0;
    bool isDead = false;
    bool isInvincible = false;
    float invincibleTimer = 0f;

    void Start()
    {
        currentHp = maxHp;
        UpdateHpText();
        PrintHealth();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInvincibleTimer();

        if (Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            PrintHealth();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead == true)
        {
            return;
        }

        if (isInvincible == true)
        {
            Debug.Log("무적 상태라서 데미지를 무시합니다.");
            return;
        }

        currentHp = currentHp - damageAmount;

        ClampHp();
        UpdateHpText();
        PrintHealth();
        CheckDead();

        if (isDead == false)
        {
            StartInvincible();
        }
    }

    void ClampHp()
    {
        if (currentHp < 0)
        {
            currentHp = 0;
        }

        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }
    }

    void UpdateHpText()
    {
        if (hpText == null)
        {
            Debug.Log("HP UI가 연결되지 않았습니다.");
            return;
        }

        hpText.text = "HP: " + currentHp;
    }

    void CheckDead()
    {
        if (currentHp <= 0)
        {
            isDead = true;
            Debug.Log("플레이어가 쓰러졌습니다.");
        }
    }

    void PrintHealth()
    {
        Debug.Log("현재 체력: " + currentHp + "/" + maxHp);
    }

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

        invincibleTimer = invincibleTimer - Time.deltaTime;

        if (invincibleTimer <= 0f)
        {
            isInvincible = false;
            Debug.Log("무적 시간이 끝났습니다.");
        }
    }

    public void ResetHealth()
    {
        currentHp = maxHp;
        isDead = false;
        isInvincible = false;

        invincibleTimer = 0.0f;
        ClampHp();
        UpdateHpText();
        PrintHealth();
        Debug.Log("체력이 초기화되었습니다.");
    }
}
