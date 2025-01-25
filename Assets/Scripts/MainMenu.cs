using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas settingCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene("Game");
    }

    public void SettingsGame()
    {
        menuCanvas.gameObject.SetActive(false);
        settingCanvas.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("ExitGame");
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        settingCanvas.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
    }
}
