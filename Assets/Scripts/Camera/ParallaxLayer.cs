using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public Transform cameraTransform;
    public float parallaxRatio = 0.3f;

    private Vector3 previousCameraPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        previousCameraPosition = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraMove = cameraTransform.position - previousCameraPosition;
        Vector3 backgroundMove = cameraMove * parallaxRatio;
        backgroundMove.y = cameraMove.y;
        backgroundMove.z = 0.0f;

        transform.position = transform.position + backgroundMove;
        previousCameraPosition = cameraTransform.position;
    }
}
