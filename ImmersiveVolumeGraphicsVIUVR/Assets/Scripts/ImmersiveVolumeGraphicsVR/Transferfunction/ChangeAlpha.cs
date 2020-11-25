using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityVolumeRendering;
using ImmersiveVolumeGraphics.Transferfunctions;
namespace ImmersiveVolumeGraphics
{
    namespace Transferfunctions
{

       

        public class ChangeAlpha : MonoBehaviour
        {




            static VolumeRenderedObject volumeObject;
            private static TransferFunction transferfunction = null;
            public  Slider AlphaSlider;
            private TFAlphaControlPoint alphaPoint = new TFAlphaControlPoint();
            private static Material tfGUIMat = null;




            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }


            public  void ChangeAlphaValue()
            {


                volumeObject = GameObject.FindObjectOfType<VolumeRenderedObject>();
                tfGUIMat = Resources.Load<Material>("TransferFunctionGUIMat");

                if (volumeObject != null &&tfGUIMat!=null)
                {
                    transferfunction = volumeObject.transferFunction;
                  

                    /*
                    for (int iAlpha = 0; iAlpha < transferfunction.alphaControlPoints.Count; iAlpha++)
                    {

                        Debug.Log("Alpha alpha   " + transferfunction.alphaControlPoints[iAlpha].alphaValue);
                        Debug.Log("Alpha datavalue   " + transferfunction.alphaControlPoints[iAlpha].dataValue);
                    }

                    for (int iAlpha = 0; iAlpha < transferfunction.colourControlPoints.Count; iAlpha++)
                    {

                        Debug.Log("Color value   " + transferfunction.colourControlPoints[iAlpha].colourValue);
                        Debug.Log("Color datavalue   " + transferfunction.colourControlPoints[iAlpha].dataValue);
                    }

                    Debug.Log(transferfunction.alphaControlPoints.Count);
                    Debug.Log(transferfunction.colourControlPoints.Count);
                    */

                    alphaPoint.alphaValue = AlphaSlider.value;
                    alphaPoint.dataValue = transferfunction.alphaControlPoints[TransferfunctionAlphaPointList.getIndex()].dataValue;
                    transferfunction.alphaControlPoints[TransferfunctionAlphaPointList.getIndex()] = alphaPoint;
                    transferfunction.GenerateTexture();
                    tfGUIMat.SetTexture("_TFTex", transferfunction.GetTexture());

                   
                    GameObject slicingPlane1 = GameObject.Find("SlicingPlane1");
                    GameObject slicingPlane2 = GameObject.Find("SlicingPlane2");
                    GameObject slicingPlane3 = GameObject.Find("SlicingPlane3");
                  
                    //Sets new Texture to SlicingPlanes' Material 
                    slicingPlane1.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_TFTex", tfGUIMat.GetTexture("_TFTex"));
                    slicingPlane2.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_TFTex", tfGUIMat.GetTexture("_TFTex"));
                    slicingPlane3.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_TFTex", tfGUIMat.GetTexture("_TFTex"));
                 

                }






            }
        }

    }

}
