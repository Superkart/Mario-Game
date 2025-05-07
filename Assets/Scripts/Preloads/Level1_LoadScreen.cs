using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_LoadScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadScene());    
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    
}
