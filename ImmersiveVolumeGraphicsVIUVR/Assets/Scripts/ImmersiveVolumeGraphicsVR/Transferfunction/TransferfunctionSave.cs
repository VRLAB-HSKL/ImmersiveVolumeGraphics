using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityVolumeRendering;
using ImmersiveVolumeGraphics.ModelImport;
namespace ImmersiveVolumeGraphics
{
    namespace Transferfunctions
    {

        public class TransferfunctionSave : MonoBehaviour
        {
        
            public void SaveTransferFunction()
            {
              
                
                VolumeRenderedObject volumeObject = GameObject.FindObjectOfType<VolumeRenderedObject>();
                if (volumeObject != null)
                {
                    string filePath = Application.dataPath + "/StreamingAssets/TransferFunctions/" + LoadModelPath.Path + ".tf";

                    TransferFunction newTF = volumeObject.transferFunction;
                    if (filePath != "")
                        TransferFunctionDatabase.SaveTransferFunction(newTF, filePath);

                }


            }



        }
    }
}

