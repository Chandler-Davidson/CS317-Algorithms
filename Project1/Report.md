## CS 317 - Project 1 Report

#### Given Input
Using the given 5x7 input matrix, the matrices reported the following:

	SortingMethod1
		Comparisons made: 154
		Assignments made: 159

	SortingMethod2
		Comparisons made: 146
		Assignments made: 246

	SortingMethod1 - SortingMethod2
		Comparisons made: + 8
		Assignments made: -87

SortingMethod2 used 8 less comparisons and 87 more assignments than SortingMethod1. With no further knowledge, one might assume that SortingMethod1 is the greater algorithm because it used significantly less comparisons; however, the two algorithms accomplish two different goals. SortingMethod1 sorts the matrix left to right and SortingMethod2 sorts the matrix from the top left corner to the bottom right corner. For example:

	SortingMethod1
        L O W ---------▶---------▶---------▶---------▶----------▶
		|--------------------------------------------------------|
		| 0       0       0       1       1       1       2      |
		|                                                        |
		| 2       2       2       2       2       2       2      |
		|                                                        |
		| 2       3       4       4       5       5.21    6.6	 |
		|                                                        |
		| 6.6     7       7       8       8       9       14     |
		|                                                        |
		| 17      18.32   19      28.77   31      51.3    200.36 |
		|--------------------------------------------------------|
		---------▶---------▶---------▶---------▶--------▶ H I G H

	SortingMethod2
            L O W ---------▶---------▶---------▶---------▶----------▶
	      L |--------------------------------------------------------|  | 
	      O | 0       1       2       2       2       2       2      |  | 
	      W |                                                        |  ▼ 
	      | | 0       1       2       5       6.6     7       9      |  | 
	      | |                                                        |  | 
	      ▼ | 0       2       4       5.21    7       8       19     |  ▼ 
	      | |                                                        |  
	      | | 1       2       4       6.6     8       18.32   51.3   |  H 
	      ▼ |                                                        |  I 
	      | | 2       3       14      17      28.77   31      200.36 |  G 
	      | |--------------------------------------------------------|  H 
		---------▶---------▶---------▶---------▶--------▶ H I G H

#### 100x100 Matrix
When running the same application with a 100x100 matrix of random numbers within the range 0-99, the two sorting methods followed similar trends from the first test. 

	SortingMethod1
		Comparisons made: 140,758
		Assignments made: 120,393

	SortingMethod2
		Comparisons made: 125,787
		Assignments made: 123,600

	SortingMethod1 - SortingMethod2
		Comparisons made: +14,971
		Assignments made: - 3,207

#### Theory
In theory, QuickSort's average case is `Θ(n log(n))` and because both sorting methods use the same input we do not have to compare a best vs worst case. Suppose we have a matrix that has `x` columns and `y` rows.


SortingMethod1 sorts all of the elements of the matrix in a single array, calling QuickSort externally once, thus runs in `Θ(x * y log(x * y))`.


SortingMethod2 sorts each row, then sorts each column. This will run QuickSort x times with y elements and y times with x elements. SortingMethod2 will run in `x( Θ(y log(y))) + y(Θ(x log(x)))`.


SortingMethod2 saw success by significantly reducing the input size for each call to QuickSort; however, SortingMethod1 saw marginal success by limiting reassignments and swaps by only calling QuickSort a single time.

#### Improving Complexity
When completing this assignment, I originally used the textbook definition of QuickSort. While the provided algorithm completed the job, it was fairly inefficient at two things: choosing a pivot and decision making at lower capacities. After doing some research, I choose the MedianOf3 partition method and wrote a manual sorting method once the size of the array reached three. These two improvements improved outlier scenarios that greatly improved comparison and assignment counts as input size grew.


#### Generics and Continued Support
While completing the project, I kept considering the idea of abstraction within algorithms and as Dr. Sadish explains `the cost` of an algorithm. Thus, I decoupled the sorting/comparison classes from the given data type. So feel free to input a matrix of `doubles`, `integers`, `strings`, or any ADT as long as it implements `IComparable`.