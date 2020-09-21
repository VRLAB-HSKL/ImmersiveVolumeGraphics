using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;


namespace UnityVolumeRendering
{
    public class VoiceRecEx : MonoBehaviour
    {



        KeywordRecognizer keywordRecognizer;
        DictationRecognizer dictationRecognizer;
        string dictationtext = "";
        public Text RecorderLabel;

        public string[] Keywords_array;

        // Start is called before the first frame update
        void Start()
        {

            Keywords_array = new string[5];
            Keywords_array[0] = "import";
            Keywords_array[1] = "record";
            Keywords_array[2] = "how are you";
            Keywords_array[3] = "stop";
            Keywords_array[4] = "load";

            keywordRecognizer = new KeywordRecognizer(Keywords_array);
            keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
            keywordRecognizer.Start();

            //DictationFunction
            dictationRecognizer = new DictationRecognizer();
            dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
            dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
            dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
            dictationRecognizer.DictationError += DictationRecognizer_DictationError;


            Directory.CreateDirectory(Application.dataPath + "/Recording/");

          

        }

        // Update is called once per frame
        void Update()
        {

        }


        void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
        {


            Debug.Log(args.text);


            if (args.text == "import")
            {

                Debug.Log("Erfolgreich geladen");
                ImportRAWModel.OpenRAWDataset();
               
              


            }


            if (args.text == "record")
            {

                RecorderLabel.text = "Recording";
                RecorderLabel.color = Color.red;

                // PhraseRecognitionSystem.Shutdown();
                keywordRecognizer.Stop();
                PhraseRecognitionSystem.Shutdown();
                Debug.Log("Aufnahme startet");

               

                dictationRecognizer.Start();
              




            }


            if (args.text == "load")
            {



                //  string tempPath = Path.Combine(Application.persistentDataPath, "Audio");
                //tempPath = Path.Combine(tempPath, "storyrecord.wav");
                //                Debug.Log(tempPath);



                
                   
                    string tempPath = Application.dataPath + "/Recording/";
                    Debug.Log(tempPath);
   
            }








        }


        private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
        {
            // do something
            // Debug.Log(text+ " ");
            Debug.Log(text + " ");
            dictationtext += text +"\n";

            if ((text == "stopp" || text == "stop") )
            {

                Debug.Log(text + " ");

                dictationRecognizer.Stop();
                Debug.Log("gestoppt ");
                RecorderLabel.text = "Not Recording";
                RecorderLabel.color = Color.black;

                string date = DateTime.Now.ToString("dd-MM-yyyy+HH-mm-ss");
                string filepath = Application.dataPath+"/Recording/"+date+"_"+"recording.txt";
                StreamWriter Writer = new StreamWriter(filepath);
                Writer.WriteLine(dictationtext);
                Writer.Flush();
                Writer.Close();
                dictationtext = "";


            }

        }

        private void DictationRecognizer_DictationHypothesis(string text)
        {
            // do something
          //  Debug.Log(text);

          
        }

        private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
        {
            // do something

            // Debug.Log(cause);

            PhraseRecognitionSystem.Restart();
            keywordRecognizer.Start();


        }

        private void DictationRecognizer_DictationError(string error, int hresult)
        {
            // do something

            //Debug.Log(error+" "+hresult);

        }


    }


}
