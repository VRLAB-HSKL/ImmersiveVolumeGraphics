using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Text;
using System.Runtime.CompilerServices;



    public class Configurator : MonoBehaviour
    {



    /// <summary>
    /// The Input and Outputpath 
    /// </summary>
    string inputPath, outputPath;
    /// <summary>
    /// Width, Height and Depth of the Model
    /// </summary>
    int width = 512, height = 512, depth = 245;
    /// <summary>
    /// Strings for the Input of the Width, Height and Depth of the Model
    /// </summary>
    string widthstring = "3"; string heightstring = "4"; string depthstring = "3";
    /// <summary>
    /// The Path of the Anaconda activate script
    /// </summary>
    string anacondafilepath = "";
    /// <summary>
    /// The GameObject that contains the  WidthInput of the Model
    /// </summary>
    public GameObject widthinputfield;
    /// <summary>
    /// The GameObject that contains the HeightInput of the Model
    /// </summary>
    public GameObject heightinputfield;
    /// <summary>
    ///  The GameObject that contains the DepthInput of the Model
    /// </summary>
    public GameObject depthinputfield;
    /// <summary>
    /// The GameObject that contains the FileNameInput of the Model
    /// </summary>
    public GameObject fileNameinputfield;
    /// <summary>
    /// The GameObject that contains the AnacondaFilePathInput of the Model
    /// </summary>
    public GameObject anacondafilepathinputfield;

    /// <summary>
    /// The Inputfield for the Depth of the Model
    /// </summary>
    private InputField widthInput;
    /// <summary>
    /// The Inputfield for the Depth of the Model
    /// </summary>
    private InputField heightInput;
    /// <summary>
    /// The Inputfield for the Depth of the Model
    /// </summary>
    private InputField depthInput;
    /// <summary>
    /// The Inputfield for the Depth of the Model
    /// </summary>
    private InputField FileNameInput;
    /// <summary>
    /// The Inputfield for the AnacondafilePath of the Model
    /// </summary>
    private InputField AnacondafilePathInput;

    /// <summary>
    /// The Text that shows Userinformation
    /// </summary>
    public Text warningText;
    /// <summary>
    /// The Exportbutton
    /// </summary>
    public Button exportbtn;

    /// <summary>
    /// Initialization: Find the Textfileds and set the WarningText
    /// </summary>
    /// <param name="void"></param>
    /// <returns>void</returns>
    private void Start()
        {



           // exportbtn.onClick.AddListener(StartPipeline);

            widthInput = widthinputfield.GetComponent<InputField>();
            heightInput = heightinputfield.GetComponent<InputField>();
            depthInput = depthinputfield.GetComponent<InputField>();
            FileNameInput = fileNameinputfield.GetComponent<InputField>();
            AnacondafilePathInput= anacondafilepathinputfield.GetComponent<InputField>();
            FileNameInput.text = "Modelname";

        
        warningText.color = Color.black;
        warningText.text = "Please configure your Model";

        }

    /// <summary>
    /// Validate the Textfields that only Intergers can be used, change the AnacondaFilePath
    /// </summary>
    /// <param name="void"></param>
    /// <returns>void</returns>

    /// <seealso>
    /// <ul>
    /// <li>Sources:</li>
    /// <li> [1] https://answers.unity.com/questions/794388/making-a-input-field-only-accepting-numbers.html </li>
    /// </ul>
    /// </seealso>

    private void Update()
        {



            widthInput.characterValidation = InputField.CharacterValidation.Integer;


            heightInput.characterValidation = InputField.CharacterValidation.Integer;


            depthInput.characterValidation = InputField.CharacterValidation.Integer;



            // FileNameInput.characterValidation = InputField.CharacterValidation.Alphanumeric;

            if (widthInput.text != "")
                width = int.Parse(widthInput.text);
            if (heightInput.text != "")
                height = int.Parse(heightInput.text);

            if (depthInput.text != "")
                depth = int.Parse(depthInput.text);

            anacondafilepath = AnacondafilePathInput.text;

        if (anacondafilepath =="")
        {
            anacondafilepath = "C:\\Users\\Marco\\anaconda3\\Scripts\\activate.bat";

        }




        }



    /// <summary>
    /// This Method handles the complete pipleline
    /// </summary>
    /// <remarks>
    /// Start the pipeline and give information to the user
    /// <ul>
    /// <li>After the user did his inputs, save the configuration</li>
    /// <li>Use the Export-Method to execute the Export.bat</li>
    /// </ul> 
    /// </remarks>
    /// <param name="void"></param>
    /// <returns>void</returns>
    public void StartPipeline()
        {

        warningText.color = Color.green;
        warningText.text = "Saving Configuration";
        SaveConfig();

        warningText.color = Color.green;
        warningText.text = "Starting Export";

        Export();

        warningText.color = Color.green;
        warningText.text = "EXPORT OF MODEL AND CONFIG ";

    }





    /// <summary>
    /// This Method handles the savingprocess of the textinputs and writes them into seperate files 
    /// </summary>
    /// <remarks>
    /// 
    /// <ul>
    /// <li>DICOMTORAW8BIT.ijm: use ImageJ Macros to load in the data and generate the Raw-Model </li>
    /// <li>ReadDICOMMetaData.py: Use the pydicom-package to load metainformation of the DICOM-Files and save them in a Textfile </li>
    /// <li>FileNameInput.ini: This file stores information about the model´s height, width , number of slices , dataformat e.g 8 Bit for Unity  </li>+
    /// <li>Export.bat: This file does the exportingprocess  </li>
    /// <li>1. Activate the Anaconda VM </li>
    /// <li>2. Decompress the DICOM-Files </li>
    /// <li>3. Read the  DICOM-Metainformation </li>
    /// <li>4. Use the converted DICOM-Files and export the Model </li>
    /// </ul> 
    /// </remarks>
    /// <param name="void"></param>
    /// <returns>void</returns>
    /// 


    /// <seealso>
    /// <ul>
    /// <li>Sources:</li>
    /// <li> [1] https://imagej.nih.gov/ij/developer/macro/macros.html </li>
    /// <li> [2] https://imagej.net/Headless </li>
    /// <li> [3] https://imagej.net/Scripting_Headless </li>
    /// <li> [4] https://forum.image.sc/t/running-plugins-macros-from-the-command-line/363/6 </li>
    /// </ul>
    /// </seealso>

    public void SaveConfig()
        {

            //-----------------------------------------------------------------------------------------------

            StreamWriter ModelWriter = new StreamWriter("DICOMTORAW8BIT.ijm");


        // You have to keep a space between the name and the keyword sort otherwise the system will search for the filename "sort" and it will not work
        // Source: https://imagej.nih.gov/ij/developer/macro/macros.html
        ModelWriter.WriteLine("run(\"Image Sequence...\", \"open=INPUT\\" + "\u005C" + " " + "sort\");");
        ModelWriter.WriteLine("run(\"8-bit\");");
        ModelWriter.WriteLine("saveAs(\"Raw Data\", \"OUTPUT\\" + "\u005C" + FileNameInput.text + ".raw\");");

        ModelWriter.Flush();
        ModelWriter.Close();



            //--------------------------------------------------------------
            //DicomMetaData

       StreamWriter MetaInfoWriter = new StreamWriter("ReadDICOMMetaData.py");

        MetaInfoWriter.WriteLine("from pydicom import dcmread");
        MetaInfoWriter.WriteLine("path = 'INPUT/IM-0001-0001.dcm'");
        MetaInfoWriter.WriteLine("ds =dcmread(path)");
        MetaInfoWriter.WriteLine("print(ds)");
        MetaInfoWriter.WriteLine("sn=\" \u005C" + "n\"");

        MetaInfoWriter.WriteLine("patientname = str(ds.PatientName)");
        MetaInfoWriter.WriteLine("patientid= str(ds.PatientID)");
        MetaInfoWriter.WriteLine("patientbirthdate=str(ds[0x10,0x30].value)");
        MetaInfoWriter.WriteLine("patientsex=str(ds.PatientSex)");

        MetaInfoWriter.WriteLine("institutionname = str(ds.InstitutionName)");
        MetaInfoWriter.WriteLine("institutionaddress =str(ds.InstitutionAddress)");
        MetaInfoWriter.WriteLine("physicianname= str(ds.ReferringPhysicianName)");
        MetaInfoWriter.WriteLine("studydiscription=str(ds.StudyDescription)");

        MetaInfoWriter.WriteLine("modality = str(ds.Modality)");
        MetaInfoWriter.WriteLine("manufacturer = str(ds.Manufacturer)");

        MetaInfoWriter.WriteLine("studyid = str(ds[0x20, 0x10].value)");
        MetaInfoWriter.WriteLine("studydate=str(ds[0x8,0x20].value)");
        MetaInfoWriter.WriteLine("seriesnumber=str(ds[0x20,0x11].value)");
        MetaInfoWriter.WriteLine("pixelspacingx=str(ds[0x28,0x30][0])");
        MetaInfoWriter.WriteLine("pixelspacingy=str(ds[0x28,0x30][1])");
        MetaInfoWriter.WriteLine("slicethickness=str(ds[0x18,0x50].value)");
        MetaInfoWriter.WriteLine("columns=str(ds[0x28,0x10].value)");
        MetaInfoWriter.WriteLine("rows=str(ds[0x28,0x11].value)");
        MetaInfoWriter.WriteLine("patientposition=str(ds[0x18,0x5100].value)");
        MetaInfoWriter.WriteLine("imageorientationpatientrowx=str(ds[0x20,0x37][0])");
        MetaInfoWriter.WriteLine("imageorientationpatientrowy=str(ds[0x20,0x37][1])");
        MetaInfoWriter.WriteLine("imageorientationpatientrowz=str(ds[0x20,0x37][2])");
        MetaInfoWriter.WriteLine("imageorientationpatientcolumnx=str(ds[0x20,0x37][3])");
        MetaInfoWriter.WriteLine("imageorientationpatientcolumny=str(ds[0x20,0x37][4])");
        MetaInfoWriter.WriteLine("imageorientationpatientcolumnz=str(ds[0x20,0x37][5])");


        MetaInfoWriter.WriteLine("patientinfo=patientname+sn+patientid+sn+patientbirthdate+sn+patientsex+sn");
        MetaInfoWriter.WriteLine("institutioninfo=institutionname+sn+institutionaddress+sn+physicianname+sn+studydiscription+sn");
        MetaInfoWriter.WriteLine("modalityinfo=modality+sn+manufacturer+sn");
        MetaInfoWriter.WriteLine("imageinfo=studyid+sn+studydate+sn+seriesnumber+sn+pixelspacingx+sn+pixelspacingy+sn+slicethickness+sn+columns+sn+rows+sn+patientposition+sn+imageorientationpatientrowx+sn+imageorientationpatientrowy+sn+imageorientationpatientrowz+sn+imageorientationpatientcolumnx+sn+imageorientationpatientcolumny+sn+imageorientationpatientcolumnz");

        MetaInfoWriter.WriteLine("output = patientinfo + institutioninfo + modalityinfo + imageinfo");
        MetaInfoWriter.WriteLine("print(output, file = open('OUTPUT/" + FileNameInput.text+".txt', 'w'))");




            MetaInfoWriter.Flush();
            MetaInfoWriter.Close();

        //--------------------------------------------------------------
        //INI-File
        StreamWriter INIWriter = new StreamWriter("OUTPUT/" + FileNameInput.text + ".ini");

            INIWriter.WriteLine("dimx:" + width);
            INIWriter.WriteLine("dimy:" + height);
            INIWriter.WriteLine("dimz:" + depth);
            INIWriter.WriteLine("skip:0");
            INIWriter.WriteLine("format:uint8");


            INIWriter.Flush();
            INIWriter.Close();


            //-----------------------------------------------------------------------------------------------

            //Decompression
            StreamWriter AnacondaWriter = new StreamWriter("Export.bat");
        //Execute the Pythoncode in the premade Anaconda Environment

        //AnacondaWriter.WriteLine("CALL D:\\Anaconda\\Scripts\\activate.bat py36");
        // C:\\Users\\Marco\\anaconda3\\Scripts\\activate.bat
        AnacondaWriter.WriteLine("CALL "+anacondafilepath+" py36");
        //  AnacondaWriter.WriteLine("CALL decompress.bat");

        for (int i = 1; i <= depth; i++)
            {
                if (i >= 1 && i < 10)

                {


                    AnacondaWriter.WriteLine("python decompress.py INPUT/IM-0001-000" + i + ".dcm INPUT/IM-0001-000" + i + ".dcm");

                }


                if (i >= 10 && i < 100)
                {
                    AnacondaWriter.WriteLine("python decompress.py INPUT/IM-0001-00" + i + ".dcm INPUT/IM-0001-00" + i + ".dcm");
                }

                if (i >= 100 && i < 1000)
                {
                    AnacondaWriter.WriteLine("python decompress.py INPUT/IM-0001-0" + i + ".dcm INPUT/IM-0001-0" + i + ".dcm");
                }

                if (i > 1000)
                {

                    AnacondaWriter.WriteLine("python decompress.py INPUT/IM-0001-" + i + ".dcm INPUT/IM-0001-" + i + ".dcm");

                }



            }

        //Reading and Exporting Metadata from DICOM-File
        AnacondaWriter.WriteLine("CALL python ReadDICOMMetaData.py");
        //Using ImageJ to load in the DICOM-Files and Exporting the Model as Raw-File
        //Source:"https://imagej.net/Headless" , "https://imagej.net/Scripting_Headless", https://forum.image.sc/t/running-plugins-macros-from-the-command-line/363/6
        AnacondaWriter.WriteLine("CALL ImageJ-win64.exe --headless -macro DICOMTORAW8BIT.ijm");
            // AnacondaWriter.WriteLine("echo Exported successfully");


            AnacondaWriter.Flush();
            AnacondaWriter.Close();




        }



    /// <summary>
    /// Executes the Export.bat
    /// </summary>
    /// <remarks>
    /// Exporting
    /// </remarks>
    /// <param name="void"></param>
    /// <returns>void</returns>

    /// <seealso>
    /// <ul>
    /// <li>Sources:</li>
    /// <li> [1] https://answers.unity.com/questions/1203577/how-to-execute-an-external-batch-file-with-argumen.html </li>
    /// <li> [2] https://forum.unity.com/threads/running-external-exe-from-unity.541270/ </li>
    /// </ul>
    /// </seealso>
    public void Export()
        {



            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = "Export.bat";
            p.Start();

        




        }









    }








