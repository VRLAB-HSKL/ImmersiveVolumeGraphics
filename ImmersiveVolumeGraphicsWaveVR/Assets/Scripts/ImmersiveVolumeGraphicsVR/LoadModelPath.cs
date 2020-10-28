using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering
{

   

    public class LoadModelPath : MonoBehaviour
    {
        public Dropdown dropdown;
        public static  string path;
        // Start is called before the first frame update
   

        public void LoadPath()
        {
            //Sets the model´s path 
            ImportRAWModel.setModelPath(dropdown.options[dropdown.value].text);
            //

            path = dropdown.options[dropdown.value].text;
           //Reads the MetaInformation in 
            DICOMMetaReader.ReadDICOMMetaInfo();
            Debug.Log("Path + MetaInfo loaded");
        }

        //setter-Method for the path variable
        public void  setPath(string location)
        {

            path = location;


        }





    }

}
