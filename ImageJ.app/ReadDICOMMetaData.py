from pydicom import dcmread



#path = 'C:/Users/Noll/Desktop/ImmersiveVolumeGraphics/ImmersiveVolumeGraphics/VisibleHumanProject/VHP_MALE/VHMCT1mm_Head/Head/vhm.1001.dcm'
path = 'DICOM/vhm.1001.dcm'
ds =dcmread(path)
print(ds)
print("")
print("")
print("Exported successfully")
print(ds, file=open('RAWMODEL/RawModelMetadata.txt', 'w'))



