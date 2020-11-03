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
        private static string[] metainfo = new string[50];
        // Textfield which show the metainformation to the user 
        public static Text t;



        //DICOM-DATA
        // This value represents the thickness of each slice made in the computer tomograph in Millimeter eg. 1.0 = 1 mm thickness
        private static float pixelspacingx = 0;
        private static float pixelspacingy = 0;
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
            pixelspacingx = 0;
            pixelspacingy = 0;
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
                    metainfo[26] = "pixelspacingx    :   ";
                    metainfo[28] = "pixelspacingy  :   ";
                    metainfo[30] = "slicethickness  :   ";
                    metainfo[32] = "columns :   ";
                    metainfo[34] = "rows    :   ";
                    metainfo[36] = "patientposition     :   ";
                    metainfo[38] = "imageorientationpatientrowx     :   ";
                    metainfo[40] = "imageorientationpatientrowy     :   ";
                    metainfo[42] = "imageorientationpatientrowz     :   ";
                    metainfo[44] = "imageorientationpatientcolumnx     :   ";
                    metainfo[46] = "imageorientationpatientcolumny     :   ";
                    metainfo[48] = "imageorientationpatientcolumnz     :   ";

                    for (int i = 1; i < metainfo.Length; i+=2)
                    {
                        metainfo[i]=streamReader.ReadLine();

                        
                       if (i <= 25)
                        {
                            t.text += metainfo[i - 1] + metainfo[i] + "\n";



                        }
                        





                    }


                    //Parsing the incoming DICOM-Data into unity 


                    //Converting  -> dot to  comma because of float parse (american vs european way of writing floats)
                    metainfo[27]= metainfo[27].Replace(".",",");
                    metainfo[29]= metainfo[29].Replace(".", ",");
                    metainfo[31]= metainfo[31].Replace(".", ",");

  
                    pixelspacingx = float.Parse(metainfo[27]);
                    pixelspacingy= float.Parse(metainfo[29]);
                    slicethickness = float.Parse(metainfo[31]);


                  
                    t.text += metainfo[26]+pixelspacingx +" mm"+"\n"; ;
                    t.text += metainfo[28]+pixelspacingy +" mm"+ "\n"; ;
                    t.text += metainfo[30]+slicethickness +" mm"+"\n"; ;


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


        public static float getPixelSpacingX()
        {

            return pixelspacingx;

        }

        public static float getPixelSpacingY()
        {

            return pixelspacingy;

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