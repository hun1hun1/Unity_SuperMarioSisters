using UnityEngine;

public class CheckKey : MonoBehaviour
{
    public GameManager gameManager;

    private BoxCollider2D doorCollider;

    private void Start()
    {
        doorCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player;
        player = collision.gameObject.GetComponent<PlayerController>();

        if (player == null)
        {
            return;
        }

        if (gameManager.GetHasKey() == true)
        {
            doorCollider.isTrigger = true;
            Debug.Log("문이 열렸습니다.");
        }
        else
        {
            Debug.Log("문을 열려면 열쇠가 필요합니다.");
        }
    }
}
