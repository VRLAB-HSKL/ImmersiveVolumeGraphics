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



        string path = "" + Application.dataPath + " /StreamingAssets/ ";

     

        List<string> DropDownOptions = new List<string>();
      

        foreach (string file in System.IO.Directory.GetFiles(path))
        {

            // Nur Modelle werden gelistet 

            if (file.EndsWith(".raw"))
            {
                //Testen
                //Debug.Log(file);

                //Entfernt den Pfad aus dem Namen
                // für Buildversion    string file2 = file.Remove(0,100);
                // für Editorversion    string file2 = file.Remove(0,97);
                string file2 = file.Remove(0, 97);
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
