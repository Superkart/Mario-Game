using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeMushroomMoveScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ChildPhysicsBody = null;
    void Start()
    {
        var rb = this.GetComponentInChildren<Rigidbody>();
        rb.AddForce(100f, 0f, 0f);        
    }

    // Update is called once per frame
    void Update()
    {
      //  this.transform.position = ChildPhysicsBody.transform.position;
    }
}
