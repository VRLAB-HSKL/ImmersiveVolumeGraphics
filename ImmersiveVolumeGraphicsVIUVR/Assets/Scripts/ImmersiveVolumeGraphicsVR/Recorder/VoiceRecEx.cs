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

        // KewwordRecognizer from the Microsoft Speech API
        KeywordRecognizer keywordRecognizer;

        // DictationRecognizer from the Microsoft Speech API
        DictationRecognizer dictationRecognizer;

        // Storing the text
        string dictationtext = "";

        // Informationhint for the user in VR
        public Text RecorderLabel;

        // List of keywords that are usued for the voice commands
        public string[] Keywords_array;

        // Start is called before the first frame update
        void Start()
        {
            // Creates a new array and adds the keywords to it
            Keywords_array = new string[5];
            Keywords_array[0] = "import";
            Keywords_array[1] = "record";
            Keywords_array[2] = "quit";
            Keywords_array[3] = "stop";
            Keywords_array[4] = "load";

            // Initialization
            // Keywords
            keywordRecognizer = new KeywordRecognizer(Keywords_array);
            keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
            keywordRecognizer.Start();

            // DictationFunction Initialization and adding the listeners
            dictationRecognizer = new DictationRecognizer();
            dictationRecognizer.DictationResult += DictationRecognizer_DictationResult;
            dictationRecognizer.DictationHypothesis += DictationRecognizer_DictationHypothesis;
            dictationRecognizer.DictationComplete += DictationRecognizer_DictationComplete;
            dictationRecognizer.DictationError += DictationRecognizer_DictationError;

            // Creates a new directory for the recording
            Directory.CreateDirectory(Application.dataPath + "/Recording/");

        }

        // Triggers when a word is recognized
        void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
        {

            //Debugs the word
            Debug.Log(args.text);

            // Did the user say "import" ?
            if (VRGUI.status == 1)
            {
                if (args.text == "import")
                {
                    //Debuginformation
                    Debug.Log("Model loaded sucessfully");
                    //Imports the model using the OpenRAWDataset-Method
                    ImportRAWModel.OpenRAWDataset();

                }
            }

            // Did the user say "import" ?
            if (VRGUI.status == 4)
            {
                if (args.text == "record")
                {
                    //Changes the text to "Recording" in the color red to signalize that the recorded actually started

                    RecorderLabel.text = "Recording";
                    RecorderLabel.color = Color.red;

                    // Stops the keyword listener
                    keywordRecognizer.Stop();
                    //Shuts down the PhraseRecognitionSystem
                    // only one Recognizer can run 
                    PhraseRecognitionSystem.Shutdown();
                    //Debuginformation
                    Debug.Log("Recording started");
                    // Starts the dictation
                    dictationRecognizer.Start();

                }
            }


            // Did the user say "import" ?


            if (args.text == "quit")
            {
                // Quits the program
                Application.Quit();
                
            }

            /*
            //For Testing
            if (args.text == "load")
            {

                //  string tempPath = Path.Combine(Application.persistentDataPath, "Audio");
                //tempPath = Path.Combine(tempPath, "storyrecord.wav");
                //                Debug.Log(tempPath);  
                    string tempPath = Application.dataPath + "/Recording/";
                    Debug.Log(tempPath);
  
            }*/

        }


        // Triggers when a sentence is finished 
        private void DictationRecognizer_DictationResult(string text, ConfidenceLevel confidence)
        {
           
            // Debuginformation
            Debug.Log(text + " ");
            //adds the text our string in a format
            dictationtext += text +"\n";

            // Did the user say "stop"? 
            // sometimes it happens that the Microsoft Speech API doesnt recognize words well 
            
            if ((text == "stopp" || text == "stop") )
            {

                // Debuginformation
                Debug.Log(text + " ");
                // Stop the Dication / Recording 
                dictationRecognizer.Stop();
                //Debuinformation
                Debug.Log("Recording stopped ");
                // //Changes the text to "Not Recording" in the color black to signalize that the recorded actually stopped
                RecorderLabel.text = "Not Recording";
                RecorderLabel.color = Color.black;

                //adds the current date and time to the filename
                string date = DateTime.Now.ToString("dd-MM-yyyy+HH-mm-ss");
                // the location where the recording is stored
                // file typ is .txt 
                string filepath = Application.dataPath+"/Recording/"+date+"_"+"recording.txt";
                // gives the path to the Streamwriter 
                StreamWriter Writer = new StreamWriter(filepath);
                // the StreamWriter writes the stored Data 
                Writer.WriteLine(dictationtext);
                // Clearing the buffer
                Writer.Flush();
                // Closing the Writer to prevent memory leak
                Writer.Close();
                // Reset of the text because the recording is finished
                dictationtext = "";


            }

        }

        // Thze Microsoft Voice API can predict words that you are saying 
        // This event handles predicted words 
        private void DictationRecognizer_DictationHypothesis(string text)
        {
        
          
        }

        // Is triggered when the Dication is complete
        private void DictationRecognizer_DictationComplete(DictationCompletionCause cause)
        {

            // Restarts the  PhraseRecognitionSystem 
            PhraseRecognitionSystem.Restart();
            // Starts the keywordRecognizer for new voice commands
            keywordRecognizer.Start();


        }

        // Is triggered when an error occured (error handling)
        private void DictationRecognizer_DictationError(string error, int hresult)
        {
            // do something
            //Debug.Log(error+" "+hresult);

        }


    }


}
