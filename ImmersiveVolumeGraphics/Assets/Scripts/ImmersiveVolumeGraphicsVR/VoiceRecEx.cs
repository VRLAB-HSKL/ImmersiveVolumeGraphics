using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;


namespace UnityVolumeRendering
{
    public class VoiceRecEx : MonoBehaviour
    {



        KeywordRecognizer keywordRecognizer;
        public string[] Keywords_array;

        // Start is called before the first frame update
        void Start()
        {

            Keywords_array = new string[2];
            Keywords_array[0] = "import";
            Keywords_array[1] = "how are you";

            keywordRecognizer = new KeywordRecognizer(Keywords_array);
            keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
            keywordRecognizer.Start();


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

               
                ImportRAWModel.OpenRAWDataset();
                Debug.Log("Erfolgreich geladen");
              


            }




        }

    }


}
