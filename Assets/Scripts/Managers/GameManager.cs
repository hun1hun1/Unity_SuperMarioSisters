using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerHp = 10;
    public int score = 0;
    public int remainingEnemyCount = 0;
    public bool isGameCleared = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("현재 점수: " + score);
        Debug.Log("플레이어 체력: " + playerHp);
        Debug.Log("남은 적 수: " + remainingEnemyCount);
        Debug.Log("클리어 여부: " + isGameCleared);
    }

    public void AddScore(int amount)
    {
        //score = score + amount;
        score += amount;
        Debug.Log("점수 증가: " + amount);
        Debug.Log("현재 점수: " + score);
    }

    public void ChangePlayerHp(int amount)
    {
        //playerHp = playerHp + amount;
        playerHp += amount;

        if (amount > 0)
        {
            Debug.Log("체력 회복: " + amount);
        }
        else
        {
            Debug.Log("피해 받음: " + amount);
        }

        if (playerHp < 0)
        {
            playerHp = 0;
        }

        Debug.Log("플레이어 체력: " + playerHp);
    }

    public void RegisterEnemy()
    {
        //remainingEnemyCount = remainingEnemyCount + 1;
        //remainingEnemyCount += 1;
        remainingEnemyCount++;
        Debug.Log("적 등록 완료");
        Debug.Log("남은 적 수: " + remainingEnemyCount);
    }

    public void NotifyEnemyDeath(int scoreAmount)
    {
        AddScore(scoreAmount);
        if (remainingEnemyCount == 1)
        {
            Debug.Log("보너스 스코어 100 추가");
            AddScore(100);
        }
        //remainingEnemyCount = remainingEnemyCount - 1;
        //remainingEnemyCount -= 1;
        remainingEnemyCount--;
        if (remainingEnemyCount < 0) remainingEnemyCount = 0;

        Debug.Log("남은 적 수: " + remainingEnemyCount);

        if (remainingEnemyCount <= 0)
        {
            // 게임 클리어 처리.
            ClearGame();
        }
    }

    void ClearGame()
    {
        if (isGameCleared == true)
        {
            return;
        }

        isGameCleared = true;
        Debug.Log("스테이지 클리어");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
