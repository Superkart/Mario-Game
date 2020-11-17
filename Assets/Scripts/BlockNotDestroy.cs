using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockNotDestroy : MonoBehaviour
{
   


    // Start is called before the first frame update
    public void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public IEnumerator OnTriggerEnter(Collider col)
    {
        float x_pos = transform.position.x;
        float y_pos = transform.position.y;
        float z_pos = transform.position.z;
        transform.GetComponent<Collider>().isTrigger = false;
        if(col.gameObject.tag == "Player")
        {
            
            this.transform.position = new Vector3(x_pos, y_pos + 0.2f, z_pos);
            yield return new WaitForSeconds(0.08f);
            this.transform.position = new Vector3(x_pos, y_pos ,z_pos);
            yield return new WaitForSeconds(0.25f);
            transform.GetComponent<Collider>().isTrigger = true;

        }
        
    }
}
