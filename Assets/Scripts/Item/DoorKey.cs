using UnityEngine;

public class DoorKey : MonoBehaviour
{
    public GameManager gameManager;

    public void Collect()
    {
        gameManager.SetHasKey();
        Debug.Log("ø≠ºË∏¶ »πµÊ«ﬂΩ¿¥œ¥Ÿ.");
        Destroy(gameObject);
    }
}
