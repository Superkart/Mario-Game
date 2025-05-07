using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void PlayButtonAction()
    {
        SceneManager.LoadScene("LoadScreen");
        GamePersistantData.GetPersistantData().CurrentGameLives = 3;
        
    }

    public void QuitButtonAction()
    {
        Application.Quit();   
    }


}
