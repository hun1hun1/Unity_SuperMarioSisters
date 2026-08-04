using UnityEngine;

public class StageDifficultyController : MonoBehaviour
{
    public EnemyPatrol[] enemyPatrols;
    public GameObject[] extraTraps;
    public GameObject[] rewardItems;

    public float easyEnemySpeed = 1.5f;
    public float normalEnemySpeed = 2.5f;
    public float hardEnemySpeed = 3.5f;

    public KeyCode easyKey = KeyCode.Alpha1;
    public KeyCode normalKey = KeyCode.Alpha2;
    public KeyCode hardKey = KeyCode.Alpha3;
    public KeyCode reportKey = KeyCode.R;

    private int difficultyLevel = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(easyKey) == true)
        {
            ApplyEasyDifficulty();
        }

        if (Input.GetKeyDown(normalKey) == true)
        {
            ApplyNormalDifficulty();
        }

        if (Input.GetKeyDown(hardKey) == true)
        {
            ApplyHardDifficulty();
        }

        if (Input.GetKeyDown(reportKey) == true)
        {
            PrintDifficultyReport();
        }

        if (Input.GetKeyDown(KeyCode.Alpha7) == true)
        {
            CircularDifficultyChange();
        }
    }

    void ApplyEasyDifficulty()
    {
        difficultyLevel = 0;

        SetEnemySpeed(easyEnemySpeed);
        SetActiveState(extraTraps, false);
        SetActiveState(rewardItems, true);

        Debug.Log("쉬운 상태를 적용했습니다.");
    }

    void ApplyNormalDifficulty()
    {
        difficultyLevel = 1;

        SetEnemySpeed(normalEnemySpeed);
        SetActiveState(extraTraps, true);
        SetActiveState(rewardItems, true);

        Debug.Log("보통 상태를 적용했습니다.");
    }

    void ApplyHardDifficulty()
    {
        difficultyLevel = 2;

        SetEnemySpeed(hardEnemySpeed);
        SetActiveState(extraTraps, true);
        SetActiveState(rewardItems, false);

        Debug.Log("어려운 상태를 적용했습니다.");
    }

    void SetEnemySpeed(float newSpeed)
    {
        for (int i = 0; i < enemyPatrols.Length; ++i)
        {
            enemyPatrols[i].moveSpeed = newSpeed;
        }
    }

    void SetActiveState(GameObject[] targetObjects, bool activeState)
    {
        for (int i = 0; i <  targetObjects.Length; ++i)
        {
            if (targetObjects[i] == null) continue;
            targetObjects[i].SetActive(activeState);
        }
    }

    void PrintDifficultyReport()
    {
        int activeTrapCount = CountActiveObjects(extraTraps);
        int activeItemCount = CountActiveObjects(rewardItems);

        Debug.Log("현재 설정 단계: " + difficultyLevel);
        Debug.Log("활성 함정 수: " + activeTrapCount);
        Debug.Log("활성 아이템 수: " + activeItemCount);
    }

    int CountActiveObjects(GameObject[] targetObjects)
    {
        int activeCount = 0;

        for (int i = 0; i < targetObjects.Length; ++i)
        {
            if (targetObjects[i] == null) continue;

            if (targetObjects[i].activeSelf == true)
            {
                activeCount++;
            }
        }

        return activeCount;
    }

    void CircularDifficultyChange()
    {
        if (difficultyLevel == 0)
        {
            difficultyLevel++;
            ApplyNormalDifficulty();
        }
        else if (difficultyLevel == 1)
        {
            difficultyLevel++;
            ApplyHardDifficulty();
        }
        else
        {
            difficultyLevel = 0;
            ApplyEasyDifficulty();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player;
        player = other.GetComponent<PlayerController>();

        if (player == null)
        {
            return;
        }

        difficultyLevel = 2;
        ApplyHardDifficulty();
    }
}
