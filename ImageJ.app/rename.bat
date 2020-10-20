FOR /L %%A IN (135,1,999) DO (
 
  ren vhm.%%A.dcm IM-0001-0%%A.dcm
)




 FOR /L %%A IN (1000,1,1245) DO (
 
  
  ren vhm.%%A.dcm IM-0001-%%A.dcm
 )


