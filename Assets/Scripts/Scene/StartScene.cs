using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public string playSceneName = "PlayScene";

    public void OnClickStartButton()
    {
        SceneManager.LoadScene(playSceneName);
        Debug.Log(playSceneName + "으로 씬을 전환합니다.");
    }
}
