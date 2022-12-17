using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMushroomMoveFirst : MonoBehaviour
{
    public AudioSource GrowSound;
    public float AnimSpeed = 0.3f;
    Vector3 targetpos;


    private void Start()
    {
        targetpos = this.transform.position + Vector3.up *1;    
        
    }

    void Update()
    {
        if(this.transform.position.y < targetpos.y)
       this.gameObject.transform.Translate(Vector3.up * 2 * Time.deltaTime *AnimSpeed ,Space.World);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            GrowSound.Play();
            int gameLives = GamePersistantData.GetPersistantData().CurrentGameLives;
            GamePersistantData.GetPersistantData().CurrentGameLives = ++gameLives;
            GameObject.Destroy(this.gameObject);
        }

    }

}
