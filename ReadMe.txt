Programming Problem - Find Longest Word Made of Other Words
======================

Write a program that reads a file containing a sorted list of words (one
word per line, no spaces, all lower case), then identifies the longest
word in the file that can be constructed by concatenating copies of
shorter words also found in the file.

For example, if the file contained:

       cat
       cats
       catsdogcats
       catxdogcatsrat
       dog
       dogcatsdog
       hippopotamuses
       rat
       ratcatdogcat

The answer would be 'ratcatdogcat' - at 12 letters, it is the longest
word made up of other words in the list.  The program should then
go on to report how many of the words in the list can be constructed 
of other words in the list.


How to USE the program :


// Compile the program 
SWEDotNetTest_FindLongestWord 


// Run the program
Press F5 to run the program. The input.txt file is included in the project file


// The output will show following things
1) The longest words that can be made of other words
3) The second longedt words that can be made of other words



Other Ways to solve the program:

1) This problem can also be easily solved using a "Trie data structure"
2) First I sort the strings in descending order "Lengthwise".
3) Start with the first string and loop over sorted strings
4) Check if it can be made of other words by dividing strings into all possible combinations and doing same thing for each splits.
5) Retrun true if it is made of other strings and Save that string onto an array list.
6) Return the top string because that would be the longest string.
7) The size of array list will give you the total number of words that can be made of other words.

