# CubeMerge 

Program for merging Magic: The Gathering cube lists together.

Usage: <input file path 1> <input file path 2> <output file path>

files are expected to be tsv (tab separated values) without a header row in the format:

mask	key (i.e. unique card name)	other columns...

The program will read the first file and create a dictionary. The program will then read the second file, merging the content into the existing dictionary. The mask columns will be combined using a logical OR. The key column will be used as the dictionary key. The other columns will be preserved as-is.
