Multiple Search Replace 0.1, copyfree 2005, Rob Vonk


Multiple search replace is a tool that allows you to search and replace
multiple strings in a single file. The search and replace keywords are
stored in a datafile so that you can re-run the same search and replace
sequence multiple times.

Usage: MSR sourcefile datafile

The format of a line in the datafile is like this:

Source,Target,Case sensitive,Description

- Source is the source data. You can use any sequence of ascii characters.
- Replace is the replace data. You can use any sequence of ascii characters.
- Case sensitive determines if the search should be done case sensitive.
  Use 1 for case sensitive and 0 for non-case sensitive
- Description allows you to put a description on the line.

You can have multiple lines in the datafile.

After searhing and replacing, the new file will have the extention _replaced 
added. For example: myfile.txt will become myfile_replaced.txt
