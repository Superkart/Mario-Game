using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public Text LivesText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LivesText != null)
        {
            LivesText.text = "Lives: "+GamePersistantData.GetPersistantData().CurrentGameLives.ToString(); 
        }
    }
}
