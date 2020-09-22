using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Hosting;
using System;
using UnityEngine.UI;

namespace UnityVolumeRendering { 
public class DICOMMetaReader : MonoBehaviour
{

        private string[] metainfo = new string[14];
        public Text t;

    // Start is called before the first frame update
    void Start()
    {
            //ReadDICOMMetaInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }



        public  void ReadDICOMMetaInfo()
        {
            //string path = Application.dataPath + "/StreamingAssets/" + LoadModelPath.path + ".txt";
            string path = Application.dataPath + "/StreamingAssets/" + ImportRAWModel.ModelPath+ ".metainfo.txt";
            //string path = Application.dataPath + "/StreamingAssets/" + "Male_Head.metainfo" + ".txt";

            StreamReader streamReader = new StreamReader(path);
            if (streamReader != null)
            {
                for (int i = 0; i < 17; i++)
                {
                    streamReader.ReadLine();
                }


                //string mod = streamReader.ReadLine();
                //mod= mod.Remove(0,12);
                // mod = mod.Remove(49, 3);
                //mod = mod.Remove(0,12);

                // t.text = CutString(mod);

                for (int i = 0; i < 13; i++)
                {

                    string mod = streamReader.ReadLine();
                    metainfo[i] = CutString(mod);
                    t.text += metainfo[i] + "\n";

                }



            }
        }

            private string CutString(string basestring)
            {

                basestring = basestring.Remove(49, 3);
                basestring = basestring.Remove(0, 12);

                return basestring;


            }

        }
     


}