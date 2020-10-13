from pydicom import dcmread
path = 'INPUT/IM-0001-0001.dcm'
ds =dcmread(path)
print(ds)
print(ds, file = open('OUTPUT/test.txt', 'w'))
