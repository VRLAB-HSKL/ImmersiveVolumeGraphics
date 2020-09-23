using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering {
    public class VREditRotation : MonoBehaviour
    {
        //Slider for the GUI in VR
        public Slider s;
 
        // OnValueChangedListener for the slider
        // Edit the Rotation of the X-Axis in VR
    public void EditRotationX()
        {
            // Find the Volume Object i.e. our model
            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            // Do we have a model?
            if (volobj != null)
            {
            // Rotate it 
            Vector3 rotation = new Vector3(s.value, 0, 0);
             volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);
            }
        }

        // OnValueChangedListener for the slider
        // Edit the Rotation of the Y-Axis in VR
        public void EditRotationY()
        {
            // Find the Volume Object i.e. our model
            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            // Do we have a model?
            if (volobj != null)
            {
            // Rotate it 
            Vector3 rotation = new Vector3(0, s.value, 0);
            volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);
            }
        }

        // OnValueChangedListener for the slider
        // Edit the Rotation of the Z-Axis in VR
        public void EditRotationZ()
        {
            // Find the Volume Object i.e. our model
            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            // Do we have a model?
            if (volobj != null)
            {
            // Rotate it 
            Vector3 rotation = new Vector3(0, 0, s.value);
            volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);
            }
        }





    }
}