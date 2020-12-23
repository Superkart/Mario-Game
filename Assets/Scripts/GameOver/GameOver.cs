using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
     void Start()
    {
        StartCoroutine(Gameover());
        
    }

    // Update is called once per frame
    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        
    }
}
