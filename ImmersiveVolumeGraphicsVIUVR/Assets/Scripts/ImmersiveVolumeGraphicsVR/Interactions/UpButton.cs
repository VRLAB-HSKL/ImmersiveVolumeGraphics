using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;


namespace UnityVolumeRendering
{
    public class UpButton : MonoBehaviour, IColliderEventPressEnterHandler
        , IColliderEventPressExitHandler
    {

        [SerializeField]
        private ColliderButtonEventData.InputButton m_activeButton = ColliderButtonEventData.InputButton.Trigger;

        public Vector3 buttonDownDisplacement;
        public Vector3 objectDisplacement;
        public Transform buttonObject;
        bool getUpwards = false;

        private VolumeRenderedObject volobj;
        private GameObject ConsoleBase;
        private GameObject Regulator1;
        private GameObject Regulator2;
        private GameObject Regulator3;




        void Start()
        {

            ConsoleBase = GameObject.Find("ConsoleBase");
            Regulator1  = GameObject.Find("Regulator");
            Regulator2 = GameObject.Find("Regulator (1)");
            Regulator3 = GameObject.Find("Regulator (2)");

        }



        public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            if (eventData.button == m_activeButton)
            {
                volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();

                buttonObject.localPosition += buttonDownDisplacement;
                getUpwards = true;





            }
        }

        public void OnColliderEventPressExit(ColliderButtonEventData eventData)
        {
            buttonObject.localPosition -= buttonDownDisplacement;
            getUpwards = false;
        }



        // Update is called once per frame
        void Update()
        {
            if (getUpwards)
            {
                if (volobj != null)
                {

                    if (ConsoleBase.transform.localPosition.y <= -0.399)
                    {

                        ConsoleBase.transform.localPosition += objectDisplacement * Time.deltaTime;
                        Regulator1.transform.localPosition += objectDisplacement * Time.deltaTime;
                        Regulator2.transform.localPosition += objectDisplacement * Time.deltaTime;
                        Regulator3.transform.localPosition += objectDisplacement * Time.deltaTime;

                        volobj.transform.localPosition += objectDisplacement * Time.deltaTime;




                        Debug.Log("hoch");

                    }



                    /*  if (ConsoleBase.transform.localPosition.y <= -1.3f) {


                          volobj.transform.localPosition = new Vector3(volobj.transform.localPosition.z, volobj.transform.localPosition.y, volobj.transform.localPosition.x);
                          ConsoleBase.transform.localPosition = new Vector3(ConsoleBase.transform.localPosition.z, -1.3f, ConsoleBase.transform.localPosition.x);


                      }*/

                }


            }
        }



    }

}