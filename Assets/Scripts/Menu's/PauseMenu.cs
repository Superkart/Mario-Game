using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    [SerializeField] private AudioSource backgroundMusic;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            backgroundMusic.Pause();
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
           
        }

    }

    
    public void ResumeButtonAction()
    {
        PauseCanvas.SetActive(false);
        backgroundMusic.UnPause();
        Time.timeScale = 1;
    }
    public void QuitButtonAction()
    {
        Application.Quit();
    }

    public void MainMenuButtonAction()
    {
        backgroundMusic.Stop();
        SceneManager.LoadScene(0); // Loading the main menu    
    }




}
