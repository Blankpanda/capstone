# Image viewer

### Purpose: A system to test human parsing of written numbers

This code is really bad but we needed to develop it quickly due to time limitations, this application is an internal tool for us to collect the human data versus the machine data.

Desktop application to test number accuracy written in C# WPF

Files can be found in
 ```
  ImageViewer/*
 ```

---

## Features

#### Data reader
  - Takes the raw input images for the application interface
    - The images file name indicates what the number actually is

#### Input Parser
  - Works with the files inside to see if what the user input was correct
  - Stores this information to a local database/data file


#### interface
- Main interface with:
  - Image at the center with the number
  - Submit button
    - Validates user input
    - Works with the input parser to determine if it was correct or not
  - Input box: Takes user input
