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

        //Creates a new DropDownlist
        List<string> DropDownOptions = new List<string>();

        //Length of the whole path
        int pathlength = path.Length;

        //Lists all files 
        foreach (string file in System.IO.Directory.GetFiles(path))
        {

          //Listing just the Rawmodels ending in .raw
          if (file.EndsWith(".raw"))
            {

                // removes the path and just leaves "Name.raw" 
                string file2 = file.Remove(0, pathlength);
                file2 = file2.Remove(file2.Length - 4, 4);
                //Adds the Names of the Models to the DropDownLists 
                DropDownOptions.Add(file2);
              
            }

            



        }

        // Adds the List to the DropDown as available options

        dropdown.AddOptions(DropDownOptions);



    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
