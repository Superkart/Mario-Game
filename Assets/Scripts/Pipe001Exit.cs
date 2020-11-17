using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe001Exit : MonoBehaviour
{
    
    public GameObject FadeScreen;
    public GameObject MainCam;
    public GameObject SecondCam;
    public GameObject MainPlayer;
    public AudioSource PipeSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        StartCoroutine(ChangePlayerPosition());
    }

    IEnumerator ChangePlayerPosition()
    {
        PipeSound.Play();
        FadeScreen.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(0.5f);
        MainCam.SetActive(true);
       
        SecondCam.SetActive(false);
        MainPlayer.transform.localPosition = new Vector3(39.84f, 8.48f, MainPlayer.transform.localPosition.z);
    }

}
