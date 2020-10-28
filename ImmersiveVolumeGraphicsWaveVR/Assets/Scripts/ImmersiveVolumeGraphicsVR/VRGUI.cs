using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGUI : MonoBehaviour
{
    public Text fpsText;
    public float deltaTime;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width, 30), "FPS:     "+fpsText.text);

    }

    private void Start()
    {
     
    }


}
