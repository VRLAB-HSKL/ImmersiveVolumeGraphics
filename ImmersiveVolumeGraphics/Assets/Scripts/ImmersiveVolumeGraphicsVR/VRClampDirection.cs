using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRClampDirection : MonoBehaviour
{
    // Start is called before the first frame update
    public bool x;
    public bool y;
    public bool z;
    public float offsetX;
    public float offsetY;
    public float offsetZ;
    private Vector3 start;

    void Start()
    {
        start = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);       
    }

    // Update is called once per frame
    void Update()
    {
        if (x)
        {
            if (this.gameObject.transform.localPosition.x >= start.x + offsetX)
            { this.gameObject.transform.localPosition = new Vector3(start.x + offsetX, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z); }

            if (this.gameObject.transform.localPosition.x <= start.x - offsetX)
            { this.gameObject.transform.localPosition = new Vector3(start.x - offsetX, this.gameObject.transform.localPosition.y, this.gameObject.transform.localPosition.z); }


        }




            if (y)
        {


            if (this.gameObject.transform.localPosition.y >= start.y + offsetY)
            { this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, start.y + offsetY, this.gameObject.transform.localPosition.z); }

            if (this.gameObject.transform.localPosition.y <= start.y - offsetY)
            { this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, start.y - offsetY, this.gameObject.transform.localPosition.z); }

        }




        if (z)
        {
            if (this.gameObject.transform.localPosition.z >= start.z + offsetZ)
            { this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y + offsetY, start.z  + offsetZ); }

            if (this.gameObject.transform.localPosition.z <= start.z - offsetZ)
            { this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, this.gameObject.transform.localPosition.y - offsetY, start.z - offsetZ); }


        }










    }









}

