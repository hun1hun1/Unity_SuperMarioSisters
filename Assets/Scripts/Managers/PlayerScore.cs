using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int totalScore = 0;
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateScoreText();
    }

    public void CheckScore(int scoreAmount)
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
