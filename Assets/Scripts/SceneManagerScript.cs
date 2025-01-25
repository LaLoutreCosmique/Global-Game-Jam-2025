using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (sceneName == null || sceneName.Length == 0) { return; }
        SceneManager.LoadScene(sceneName);
        return;
    }
}
