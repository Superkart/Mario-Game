using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public AudioSource CollectSound;

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
        CollectSound.Play();
        transform.position = new Vector3(0, -1000, 0);
        GlobalCoins.CoinCount += 1;
        
    }
}
