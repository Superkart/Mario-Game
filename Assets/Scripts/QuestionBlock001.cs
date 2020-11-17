using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock001 : MonoBehaviour
{
    public GameObject QuestionBlock;
    public GameObject DeadBlock;
    public GameObject Mushroom;
    

    public void OnTriggerEnter(Collider col)
    {
        QuestionBlock.SetActive(false);
        DeadBlock.SetActive(true);
        Wait();
        Mushroom.SetActive(true);
        

        
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);

    }
}
