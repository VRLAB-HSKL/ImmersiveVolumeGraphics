FOR /L %%A IN (1,1,9) DO (
 
  python decompress.py DICOM/IM-0001-000%%A.dcm DICOM/IM-0001-000%%A.dcm
)


FOR /L %%A IN (10,1,99) DO (
 
  python decompress.py DICOM/IM-0001-00%%A.dcm  DICOM/IM-0001-00%%A.dcm
)

 FOR /L %%A IN (100,1,250) DO (
 
 python decompress.py DICOM/IM-0001-0%%A.dcm DICOM/IM-0001-0%%A.dcm
 )



