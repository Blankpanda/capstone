"""
    this will read the Short.csv file
    and convert the seconds column into
    a dictionary that holds an index and
    a number based on the value at that
    index.  This is to be used when pairing
    values in the viewer.
    for instance:
        m7.jpg -> key: 7 value: 3
"""

import pandas as pd
import json

def main():

    infile = 'Short.csv' # the csv file that were reading
    short_data_frame = pd.read_csv(infile) # conver the csv into a data frame

    # extract the content we need and then save it to a dictionary
    numbers = short_data_frame.label
    numbers_dict = {}

    for i in range(0, len(numbers)):
        numbers_dict[int(i)] = str(numbers[i])

    # convert the dictionary to a json file
    numbers_json = json.dumps(numbers_dict)

    # sort the dictionary
    sorted(numbers_dict.items(), key=lambda x: x[1])
    # write the json to a file
    out = open('numbers.json', 'w')
    out.write(numbers_json)

if __name__ == '__main__':
    main()
