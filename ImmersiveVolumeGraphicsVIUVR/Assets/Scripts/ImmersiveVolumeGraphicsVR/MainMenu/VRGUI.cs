using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGUI : MonoBehaviour
{


    //MainMenu              | Status 0
    public Button modelimportbtn;
    public Button modeleditbtn;
    public Button transferfunctionbtn;
    public Button recorderbtn;
    public Button dashboardbtn;
    public Button aboutbtn;
    public GameObject MainMenu;
    //ModelImport           | Status 1
    public GameObject ModelImport;
    //ModelEdit             | Status 2
    public GameObject ModelEdit;
    //Transferfunction      | Status 3
    public GameObject Transferfunction;
    //Recorder              | Status 4
    public GameObject Recorder;
    //Dashboard             | Status 5
    public GameObject Dashboard;
    //Info / About          | Status 6
    public GameObject About;


    //Backbutton to get back to the MainMenu
    public GameObject BackButton;
    public Button backbtn;
    public static int status = 0;


   

    private void Start()
    {

        //Add Listeners 

        modelimportbtn.onClick.AddListener(ToStatus1);
        modeleditbtn.onClick.AddListener(ToStatus2);
        transferfunctionbtn.onClick.AddListener(ToStatus3);
        recorderbtn.onClick.AddListener(ToStatus4);
        dashboardbtn.onClick.AddListener(ToStatus5);
        aboutbtn.onClick.AddListener(ToStatus6);
        backbtn.onClick.AddListener(ToStatus0);





    }

    //MainMenu  
   public  void ToStatus0()
    {
        BackButton.SetActive(false);

        if (ModelImport.active == true) { ModelImport.SetActive(false); }
        if (ModelEdit.active == true) { ModelEdit.SetActive(false); }
        if (Transferfunction.active == true) { Transferfunction.SetActive(false); }
        if (Recorder.active == true) { Recorder.SetActive(false); }
        if (Dashboard.active == true) { Dashboard.SetActive(false); }
        if (About.active == true) { About.SetActive(false); }

        MainMenu.SetActive(true);

        status = 0;
    }

    //ModelImport 
    public void ToStatus1()
    {

        MainMenu.SetActive(false);
        BackButton.SetActive(true);
        BackButton.SetActive(true);
        ModelImport.SetActive(true);

        status = 1;
    }
    //ModelEdit
    public void ToStatus2()
    {
        MainMenu.SetActive(false);
        BackButton.SetActive(true);
        BackButton.SetActive(true);
        ModelEdit.SetActive(true);

        status = 2;
    }

    //Transferfunction 
    public void ToStatus3()
    {
        MainMenu.SetActive(false);
        BackButton.SetActive(true);
        BackButton.SetActive(true);
        Transferfunction.SetActive(true);

        status = 3;

    }
    //Recorder 
    public  void ToStatus4()
    {
        MainMenu.SetActive(false);
        BackButton.SetActive(true);
        BackButton.SetActive(true);
        Recorder.SetActive(true);

        status = 4;
    }
    //Dashboard  
    public void ToStatus5()
    {
        MainMenu.SetActive(false);
        BackButton.SetActive(true);
        BackButton.SetActive(true);
        Dashboard.SetActive(true);

        status = 5;
    }
    //Info / About
    public void ToStatus6()
    {
        MainMenu.SetActive(false);
        BackButton.SetActive(true);
        BackButton.SetActive(true);
        About.SetActive(true);

        status = 6;

    }









}
