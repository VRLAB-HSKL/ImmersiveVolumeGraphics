using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using System.Text;
using System.Runtime.CompilerServices;



    public class Configurator : MonoBehaviour
    {




        string inputPath, outputPath;
        int width = 512, height = 512, depth = 245;
        string widthstring = "3"; string heightstring = "4"; string depthstring = "3";
        //Object asset;

        public GameObject widthinputfield;
        public GameObject heightinputfield;
        public GameObject depthinputfield;
        public GameObject fileNameinputfield;



        private InputField widthInput;
        private InputField heightInput;
        private InputField depthInput;
        private InputField FileNameInput;

        public Text warningText;

        static string data;
        public static Color[] colors;


        public Button exportbtn;
        private void Start()
        {



           // exportbtn.onClick.AddListener(StartPipeline);

            widthInput = widthinputfield.GetComponent<InputField>();
            heightInput = heightinputfield.GetComponent<InputField>();
            depthInput = depthinputfield.GetComponent<InputField>();
            FileNameInput = fileNameinputfield.GetComponent<InputField>();
            FileNameInput.text = "Modelname";

        
        warningText.color = Color.black;
        warningText.text = "Please configure your Model";

        }
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

        }




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




        public void SaveConfig()
        {

            //-----------------------------------------------------------------------------------------------

            StreamWriter ModelWriter = new StreamWriter("DICOMTORAW8BIT.ijm");


            // You have to keep a space between the name and the keyword sort otherwise the system will search for the filename "sort" and it will not work
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
        MetaInfoWriter.WriteLine("pixelspacing=str(ds[0x28,0x30].value)");
        MetaInfoWriter.WriteLine("slicethickness=str(ds[0x18,0x50].value)");
        MetaInfoWriter.WriteLine("columns=str(ds[0x28,0x10].value)");
        MetaInfoWriter.WriteLine("rows=str(ds[0x28,0x11].value)");
        MetaInfoWriter.WriteLine("patientposition=str(ds[0x18,0x5100].value)");
        MetaInfoWriter.WriteLine("imageorientationpatient=str(ds[0x20,0x37].value)");

        MetaInfoWriter.WriteLine("patientinfo=patientname+sn+patientid+sn+patientbirthdate+sn+patientsex+sn");
        MetaInfoWriter.WriteLine("institutioninfo=institutionname+sn+institutionaddress+sn+physicianname+sn+studydiscription+sn");
        MetaInfoWriter.WriteLine("modalityinfo=modality+sn+manufacturer+sn");
        MetaInfoWriter.WriteLine("imageinfo=studyid+sn+studydate+sn+seriesnumber+sn+pixelspacing+sn+slicethickness+sn+columns+sn+rows+sn+patientposition+sn+imageorientationpatient");

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
            AnacondaWriter.WriteLine("CALL D:\\Anaconda\\Scripts\\activate.bat py36");

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
            AnacondaWriter.WriteLine("CALL ImageJ-win64.exe --headless -macro DICOMTORAW8BIT.ijm");
            // AnacondaWriter.WriteLine("echo Exported successfully");


            AnacondaWriter.Flush();
            AnacondaWriter.Close();




        }


        public void Export()
        {



            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = "Export.bat";
            p.Start();

        




        }









    }








