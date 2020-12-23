using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void PlayButtonAction()
    {
        SceneManager.LoadScene("LoadScreen");
        GamePersistantData.persistantData.CurrentGameLives = 3;
        
    }

    public void QuitButtonAction()
    {
        Application.Quit();   
    }

    public void SettingsButtonAction()
    {
    //TODO: show settings screen
    
    }

}
