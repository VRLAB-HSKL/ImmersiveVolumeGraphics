using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class VRRotateWithObject : MonoBehaviour
{

    public GameObject obj;
    public GameObject obj2;
    public string objname = "";
    public string objname2 = "";
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
                Vector3 rot = new Vector3(0.0f, 0.0f, obj.transform.eulerAngles.z);
                obj2.transform.rotation = Quaternion.Euler(rot);
            }

            if (dirx)
            {

                Vector3 rot = new Vector3(obj.transform.eulerAngles.y, 0.0f, 0.0f);
                obj2.transform.rotation = Quaternion.Euler(rot);
            }

            if (diry)
            {

                Vector3 rot = new Vector3(obj2.transform.eulerAngles.x,obj.transform.eulerAngles.y*2, obj2.transform.eulerAngles.z);
                obj2.transform.rotation = Quaternion.Euler(rot);

            }



        }
        else
        {

            obj = GameObject.Find(objname);
            obj2 = GameObject.Find(objname2);

        }
    }

    public void initObj(string name1, string name2, string dir)
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
