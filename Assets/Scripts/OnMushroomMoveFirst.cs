using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMushroomMoveFirst : MonoBehaviour
{
    public GameObject ActualMushroom;
    public GameObject ThisMushroom;

     void Update()
    {
        transform.parent = null;
        ThisMushroom.transform.Translate(Vector3.up * 2 * Time.deltaTime ,Space.World);
        CloseAnimation();
        ThisMushroom.SetActive(false);
        ActualMushroom.SetActive(true);
    }

    IEnumerator CloseAnimation()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
