import os

count = 0
fcount = 1
for filename in os.listdir("."):
    if filename.startswith('m' + str(fcount)):
        os.rename(filename, filename[:1] + str(count) + ".jpg")
        count += 1
        fcount += 1
