using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace UnityVolumeRendering
{
   

    public class ImportRAWModel : MonoBehaviour
    {

        public static  string  ModelPath = "";

        // Start is called before the first frame update

        // "C:\\Users\\Marco\\Desktop\\ImmersiveVolumeGraphics\\ImmersiveVolumeGraphics\\DataFiles\\Male_Head.raw


       /* public void Import()
        {





            RawDatasetImporter importer = new RawDatasetImporter(Application.dataPath + "/StreamingAssets/"+ModelPath, 512, 512, 245, DataContentFormat.Uint16, 0, 0);
            VolumeDataset dataset = importer.Import();
            // Spawn the object
            if (dataset != null)
            {
                VolumeObjectFactory.CreateObject(dataset);
            }




        } */

        public static void setModelPath(string Path)
        {
            ModelPath = Path;


        }









         void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }


        public void OpenRAWDataset()
        {
           
                // We'll only allow one dataset at a time in the runtime GUI (for simplicity)
                DespawnAllDatasets();

                // Did the user try to import an .ini-file? Open the corresponding .raw file instead
              //  string filePath = Application.dataPath + "/StreamingAssets/" ;
                //if (System.IO.Path.GetExtension(filePath) == ".ini")
                  //  filePath = filePath.Replace(".ini", ".raw");

                // Parse .ini file
                DatasetIniData initData = DatasetIniReader.ParseIniFile(Application.dataPath + "/StreamingAssets/"+ModelPath+".ini");
                if (initData != null)
                {
                    // Import the dataset
                    RawDatasetImporter importer = new RawDatasetImporter(Application.dataPath + "/StreamingAssets/" + ModelPath, initData.dimX, initData.dimY, initData.dimZ, initData.format, initData.endianness, initData.bytesToSkip);
                    VolumeDataset dataset = importer.Import();
                    // Spawn the object
                    if (dataset != null)
                    {
                        VolumeObjectFactory.CreateObject(dataset);
                    }
                }
            
        }

        private void DespawnAllDatasets()
        {
            VolumeRenderedObject[] volobjs = GameObject.FindObjectsOfType<VolumeRenderedObject>();
            foreach (VolumeRenderedObject volobj in volobjs)
            {
                GameObject.Destroy(volobj.gameObject);
            }
        }

    }
}