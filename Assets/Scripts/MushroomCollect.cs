using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomCollect : MonoBehaviour
{
    public AudioSource GrowSound;
    public GameObject ThePlayer;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            this.transform.position = new Vector3(0, -1000, 0);
            GrowSound.Play();
            int gameLives = GamePersistantData.GetPersistantData().CurrentGameLives;
            GamePersistantData.GetPersistantData().CurrentGameLives = ++gameLives;
        }
        
    }

}
