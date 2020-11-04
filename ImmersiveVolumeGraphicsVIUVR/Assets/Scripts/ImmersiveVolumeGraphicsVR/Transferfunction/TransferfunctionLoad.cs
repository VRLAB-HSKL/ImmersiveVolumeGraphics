using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering { 
public class TransferfunctionLoad : MonoBehaviour
{
        public Dropdown dropdown;
        public Button btn;
        public string filepath;
        VolumeRenderedObject volobj;
        private Material SliceRendererMat = null;
        /*
         void Start()
        {
            btn.onClick.AddListener(load);
        } */




        public void load() {

         //Path in the Project for the Transferfunctions
         filepath = Application.dataPath + "/TransferFunctions/" + dropdown.options[dropdown.value].text+".tf";

           

            //Finding our VolumeObject
             volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();

             


            if (volobj != null)
            {
                if (filepath != "")
                {
                   //Helperfunction of the UnityVolumeRendering-Project to Load the Transferfunction
                    TransferFunction newTF = TransferFunctionDatabase.LoadTransferFunction(filepath);
                    if (newTF != null)
                        //Sets the new Transferfunction for our VolumeObject
                        volobj.transferFunction = newTF;
                    //Update to Render 1 dimensional Transferfunctions
                    volobj.SetTransferFunctionMode(TFRenderMode.TF1D);


                    //Updates Histogramm and Transferfunctionviewer according to newest Transferfunction
                    Histogramm.LoadHistogramm();

                    /*
                    GameObject ImageViewer = GameObject.Find("ImageViewer1");
                    GameObject ImageViewer2 = GameObject.Find("ImageViewer2");
                    GameObject ImageViewer3 = GameObject.Find("ImageViewer3");

                    ImageViewer.GetComponent<MeshRenderer>().material.SetTexture("_TFTex", newTF.GetTexture());
                    ImageViewer2.GetComponent<MeshRenderer>().material.SetTexture("_TFTex", newTF.GetTexture());
                    ImageViewer3.GetComponent<MeshRenderer>().material.SetTexture("_TFTex", newTF.GetTexture());
                    */

                    //Find the Slicing Planes
                    GameObject SlicingPlane1 = GameObject.Find("SlicingPlane1");
                    GameObject SlicingPlane2 = GameObject.Find("SlicingPlane2");
                    GameObject SlicingPlane3 = GameObject.Find("SlicingPlane3");

                    //Sets new Texture to SlicingPlanes' Material 
                    SlicingPlane1.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_TFTex", newTF.GetTexture());
                    SlicingPlane2.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_TFTex", newTF.GetTexture());
                    SlicingPlane3.GetComponent<MeshRenderer>().sharedMaterial.SetTexture("_TFTex", newTF.GetTexture());



                }
            }





        }



}


}