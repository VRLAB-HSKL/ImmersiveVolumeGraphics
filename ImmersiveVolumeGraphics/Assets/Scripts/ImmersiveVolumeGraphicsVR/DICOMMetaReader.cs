using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;


namespace UnityVolumeRendering {
    public class DICOMMetaReader : MonoBehaviour
    {

        // Array of all  metainformation eg. patien´s name , modality etc.
        // Only reasonable information is included
        private static string[] metainfo = new string[38];
        // Textfield which show the metainformation to the user 
        public static Text t;
        // This value represents the thickness of each slice made in the computer tomograph in Millimeter eg. 1.0 = 1 mm thickness
        private static float slicethickness=0;


        // Start is called before the first frame update
        void Start()
        {
        // Finding the text in the scene 
            t = GameObject.Find("MetaInfoLabel").GetComponent<Text>();

        }





        public static void ReadDICOMMetaInfo()
        {
            // The path to the meta information (saved as a text file) based on the model.
            //The model´s path or name is loaded when the user clicks on dropdown element
            // For Example : string path = Application.dataPath + "/StreamingAssets/" + "Male_Head.metainfo" + ".txt";
            string path = Application.dataPath + "/StreamingAssets/" + ImportRAWModel.ModelPath + ".txt";
          
            
            
           // Resets when you change the model

            slicethickness = 0;
            t.text = "";

            // check if the model has a corresponding metainfo file
            bool FileValid = IsFileValid(path);

            // When the File exists 
            if (FileValid)
            {
                //StreamReader reads the meta-information of the text file 
                StreamReader streamReader = new StreamReader(path);

                // Safety check
                if (streamReader != null)
                {

                    // the first 19 lines are not that important for a user. 
                    // moving through the textfile

                    //Displaying additional Information
                    metainfo[0] = "patientname  :   ";
                    metainfo[2] = "patientid    :   ";
                    metainfo[4] = "patientbirthdate :   ";
                    metainfo[6] = "patientsex   :   ";
                    metainfo[8] = "institutionname  :   ";
                    metainfo[10] = "institutionaddress  :   ";
                    metainfo[12] = "physicianname   :   ";
                    metainfo[14] = "studydiscription    :   ";
                    metainfo[16] = "modality    :   ";
                    metainfo[18] = "manufacturer    :   ";
                    metainfo[20] = "studyid     :   ";
                    metainfo[22] = "studydate   :   ";
                    metainfo[24] = "seriesnumber    :   ";
                    metainfo[26] = "pixelspacing    :   ";
                    metainfo[28] = "slicethickness  :   ";
                    metainfo[30] = "columns :   ";
                    metainfo[32] = "rows    :   ";
                    metainfo[34] = "patientposition     :   ";
                    metainfo[36] = "imageorientationpatient     :   ";
                   

                    for (int i = 1; i < metainfo.Length; i+=2)
                    {
                        metainfo[i]=streamReader.ReadLine();

                        t.text += metainfo[i-1] +metainfo[i] + "\n";
                    }



                    slicethickness = float.Parse(metainfo[29]);
                    //Parse the slicethickness from element 25 of the array and divide it by 10 because of float conversion
                    //  slicethickness = int.Parse(metainfo[15]);

                    t.text += slicethickness;


                }
              
            }
        }



        // Approach
        // The data is structured like a table
        // On the left side is a tag and the name of the value
        // On the right side are some letters and the actual value
        // eg. (0018, 0050) Slice Thickness                     DS: "1.0"
        // 


        // Left column , name eg. : Slice Thickness 

       

        // getter-Method 
        public static float getThickness()
        {

            return slicethickness;
        
        }

        // Checks if the File exists or not 
        private static bool IsFileValid(string filePath)
        {
            bool IsValid = true;

            if (!File.Exists(filePath))
            {
                IsValid = false;
            }
            else if (Path.GetExtension(filePath).ToLower() != ".txt")
            {
                IsValid = false;
            }

            return IsValid;
        }


    }

}