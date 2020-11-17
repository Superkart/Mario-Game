﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseCanvas.SetActive(true);
           
        }

    }

    
    
         public void ResumeButtonAction()
        {
            PauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
        public void QuitButtonAction()
        {
        Application.Quit();
        }





}