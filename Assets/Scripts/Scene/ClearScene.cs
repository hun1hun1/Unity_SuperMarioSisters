using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScene : MonoBehaviour
{
    public string startSceneName = "StartScene";
    public string playSceneName = "PlayScene";

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene(playSceneName);
        Debug.Log(playSceneName + "으로 씬을 전환합니다.");
    }

    public void OnClickGoToStartButton()
    {
        SceneManager.LoadScene(startSceneName);
        Debug.Log(startSceneName + "으로 씬을 전환합니다.");
    }
}
