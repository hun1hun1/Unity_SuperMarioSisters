using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0.0f, 0.0f, -10.0f);

    public float followSpeed = 5.0f;

    private Vector3 targetPosition;

    public bool followY = true;

    private void LateUpdate()
    {
        PrintFollowInfo();

        targetPosition = target.position + offset;

        if (followY == false)
        {
            targetPosition.y = transform.position.y;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }

    void PrintFollowInfo()
    {
        if (Input.GetKeyDown(KeyCode.F) == true)
        {
            if (target == null)
            {
                Debug.Log("타겟이 없습니다.");
                return;
            }
            else
            {
                Debug.Log("카메라 위치: " + transform.position);
                Debug.Log("타겟 위치: " + target.position);
                Debug.Log("오프셋 값: " + offset);
            }
        }
    }
}
