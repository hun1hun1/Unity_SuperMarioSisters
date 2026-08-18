using UnityEngine;

public class RespawnPlatform : MonoBehaviour
{
    public MovingPlatform[] platformList1;
    public DisappearingPlatform[] platformList2;

    public void RespawnListedPlatform()
    {
        foreach (MovingPlatform platform in platformList1)
        {
            platform.GoToStart();
        }

        foreach (DisappearingPlatform platform in platformList2)
        {
            platform.GoToStart();
        }
    }
}
