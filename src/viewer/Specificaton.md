# Image viewer

### Purpose: A system to test human parsing of written numbers

Java desktop application because bailey doesn't know any other language

Files can be found in
 ```
  NumberViewer/*
 ```
Development tools can be found in
```
tools/*
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
