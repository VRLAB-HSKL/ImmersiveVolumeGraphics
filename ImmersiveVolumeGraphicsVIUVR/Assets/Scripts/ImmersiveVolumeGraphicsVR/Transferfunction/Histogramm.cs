using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering
{

    public class Histogramm : MonoBehaviour
    {


        static VolumeRenderedObject volobj;
        private  static Material tfGUIMat = null;
        private static Texture2D histTex = null;
        private static  TransferFunction tf = null;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        //For OnClickListener
       public void CreateHistogramm()
        {

            tfGUIMat = Resources.Load<Material>("TransferFunctionGUIMat");
            volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();

            if (volobj != null)
            {
                tf = volobj.transferFunction;
                tf.GenerateTexture();
                if (histTex == null)
                    histTex = HistogramTextureGenerator.GenerateHistogramTexture(volobj.dataset);

                tfGUIMat.SetTexture("_TFTex", tf.GetTexture());
                tfGUIMat.SetTexture("_HistTex", histTex);


            }


        }


        public static void LoadHistogramm()
        {

            tfGUIMat = Resources.Load<Material>("TransferFunctionGUIMat");
            volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();

            if (volobj != null)
            {
                tf = volobj.transferFunction;
                tf.GenerateTexture();
                if (histTex == null)
                    histTex = HistogramTextureGenerator.GenerateHistogramTexture(volobj.dataset);

                tfGUIMat.SetTexture("_TFTex", tf.GetTexture());
                tfGUIMat.SetTexture("_HistTex", histTex);

                for (int iAlpha = 0; iAlpha < tf.alphaControlPoints.Count; iAlpha++)
                {

                    Debug.Log("Alpha datavalue   "+tf.alphaControlPoints[iAlpha].alphaValue);
                }

                for (int iAlpha = 0; iAlpha < tf.colourControlPoints.Count; iAlpha++)
                {

                    Debug.Log("Color datavalue   "+tf.colourControlPoints[iAlpha].colourValue);
                }




            }


        }


    }
}
