using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ImmersiveVolumeGraphics {

    namespace Transferfunctions
    {
        public class TransferfunctionDropDown : MonoBehaviour
        {


            public Dropdown DropDown;



            // Start is called before the first frame update
            void Start()
            {

                AddDropDownList();


            }

            public  void  AddDropDownList()
            {
                string path = "" + Application.dataPath + "/StreamingAssets/TransferFunctions/";


                //Creates a new DropDownlist
                List<string> DropDownOptions = new List<string>();

                //Length of the whole path
                int pathlength = path.Length;

                //Reset
                DropDown.ClearOptions();
                

                    //Lists all files 
                    foreach (string file in System.IO.Directory.GetFiles(path))
                    {

                        //Lists all Transferfunctions
                        if (file.EndsWith(".tf"))
                        {

                            // removes the path and just leaves "Name.tf" 
                            string file2 = file.Remove(0, pathlength);
                            file2 = file2.Remove(file2.Length - 3, 3);
                            //Adds the Names of the Transferfunctions to the DropDownLists 
                            DropDownOptions.Add(file2);

                        }





                    }

                    // Adds the List to the DropDown as available options

                    DropDown.AddOptions(DropDownOptions);
               

            }


           

        }
    }


}


