using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform DestinationTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO:: Teleport the player to destinationPosition

        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.localPosition = DestinationTransform.position;
        }
    }
}
