import sys
import math

if len(sys.argv) > 3:
    print("usage: py file-comparisonin.py <CorrectFile.txt> <PredictionFile.txt>")

# Open files and convert the lines into lists
correct_file = open(str(sys.argv[1]),'r')
prediction_file = open(str(sys.argv[2]), 'r')

correct_file_lines = correct_file.readlines()
prediction_file_lines = prediction_file.readlines()


# Iterate over the lists and count the differences
incorrect_count = 0

for i in range(0, len(correct_file_lines)):
    if correct_file_lines[i] != prediction_file_lines[i]: incorrect_count+=1

# Calculate percent correct
base = len(correct_file_lines) + 1
correct = base - incorrect_count
percent_correct = float(math.floor((100.0) * (correct / base)))

# Calculate percent error
# percent error =  (|(theoretical - experimental)| / 100%) * 100
percent_error = (abs(base - correct) / 100) * 100

# print out information
print("File difference statistics")
print("Basefile: " + str(correct_file.name))
print("Diff File: " + str(prediction_file.name))
print("Ammount of differences: " + str(incorrect_count))
print("Percent correct: " + str(percent_correct))
print("Percent error: " + str(percent_error))
