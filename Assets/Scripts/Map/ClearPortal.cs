using UnityEngine;

public class ClearPortal : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("게임 클리어!");
        gameManager.LoadClaerScene();
    }
}
