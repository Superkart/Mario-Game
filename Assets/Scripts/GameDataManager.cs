using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public Transform spawnpoint;
    private static GameDataManager myInstance = null;
    public void Awake()
    {// if the singleton hasn't been initialized yet
         if (myInstance != null && myInstance != this) 
         {
             Destroy(this.gameObject);
         }
 
         myInstance = this;
         DontDestroyOnLoad( this.gameObject );

    }
    public static GameDataManager getGameDataManager()
    {
    return myInstance;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
