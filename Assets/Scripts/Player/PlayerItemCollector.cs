using UnityEngine;
using TMPro;

public class PlayerItemCollector : MonoBehaviour
{
    public int totalScore = 0;
    public TMP_Text scoreText;

    void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollectableItem item;
        item = other.GetComponent<CollectableItem>();

        if (item == null)
        {
            return;
        }

        AddScore(item.GetScoreValue());
        item.Collect();
    }

    void AddScore(int scoreAmount)
    {
        totalScore = totalScore + scoreAmount;
        Debug.Log("현재 점수: " + totalScore);
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText == null)
        {
            Debug.Log("점수 UI가 연결되지 않았습니다.");
            return;
        }

        scoreText.text = "Score: " + totalScore;
    }
}
