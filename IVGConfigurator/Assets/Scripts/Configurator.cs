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
        warningText.text = "EXPORT OF MODEL AND CONFIG FILES SUCCESSFULL";

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
            MetaInfoWriter.WriteLine("print(ds, file = open('OUTPUT/" + FileNameInput.text + ".txt', 'w'))");


            MetaInfoWriter.Flush();
            MetaInfoWriter.Close();

            //--------------------------------------------------------------

            StreamWriter INIWriter = new StreamWriter("OUTPUT/" + FileNameInput.text + ".ini");

            INIWriter.WriteLine("dimx:" + width);
            INIWriter.WriteLine("dimy:" + height);
            INIWriter.WriteLine("dimz:" + depth);
            INIWriter.WriteLine("skip:0");
            INIWriter.WriteLine("format:uint8");


            INIWriter.Flush();
            INIWriter.Close();


            //-----------------------------------------------------------------------------------------------


            StreamWriter AnacondaWriter = new StreamWriter("Export.bat");
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


            AnacondaWriter.WriteLine("CALL python ReadDICOMMetaData.py");
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








