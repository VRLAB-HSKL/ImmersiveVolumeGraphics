﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering
{

  

    public class LoadModelPath : MonoBehaviour
{
        public Dropdown dropdown;

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void LoadPath()
        {

            ImportRAWModel.setModelPath(dropdown.options[dropdown.value].text);
                Debug.Log("Path loaded");


       






        }





    }

}
