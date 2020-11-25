using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityVolumeRendering;
namespace ImmersiveVolumeGraphics {
    namespace Transferfunctions
    {
        public class TransferfunctionAlphaPointList : MonoBehaviour
        {

            List<string>  DropDownOptions = new List<string>();
            public Dropdown DropDown;
            static VolumeRenderedObject   volobject;

            public static int AlphaPointIndex = 0;


            // Start is called before the first frame update
            void Start()
            {

            }

            // Update is called once per frame
            void Update()
            {

            }



            public  void ReloadList()
            {
                volobject = GameObject.FindObjectOfType<VolumeRenderedObject>();
                DropDown.ClearOptions();
                DropDownOptions.Clear();
              
                if (volobject != null)
                {
                    for (int i = 0; i < volobject.transferFunction.alphaControlPoints.Count; i++)
                    {
                        DropDownOptions.Add(i + "");


                    }
                    DropDown.AddOptions(DropDownOptions);
                }

               
            }

            public void changeIndex()
            {

                AlphaPointIndex = DropDown.value;
                    


            }


            public static int getIndex()
            {

                return AlphaPointIndex;
            }








        }
    }
}
