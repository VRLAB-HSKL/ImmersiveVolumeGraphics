using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGUI : MonoBehaviour
{


    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, 30), "");
      //  GUI.TextField(new Rect(Screen.width - 50, 0, Screen.width, 30), "");

    }


}
