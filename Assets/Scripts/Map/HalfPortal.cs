using UnityEngine;

public class HalfPortal : MonoBehaviour
{
    public GameObject stopWall;
    public GameObject leftArrow;
    public GameObject rightArrow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stopWall.SetActive(false);
        leftArrow.GetComponent<SpriteRenderer>().enabled = false;
        rightArrow.GetComponent<SpriteRenderer>().enabled = true;
    }
}
