# CSV Parser

## Overview
This is a simple CSV parser that allows users to extract values from specific columns in CSV files and save them to a new text file. Each value is on a new line, without additional punctuation marks and brackets. Designed to handle both command line arguments and interactive prompts.

## How to Use

### From the Command Line
To use CsvParser from the command prompt, you can pass arguments in a specific order as defined by the `CommandLineArgs` enum in the code. Here's the order to follow:

1. **CsvFilePath (0):** Path to the CSV file you want to parse.
2. **OutputFilePath (1):** Path where the output file will be saved.
3. **ColumnName (2):** Name of the column from which to extract values.

Example command:
```cmd
./CsvParser.exe [path to csv file] [path to output file] [column name]
```

Alternatively, you can start the application without any arguments by running:
```cmd
./CsvParser.exe
```

In this mode, the program will interactively prompt you to provide the CSV file path, output file path, and column name through a user-friendly command line interface.

### Output Format
The output file will contain data extracted from the specified column in the input CSV file. Each piece of data is presented on a new line, formatted cleanly without brackets or additional punctuation.


## Usage Scenarios

### Converting a CSV File with IP addresses to Hostfile for OpenMPI
Scenario: You have a CSV file with results of the Azure Resource Graph query results that contains VMs IP addresses, and you need to convert this data into a hostfile format for OpenMPI.

Steps:
1. Identify the column in the CSV that contains the IP addresses.
2. Run the CsvParser with the CSV file path, the output file path for the hostfile, and the column name containing the IPs.

Example:
```cmd
CsvParser.exe azure_vms.csv hostfile.txt IPAddress
```

This will generate a hostfile with each IP address on a new line, suitable for use with OpenMPI configurations.

