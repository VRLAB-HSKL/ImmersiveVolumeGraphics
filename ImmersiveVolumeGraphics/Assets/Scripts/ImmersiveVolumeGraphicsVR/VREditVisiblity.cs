using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering
{
    public class VREditVisiblity : MonoBehaviour
    {
        //Slider for the GUI in VR
        public Slider s;

    // Edits the minimum Visibility 
        public void EditMinVisiblity()
        {   
            // Find the Volume Object i.e. our model
            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            // Get the visibily information
            Vector2 visibilityWindow = volobj.GetVisibilityWindow();
            // Set the visibility according to the slider´s value
            visibilityWindow.x = s.value;
            volobj.SetVisibilityWindow(visibilityWindow);


        }

        // Edits the maximum Visibility 
        public void EditMaxVisiblity() 
        {
            // Find the Volume Object i.e. our model
            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            // Get the visibily information
            Vector2 visibilityWindow = volobj.GetVisibilityWindow();
            // Set the visibility according to the slider´s value
            visibilityWindow.y = s.value;
            volobj.SetVisibilityWindow(visibilityWindow);

        }



    }
}