using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.R))
        {
            // reset game

            SceneManager.LoadScene("Level 1");
        }
    }
}
