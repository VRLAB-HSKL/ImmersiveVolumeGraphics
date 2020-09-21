using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class AddDropDownItems : MonoBehaviour
{


    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {

#if UNITY_EDITOR

         string path = "" + Application.dataPath + "/StreamingAssets/";

#else 
         string path = "" + Application.dataPath + "/StreamingAssets/";

#endif   

        List<string> DropDownOptions = new List<string>();

        int pathlength = path.Length;
        foreach (string file in System.IO.Directory.GetFiles(path))
        {

            // Nur Modelle werden gelistet 

          if (file.EndsWith(".raw"))
            {

               

                string file2 = file.Remove(0, pathlength);

                //Testen
                //Debug.Log(file);


                DropDownOptions.Add(file2);
              
            }

            



        }

        // Hinzufügen der Liste an Optionen
        dropdown.AddOptions(DropDownOptions);



    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
