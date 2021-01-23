## Project 1

#### Program Requirements

1. Read a matrix from a file
2. Sort the matrix 
	1. Method 1: 
		- Combine all of the elements into a single array
		- Sort the entire array
	2. Method 2:
		- Sort the elements of each row
		- Sort the elements of each column
3. Write the results of each matrix sorting method to a file

#### Array Sorting
 - Arrays must be sorted using a variation of QuickSort 
 - Track the number of comparisons and assignments of elements
 - Attempt to limit the number of comparisons and assignments
 - Must implement custom comparison and assignment functions.

#### File Output
 - There must be two reports, one for each matrix sorting method
 - Matrices must be formatted legibly

#### Above and Beyond
Just for fun, I wrote a custom generic matrix class that supports any type that implements `IComparable`. This allowed me to test my implementation using `int` or any other type.
