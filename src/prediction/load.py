import os
import struct
import numpy as np

def load_mnist(path, kind='train'):

    labels_path = os.path.join(path,
                                '%s-labels.idx1-ubyte'
                                % kind)
    images_path = os.path.join(path,
                                '%s-images.idx3-ubyte'
                                % kind)

    with open(labels_path, 'rb')  as lbpath:
        magic, n = struct.unpack('>II', lbpath.read(8))
        labels = np.fromfile(lbpath, dtype=np.uint8)

    with open(images_path, 'rb') as imgpath:
        magic , num, rows, cols = struct.unpack(">IIII", imgpath.read(16))
        images = np.fromfile(imgpath, dtype=np.uint8).reshape(len(labels), 784)

    return images, labels

X_train, y_train = load_mnist('mnist', kind='train')

X_test, y_test = load_mnist('mnist', kind='t10k')

np.savetxt('train_img.csv' , X_train, fmt='%i', delimiter = ',')
np.savetxt('train_labels.csv' , y_train, fmt='%i', delimiter = ',')
np.savetxt('test_img.csv' , X_test, fmt='%i', delimiter = ',')
np.savetxt('test_labels.csv' , y_test, fmt='%i', delimiter = ',')
