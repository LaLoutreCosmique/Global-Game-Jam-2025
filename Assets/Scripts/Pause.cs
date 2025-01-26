using UnityEngine;

public class Pause : MonoBehaviour
{   
    private bool paused;
    [SerializeField] private Canvas pauseCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paused = false;
        pauseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            if (paused) PauseGame();
            else ResumeGame();
            
        }
        
    }

    public void PauseGame()
    {
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
