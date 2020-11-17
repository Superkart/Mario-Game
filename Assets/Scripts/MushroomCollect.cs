﻿using System.Collections;
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
            ThePlayer.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
        }
        
    }

}