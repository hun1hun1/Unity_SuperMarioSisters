using UnityEngine;
using System.Collections.Generic;

public class StageCollectionReporter : MonoBehaviour
{
    public GameObject[] itemObjects;
    public List<GameObject> enemyObjects = new List<GameObject>();

    public KeyCode itemPrintKey = KeyCode.I;
    public KeyCode enemyPrintKey = KeyCode.E;
    public KeyCode activeCountKey = KeyCode.C;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PrintSummary();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(itemPrintKey) == true)
        {
            PrintItemNames();
        }

        if (Input.GetKeyDown(enemyPrintKey) == true)
        {
            PrintEnemyNames();
        }

        if (Input.GetKeyDown(activeCountKey) == true)
        {
            PrintActiveEnemyCount();
        }

        PrintItemVariation();
        DisActiveAllItems();
    }

    void PrintSummary()
    {
        Debug.Log("아이템 배열 개수: " + itemObjects.Length);
        Debug.Log("적 List 개수: " + enemyObjects.Count);
    }

    void PrintItemNames()
    {
        // 0 부터 시작해서 i가 3보다 작을 동안 계속 반복 수행.
        // 중괄호 안의 코드를 한 번 실행한 후 i를 1 증가시킴. -> i = 1
        // 중괄호 안의 코드를 또 한 번 실행한 후 i를 1 증가시킴. -> i = 2
        // 중괄호 안의 코드를 또 한 번 실행한 후 i를 1 증가시킴. -> i = 3
        for (int i = 0; i < itemObjects.Length; ++i)
        {
            Debug.Log("아이템 " + i + ": " + itemObjects[i]);
        }
    }

    void DisActiveAllItems()
    {
        if (Input.GetKeyDown(KeyCode.P) == true)
        {
            for (int i = 0; i < itemObjects.Length; ++i)
            {
                if (itemObjects[i] != null) itemObjects[i].SetActive(false);
            }
        }
    }

    void PrintItemVariation()
    {
        int activeItemCount = 0;
        int emptyCount = 0;
        int notActiveItemCount = 0;

        for (int i = 0; i < itemObjects.Length; ++i)
        {
            if (itemObjects[i] != null)
            {
                if (itemObjects[i].activeSelf == true)
                {
                    activeItemCount++;
                }
                else
                {
                    notActiveItemCount++;
                }
            }
            else
            {
                emptyCount++;
            }
        }

        if (Input.GetKeyDown(KeyCode.J) == true)
        {
            Debug.Log("연결된 아이템 개수: " + (activeItemCount + notActiveItemCount));
            Debug.Log("비어 있는 칸 개수: " + emptyCount);
        }

        if (Input.GetKeyDown(KeyCode.K) == true)
        {
            Debug.Log("활성 아이템 개수: " + activeItemCount);
        }
    }

    void PrintEnemyNames()
    {
        foreach(GameObject enemyObject in enemyObjects)
        {
            Debug.Log("적 이름: " + enemyObject.name);
        }
    }

    void PrintActiveEnemyCount()
    {
        int activeCount = 0;

        foreach (GameObject enemyObject in enemyObjects)
        {
            if (enemyObject.activeSelf == true)
            {
                activeCount++;
            }
        }

        Debug.Log("활성 적 개수: " + activeCount);
    }
}
