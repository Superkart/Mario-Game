using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public AudioSource DeathSound;
    public GameObject FadeScreen;
   
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        FadeScreen.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(0.6f);
       
        int gameLives = GamePersistantData.GetPersistantData().CurrentGameLives;
        GamePersistantData.GetPersistantData().CurrentGameLives = --gameLives;

        if (gameLives == 0)
        {

            SceneManager.LoadScene("GameOver");
        }
        else
        {

            

            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void OnTriggerEnter(Collider col)
     {
        
        if (col.gameObject.tag == "Player")
         {
            DeathSound.Play();
            StartCoroutine(Wait());
            
           
            

         }

     }
}
