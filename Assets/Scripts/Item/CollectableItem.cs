using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public string itemName = "Coin";
    public int scoreValue = 1;

    public int GetScoreValue()
    {
        return scoreValue;
    }

    public void Collect()
    {
        Debug.Log(itemName + " æ∆¿Ã≈€¿ª »πµÊ«ﬂΩ¿¥œ¥Ÿ.");
        Destroy(gameObject);
    }
}
