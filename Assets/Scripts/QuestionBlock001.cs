using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock001 : MonoBehaviour
{
    public GameObject QuestionBlock;
    public GameObject DeadBlock;
    public GameObject Mushroom;
    bool _isBlockActivated = false;

    public void OnTriggerEnter(Collider col)
    {
        if(!_isBlockActivated)
            StartCoroutine(ActivateBlock());
    }

    IEnumerator ActivateBlock()
    {
        _isBlockActivated = true;
        QuestionBlock.SetActive(false);
        DeadBlock.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        Mushroom.SetActive(true);
    }

    
}
