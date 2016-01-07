import time
import numpy as np
from neuralnet import NeuralNetMLP

X_train = np.genfromtxt('train_img.csv' , dtype=int, delimiter=',')
y_train = np.genfromtxt('train_labels.csv', dtype=int, delimiter=',')
X_test = np.genfromtxt('test_img.csv', dtype=int, delimiter=',')
y_test = np.genfromtxt('test_labels.csv', dtype=int, delimiter=',')


nn = NeuralNetMLP(n_output=10,
        n_features= X_train.shape[1],
        n_hidden = 50,
        l2 = 0.1,
        l1 = 0.0,
        epochs=1000,
        eta=0.001,
        alpha=0.001,
        decrease_const=0.00001,
        shuffle=True,
        minibatches=50,
        random_state= 1)

start_time = time.time()

nn.fit(X_train,y_train, print_progress=True)

y_train_pred = nn.predict(X_train)

y_test_pred = nn.predict(X_test)

end_time = time.time()

total_time = start_time - end_time

f = open('out.txt', 'w')

for val in y_train_pred:
     f.write(str(val) + '\n')
