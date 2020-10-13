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
        private static string[] metainfo = new string[28];
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

                    // the first 17 lines are not that important for a user. 
                    // moving through the textfile
                    for (int i = 0; i < 17; i++)
                    {
                        streamReader.ReadLine();
                    }


                    // This counter is needed to get two values per line.  
                    int ctr = 0;

                    //Moving through the important parts of the textfile
                    for (int i = 0; i < 13; i++)
                    {
                        // Read the line
                        string mod = streamReader.ReadLine();

                        // Cut the line into Part 1
                        metainfo[ctr] = CutString1(mod);
                        // Add the information to the textelement
                        t.text += metainfo[ctr];
                        // Increase the counter for the next Element
                        ctr++;
                        // Formating
                        t.text += "\n";



                        // Cut the line into Part 2
                        metainfo[ctr] = CutString2(mod);
                        // Add the information to the textelement
                        t.text += metainfo[ctr];
                        // Increase the counter for the next Element
                        ctr++;
                        // Formating
                        t.text += "\n";

                        //Debug
                        // Debug.Log((ctr-2)+" "+ metainfo[ctr -2]+""+ (ctr-1) +"   "+metainfo[ctr-1]);

                    }

                    //Parse the slicethickness from element 25 of the array and divide it by 10 because of float conversion
                    slicethickness = float.Parse(metainfo[25]) / 10;

                    //Debug
                    //Debug.Log("Thickness"+slicethickness);



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

        private static string CutString1(string basestring)
        {

            // Start  eg. : (0018, 0050) Slice Thickness                     DS: "1.0"
            //Removes the tagarea :  Slice Thickness                     DS: "1.0"
            basestring = basestring.Remove(0, 12);
            // Removes the letters and value :  Slice Thickness 
            basestring = basestring.Remove(37, basestring.Length - 37);


            return basestring;


        }

        //Right Column, value eg. : 1.0

        private static string CutString2(string basestring)
        {

            // Start  eg. : (0018, 0050) Slice Thickness                     DS: "1.0"
            //Removes the left part up to the ": 1.0"
            basestring = basestring.Remove(0, 54);
            // Removes the remaining " : 1.0 
            basestring = basestring.Remove(basestring.Length-1,1);


            return basestring;


        }

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