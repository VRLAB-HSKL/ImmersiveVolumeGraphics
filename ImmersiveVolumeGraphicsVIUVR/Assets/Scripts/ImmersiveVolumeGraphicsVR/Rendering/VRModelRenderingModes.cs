using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityVolumeRendering
{
    public class VRModelRenderingModes : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void EnableDirectVolumeRendering()
        {
            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            if (volobj != null)
            {
                volobj.SetRenderMode((RenderMode)0);
            }
        }


        public void EnableMaximumIntensityRendering()
        {

            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            if (volobj != null)
            {
                volobj.SetRenderMode((RenderMode)1);
            }
        }


        public void EnableIsosurfaceRendering()
        {

            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            if (volobj != null)
            {
                volobj.SetRenderMode((RenderMode)2);
            }



        }






    }
}