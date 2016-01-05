import os


for fname in os.listdir("."):
    if fname.startswith('m'):
        os.rename(fname, fname[1:])
