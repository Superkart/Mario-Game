using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    float waiting = 0.02f;
    // Start is called before the first frame update
    void Start()
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
        if (col.gameObject.tag == "Player")
        {

            this.transform.position = new Vector3(x_pos, y_pos + 0.1f, z_pos);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(x_pos, y_pos + 0.2f, z_pos);
            yield return new WaitForSeconds(waiting);
            transform.GetComponent<Collider>().isTrigger = false;
            this.transform.position = new Vector3(x_pos, y_pos + 0.3f, z_pos + 0.5f);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(x_pos, y_pos + 0.4f, z_pos + 1.0f);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(x_pos, y_pos - 0.1f, z_pos + 1.5f);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(x_pos, y_pos - 0.6f, z_pos + 2.0f);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(x_pos, y_pos - 1.6f, z_pos + 2.0f);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(x_pos, y_pos - 2.6f, z_pos + 2.0f);
            yield return new WaitForSeconds(waiting);
            this.transform.position = new Vector3(x_pos, y_pos - 4.0f, z_pos + 2.0f);
            yield return new WaitForSeconds(0.25f);
            transform.GetComponent<Collider>().isTrigger = true;
            Destroy(gameObject);



        }
    }
}
