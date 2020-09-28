using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


namespace UnityVolumeRendering
{
   
    /// <summary>
    /// Imports a Model into the Scene via Voice command or Import Button
    /// </summary>

    public class ImportRAWModel : MonoBehaviour
    {
        //Name or path of the model
        public static  string  ModelPath = "";

      
        //setter-Method
        public static void setModelPath(string Path)
        {
            ModelPath = Path;
            

        }

        // Update is called once per frame
        void Update()
        {

            
        }

        // Importmethod for voice command
        public static void OpenRAWDataset()
        {
           
                // We'll only allow one dataset at a time in the runtime GUI (for simplicity)
                DespawnAllDatasets();

                // Parse .ini file
                DatasetIniData initData = DatasetIniReader.ParseIniFile(Application.dataPath + "/StreamingAssets/"+ModelPath+".ini");
                if (initData != null)
                {
                    // Import the dataset
                    RawDatasetImporter importer = new RawDatasetImporter(Application.dataPath + "/StreamingAssets/" + ModelPath, initData.dimX, initData.dimY, initData.dimZ, initData.format, initData.endianness, initData.bytesToSkip);
                    VolumeDataset dataset = importer.Import();
                    // Spawn the object
                    if (dataset != null)
                    {
                    // Create the Volume Object
                    VolumeObjectFactory.CreateObject(dataset);
                    
                    VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();

                    

                    // Sets the model into the right place of the scene 
                    volobj.gameObject.transform.position = new Vector3(0,1.3f,0);
                    // Rotates the object facing us
                    Vector3 rotation = new Vector3(-90, 0, 0);
                    volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);

                    //SliceThickness can never be 0! except the metainfo file wasnt loaded , default dimensions (scales) are (x,y,z) = (1 meter , 1 meter , 1 meter)
                    if (DICOMMetaReader.getThickness() > 0)
                    {
                        // Calculating the dimensions of the model 

                        // Unity doesn't use units for its worldspace but the VR-Environment needs units for the object mapping. 
                        // 1 unit in Unity equals to 1 meter in VR/Real Life
                        // normally the VolumeObject has a default size of 1x1x1 

                        // The Volume Objects size will be adjusted according to the DICOM information that we gathered
                        // the scaling in x will be  (amount of slices in X  * slicethickness ) / 1000  
                        // the scaling in y will be  (amount of slices in Y  * slicethickness ) / 1000  
                        // the scaling in z will be  (amount of slices in Z  * slicethickness ) / 1000  

                        // Remark:
                        // the slicethickness is measured  in Millimeter but the mapped Worldspace is in Meter so we have to take the factor 1000 into consideration
                        // the slicethickness is the same for every dimension 

                        volobj.gameObject.transform.localScale = new Vector3((initData.dimX * DICOMMetaReader.getThickness()) / 1000, (initData.dimY * DICOMMetaReader.getThickness()) / 1000, (initData.dimZ * DICOMMetaReader.getThickness()) / 1000);
                    }

                    // Spawns a CrossSectionPlane  that can intersect the model and show its inside
                    VolumeObjectFactory.SpawnCrossSectionPlane(volobj);
                    // Finding the Object
                    GameObject quad = GameObject.Find("Quad");
                    // Renaming it
                    quad.name = "CrossSection";

                    //Adding the MeshRenderer
                    MeshRenderer meshRenderer = quad.GetComponent<MeshRenderer>();
                    meshRenderer.enabled = false;
                    
                    // Movable quad that can be interacted in VR with the controllers when  collided
                    GameObject crosssectionselection = GameObject.Find("CrosssectionSelection");
                    //Sets the CrossSectionPlane to the Quad that they can move together
                    quad.transform.SetParent(crosssectionselection.transform);
                    // Fitting the Quad to the right position in the world space
                    crosssectionselection.gameObject.transform.position = new Vector3(0, 1.6f, 0);

                    VolumeRenderedObject volRend = FindObjectOfType<VolumeRenderedObject>();
                    if (volobj != null)
                    {

                        volobj.CreateSlicingPlane();

                        // Finding the ImageViewer
                        GameObject SlicingPlane = GameObject.Find("SlicingPlane(Clone)");
                        GameObject ImageViewer = GameObject.Find("ImageViewer");

                        ImageViewer.GetComponent<MeshRenderer>().sharedMaterial = SlicingPlane.GetComponent<MeshRenderer>().sharedMaterial;

                    }


                }
                }
            
        }

        //OnClickListener
        public  void OpenRAWData()
        {

            // We'll only allow one dataset at a time in the runtime GUI (for simplicity)
            DespawnAllDatasets();

            // Did the user try to import an .ini-file? Open the corresponding .raw file instead
            //  string filePath = Application.dataPath + "/StreamingAssets/" ;
            //if (System.IO.Path.GetExtension(filePath) == ".ini")
            //  filePath = filePath.Replace(".ini", ".raw");

            // Parse .ini file
            DatasetIniData initData = DatasetIniReader.ParseIniFile(Application.dataPath + "/StreamingAssets/" + ModelPath + ".ini");
            if (initData != null)
            {
                // Import the dataset
                RawDatasetImporter importer = new RawDatasetImporter(Application.dataPath + "/StreamingAssets/" + ModelPath, initData.dimX, initData.dimY, initData.dimZ, initData.format, initData.endianness, initData.bytesToSkip);
                VolumeDataset dataset = importer.Import();
                // Spawn the object
                if (dataset != null)
                {
                    VolumeObjectFactory.CreateObject(dataset);
                    VolumeRenderedObject volobj = GameObject.FindObjectOfType<VolumeRenderedObject>();

                 
                   

                    volobj.gameObject.transform.position = new Vector3(0, 1.3f, 0);
                    Vector3 rotation = new Vector3(-90, 0, 0);
                    volobj.gameObject.transform.rotation = Quaternion.Euler(rotation);

                    //SliceThickness can never be 0! except the metainfo file wasnt loaded , default dimensions (scales) are (x,y,z) = (1 meter , 1 meter , 1 meter)
                    if (DICOMMetaReader.getThickness() > 0)
                    {
                        volobj.gameObject.transform.localScale = new Vector3((initData.dimX * DICOMMetaReader.getThickness()) / 1000, (initData.dimY * DICOMMetaReader.getThickness()) / 1000, (initData.dimZ * DICOMMetaReader.getThickness()) / 1000);
                    }

                    VolumeObjectFactory.SpawnCrossSectionPlane(volobj);
                    GameObject quad = GameObject.Find("Quad");
                    quad.name = "CrossSection";

                    MeshRenderer meshRenderer = quad.GetComponent<MeshRenderer>();
                    meshRenderer.enabled = false;



                    GameObject crosssectionselection = GameObject.Find("CrosssectionSelection");
                    quad.transform.SetParent(crosssectionselection.transform);
                    crosssectionselection.gameObject.transform.position = new Vector3(0, 1.6f, 0);

                    GameObject rotTable = GameObject.Find("Rotatable Table");
                   volobj.transform.SetParent(rotTable.transform);
                   




                    // Finding the ImageViewer
                    //   GameObject SlicingPlane = GameObject.Find("SlicingPlane(Clone)");

                    SlicingPlane SlicingPlane =  volobj.CreateSlicingPlane();
                    GameObject ImageViewer = GameObject.Find("ImageViewer");

                    MeshRenderer SlicerMeshrenderer = SlicingPlane.GetComponent<MeshRenderer>();
                    SlicerMeshrenderer.enabled = false;

                    ImageViewer.GetComponent<MeshRenderer>().sharedMaterial = SlicingPlane.GetComponent<MeshRenderer>().sharedMaterial;

                  
                    

                }
            }

        }












        private static void DespawnAllDatasets()
        {
            VolumeRenderedObject[] volobjs = GameObject.FindObjectsOfType<VolumeRenderedObject>();
            foreach (VolumeRenderedObject volobj in volobjs)
            {
                GameObject.Destroy(volobj.gameObject);

            }

            Object crosssection = GameObject.Find("CrossSection");
            GameObject.Destroy(crosssection);

            Object slicingplane = GameObject.Find("SlicingPlane(Clone)");
            GameObject.Destroy(slicingplane);





        }

    }
}