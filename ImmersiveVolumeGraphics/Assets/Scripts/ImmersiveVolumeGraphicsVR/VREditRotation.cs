using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityVolumeRendering {
    public class VREditRotation : MonoBehaviour
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



        




    public void EditRotationX()
        {

            VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            if (volobj != null)
            {
                Vector3 rotation = new Vector3(s.value, 0, 0);
                volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);
            }

        }


        public void EditRotationY()
        {
           
                VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
                if (volobj != null)
                {
                    Vector3 rotation = new Vector3(0, s.value, 0);
                volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);
            }
        }

        public void EditRotationZ()
        {
           
           VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();
            if (volobj != null)
            {
                Vector3 rotation = new Vector3(0, 0, s.value);
            volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);
            }
        }





    }
}