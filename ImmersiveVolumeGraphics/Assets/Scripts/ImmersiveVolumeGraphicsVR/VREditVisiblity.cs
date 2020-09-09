using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering
{
    public class VREditVisiblity : MonoBehaviour
    {

        public Slider s;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void EditMinVisiblity()
        {
            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            Vector2 visibilityWindow = volobj.GetVisibilityWindow();

            visibilityWindow.x = s.value;


                 volobj.SetVisibilityWindow(visibilityWindow);


        }


        public void EditMaxVisiblity() {

            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            Vector2 visibilityWindow = volobj.GetVisibilityWindow();
            visibilityWindow.y = s.value;
            volobj.SetVisibilityWindow(visibilityWindow);

        }



    }
}