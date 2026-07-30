using UnityEngine;
using System.Collections.Generic;

public class StagePrefabCreator : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject enemyPrefab;

    public Transform itemSpawnPoint;
    public Transform enemySpawnPoint;

    public KeyCode createItemKey = KeyCode.Alpha1;
    public KeyCode createEnemyKey = KeyCode.Alpha2;
    public KeyCode reportKey = KeyCode.R;

    private List<GameObject> createdItems = new List<GameObject>();
    private List<GameObject> createdEnemies = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(createItemKey) == true)
        {
            // 아이템 생성.
            CreateItem();
        }

        if (Input.GetKeyDown(createEnemyKey) == true)
        {
            // 적 생성.
            CreateEnemy();
        }

        if (Input.GetKeyDown(reportKey) == true)
        {
            PrintCreatedSummary();
        }

        if (Input.GetKeyDown(KeyCode.L) == true)
        {
            DisActiveItems();
        }

        if (Input.GetKeyDown(KeyCode.O) == true)
        {
            DisActiveEnemies();
        }
    }

    void CreateItem()
    {
        if (createdItems.Count == 5)
        {
            Debug.Log("아이템은 최대 5개까지 생성");
            return;
        }
        Vector3 spawnPosition = itemSpawnPoint.position;
        spawnPosition.x += createdItems.Count * 1.5f;
        GameObject createdObject = Instantiate(itemPrefab, spawnPosition, itemSpawnPoint.rotation);

        createdItems.Add(createdObject);
        createdObject.name = "Item_" + createdItems.Count;
    }

    void CreateEnemy()
    {
        if (createdEnemies.Count == 3)
        {
            Debug.Log("적은 최대 3개까지 생성");
            return;
        }
        GameObject createdObject = Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);

        createdEnemies.Add(createdObject);
        createdObject.name = "Enemy_" + createdEnemies.Count;
    }

    void PrintCreatedSummary()
    {
        Debug.Log("생성된 아이템 수: " + createdItems.Count);
        Debug.Log("생성된 적 수: " + createdEnemies.Count);
    }

    void DisActiveItems()
    {
        foreach(GameObject item in createdItems)
        {
            if (item.activeSelf == true) item.SetActive(false);
        }
    }

    void DisActiveEnemies()
    {
        foreach (GameObject enemy in createdEnemies)
        {
            if (enemy.activeSelf == true) enemy.SetActive(false);
        }
    }

    void CreateItemAndEnemy()
    {

    }
}
