CALL D:\Anaconda\Scripts\activate.bat py36 

echo test
CALL decompress.bat
CALL python ReadDICOMMetaData.py
CALL ImageJ-win64.exe --headless -macro DICOMTORAW8BIT.ijm
echo Exported successfully
