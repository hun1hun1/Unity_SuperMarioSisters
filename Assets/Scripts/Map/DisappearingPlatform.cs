using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float visibleTime = 2.0f;
    public float hiddenTime = 1.0f;

    public SpriteRenderer platformRenderer;
    public Collider2D platformCollider;

    private float timer = 0.0f;
    public bool isVisible = true;

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime : 이전 프레임과 현재 프레임 사이의 시간 간격 -> 초 단위.
        timer += Time.deltaTime;

        // 발판을 켜기/끄기 처리.
        if (isVisible == true)
        {
            if (timer >= visibleTime * 0.5)
            {
                platformRenderer.color = Color.yellow;
            }
            else
            {
                platformRenderer.color = Color.white;
            }
            CheckVisibleTime();
        }
        else
        {
            if (timer >= hiddenTime * 0.2)
            {
                platformRenderer.color = Color.yellow;
            }
            CheckHiddenTime();
        }
    }

    void CheckVisibleTime()
    {
        if (timer >= visibleTime)
        {
            SetPlatformVisible(false);
            timer = 0.0f;
        }
    }

    void CheckHiddenTime()
    {
        if (timer >= hiddenTime)
        {
            SetPlatformVisible(true);
            platformRenderer.color = Color.white;
            timer = 0.0f;
        }
    }

    void SetPlatformVisible(bool value)
    {
        isVisible = value;
        platformRenderer.enabled = value;
        platformCollider.enabled = value;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 게임 오브젝트의 Tag가 인자로 전달한 문자열과 일치하는지 체크하는 함수.
        if (collision.gameObject.CompareTag("Player") == true)
        {
            // SetParent : 인자로 전달한 트랜스폼을 부모로 설정하는 함수.
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
