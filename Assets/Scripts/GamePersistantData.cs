using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePersistantData : MonoBehaviour
{

    public static GamePersistantData persistantData = null;

    [SerializeField]
    int GameLives = 3;
    public int CurrentGameLives { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        persistantData = this;
        CurrentGameLives = 3;
    }


    public static GamePersistantData GetPersistantData() 
    {
        if (persistantData == null)
        {
            var go = new GameObject("PersistantGameData");
            go.AddComponent<GamePersistantData>();
        }
        return persistantData;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
