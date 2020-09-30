using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VRMoveWithObject : MonoBehaviour
{

    public GameObject obj;
    public GameObject obj2;
    public string objname = ""; 
    public string objname2 = "";
    public float origin=0;
    public bool dirx;
    public bool diry;
    public bool dirz;

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


            if (dirz)
            { 
                obj.transform.localPosition = new Vector3(0, -(obj2.transform.position.z - origin), 0);
            }

           if(dirx)
            {
                obj.transform.localPosition = new Vector3((obj2.transform.position.x - origin), 0, 0);
            }

            if (diry)
            {
                obj.transform.localPosition = new Vector3(0, 0, -(obj2.transform.position.z - origin));
            }



        }
        else {

            obj = GameObject.Find(objname);
            obj2 = GameObject.Find(objname2);

        }
    }

    public  void initObj(string name1, string name2, string dir)
    {
        objname = name1;
        objname2 = name2;


        if (dir.Equals("x"))
        {
            dirx = true;
        
        }

        if (dir.Equals("y"))
        {
            diry = true;

        }

        if (dir.Equals("z"))
        {
            dirz = true;

        }

    }



}
