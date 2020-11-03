using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.ColliderEvent;
using HTC.UnityPlugin.Utility;


namespace UnityVolumeRendering
{
    public class DownButton : MonoBehaviour, IColliderEventPressEnterHandler
        , IColliderEventPressExitHandler
    {

        [SerializeField]
        private ColliderButtonEventData.InputButton m_activeButton = ColliderButtonEventData.InputButton.Trigger;

        public Vector3 buttonDownDisplacement;
        public Vector3 objectDisplacement;
        public Transform buttonObject;
        bool getDownwards = false;

        private VolumeRenderedObject volobj;
        private GameObject ConsoleBase;
        private GameObject Regulator1;
        private GameObject Regulator2;
        private GameObject Regulator3;
        private GameObject EditSliceRenderer3;



        void Start()
        {

            ConsoleBase = GameObject.Find("ConsoleBase");
            Regulator1 = GameObject.Find("Regulator");
            Regulator2 = GameObject.Find("Regulator (1)");
            Regulator3 = GameObject.Find("Regulator (2)");
            EditSliceRenderer3 = GameObject.Find("EditSliceRenderer3");

        }



        public void OnColliderEventPressEnter(ColliderButtonEventData eventData)
        {
            if (eventData.button == m_activeButton)
            {
                 volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();

                buttonObject.localPosition += buttonDownDisplacement;
                getDownwards = true;





            }
        }

        public void OnColliderEventPressExit(ColliderButtonEventData eventData)
        {
            buttonObject.localPosition -= buttonDownDisplacement;
            getDownwards = false;
        }



        // Update is called once per frame
        void Update()
        {
            if (getDownwards)
            {
                if (volobj != null)
                {

                    if (ConsoleBase.transform.localPosition.y > -1.3f)
                    {

                        ConsoleBase.transform.localPosition += objectDisplacement * Time.deltaTime;
                        Regulator1.transform.localPosition += objectDisplacement * Time.deltaTime;
                        Regulator2.transform.localPosition += objectDisplacement * Time.deltaTime;
                        Regulator3.transform.localPosition += objectDisplacement * Time.deltaTime;
                        EditSliceRenderer3.transform.localPosition += objectDisplacement * Time.deltaTime;
                        volobj.transform.localPosition += objectDisplacement * Time.deltaTime; ;
                        Debug.Log("runter");

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