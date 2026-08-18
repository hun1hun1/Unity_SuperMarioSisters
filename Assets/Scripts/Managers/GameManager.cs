using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int maxHp = 5;
    public int score = 0;
    public TMP_Text hpText;
    public int remainingEnemyCount = 0;
    public bool isGameCleared = false;
    public bool hasKey = false;
    public bool isPlayerDead = false;
    public PlayerController playerController;

    public string startSceneName = "StartScene";
    public string playSceneName = "PlayScene";
    public string clearSceneName = "ClearScene";

    int currentHp = 0;
    private RespawnPlayer respawnPlayer;

    private void Start()
    {
        respawnPlayer = GetComponent<RespawnPlayer>();
        currentHp = maxHp;
        UpdateHpText();
    }

    public void AddScore(int amount)
    {
        //score = score + amount;
        score += amount;
        Debug.Log("점수 증가: " + amount);
        Debug.Log("현재 점수: " + score);
    }

    public void HpRespawn()
    {
        currentHp = maxHp;
        UpdateHpText();
    }

    public void ChangePlayerHp(int amount)
    {
        //playerHp = playerHp + amount;
        currentHp -= amount;
        Debug.Log("피해 받음: " + amount);

        ClampHp();
        UpdateHpText();

        Debug.Log("플레이어 체력: " + currentHp);
        if (currentHp <= 0)
        {
            respawnPlayer.RespawnP();
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

    public void RegisterEnemy()
    {
        //remainingEnemyCount = remainingEnemyCount + 1;
        //remainingEnemyCount += 1;
        remainingEnemyCount++;
        Debug.Log("적 등록 완료");
        Debug.Log("남은 적 수: " + remainingEnemyCount);
    }

    void ClearGame()
    {
        if (isGameCleared == true)
        {
            return;
        }

        isGameCleared = true;
        Debug.Log("스테이지 클리어");

        LoadClaerScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(startSceneName);
    }

    public void LoadClaerScene()
    {
        SceneManager.LoadScene(clearSceneName);
        Debug.Log(clearSceneName + "으로 씬을 전환합니다.");
    }

    public void RestartPlayScene()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public int GetPlayerHp()
    {
        return currentHp;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetEnemyCount()
    {
        return remainingEnemyCount;
    }

    public void SetHasKey()
    {
        hasKey = true;
    }

    public bool GetHasKey()
    {
        return hasKey;
    }
}
