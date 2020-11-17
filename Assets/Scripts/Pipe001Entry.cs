using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe001Entry : MonoBehaviour
{
    public GameObject PipeEntry;
    public int StoodOn;
    public GameObject MainCam;
    public GameObject SecondCam;
    public GameObject MainPlayer;
    float waiting = 0.5f;
    public GameObject FadeScreen;
    public AudioSource PipeSound;



    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("GoDown"))
        {
            if (StoodOn == 1)
            {

                transform.position = new Vector3(0, -1000, 0);
                PipeEntry.GetComponent<Animator>().SetBool("GoDown", true);
                
                StartCoroutine(Waiting());
            }
        }

    }

    IEnumerator Waiting()
    {
        PipeSound.Play();
        FadeScreen.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(waiting);
        
        SecondCam.SetActive(true);
        MainCam.SetActive(false);
       
        MainPlayer.transform.localPosition = new Vector3(12.5f, -3.75f, -1.75f);
    }



    void OnTriggerEnter(Collider col)
    {
        StoodOn = 1;

    }
    void OnTriggerExit(Collider col)
    {
        StoodOn = 0;

    }
}
