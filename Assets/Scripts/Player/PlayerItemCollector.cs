using UnityEngine;

public class PlayerItemCollector : MonoBehaviour
{
    public int totalScore = 0;
    public PlayerScore playerScore;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DoorKey key;
        key = other.GetComponent<DoorKey>();
        CollectibleItem item;
        item = other.GetComponent<CollectibleItem>();

        if (key != null)
        {
            key.Collect();
        }
        else
        {
            if (item == null)
            {
                return;
            }

            AddScore(item.GetScoreValue());
            item.Collect();
        }
    }

    //public void AddScore(int scoreAmount)
    //{
    //    totalScore = totalScore + scoreAmount;
    //    Debug.Log("현재 점수: " + totalScore);
    //    UpdateScoreText();
    //}

    public void AddScore(int scoreAmount)
    {
        playerScore.CheckScore(scoreAmount);
    }

    //void UpdateScoreText()
    //{
    //    if (scoreText == null)
    //    {
    //        Debug.Log("점수 UI가 연결되지 않았습니다.");
    //        return;
    //    }

    //    scoreText.text = "Score: " + totalScore;
    //}
}
