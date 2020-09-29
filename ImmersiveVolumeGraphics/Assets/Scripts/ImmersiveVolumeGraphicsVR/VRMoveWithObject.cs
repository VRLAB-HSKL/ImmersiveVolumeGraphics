using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMoveWithObject : MonoBehaviour
{

    public GameObject obj;
    public GameObject obj2;
    public string objname = "SlicingPlane(Clone)"; 
    public string objname2 = "EditSliceRenderer1";
    public float origin=0;
    // Start is called before the first frame update
    void Start()
    {
        //
        obj = GameObject.Find(objname);
        obj2 = GameObject.Find(objname2);

    }

    // Update is called once per frame
    void Update()
    {
        // obj.transform.position = this.transform.position;
        if (obj != null)
        {
            obj.transform.localPosition = new Vector3(0, -(obj2.transform.position.z - origin), 0);

        }
        else {

            obj = GameObject.Find(objname);


        }
    }




}
