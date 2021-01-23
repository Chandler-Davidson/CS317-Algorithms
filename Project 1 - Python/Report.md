## CS 317 - Project 1 Report

#### Given Input

Using the given 5x7 input matrix, the matrices reported the following:

    SortingMethod1
    	Comparisons made: 186
    	Assignments made: 270

    SortingMethod2
    	Comparisons made: 170
    	Assignments made: 345

    SortingMethod1 - SortingMethod2
    	Comparisons made: + 16
    	Assignments made: -75

By running through this example, I found that SortingMethod2 used 16 less comparisons and 75 more assignments than SortingMethod1. Given metrics alone, SortingMethod1 seems superior; however, the methods of accomplishing the task are fundamentally different. Method 1 sorts each element of the matrix individually, while Method 2 sorts rows, then columns. Each uses a different sample space to make comparisons.

#### 100x100 Matrix

Out of curiosity, I ran the same code against a 100x100 matrix of random numbers within the range 0-99, and received similar results to the first trial.

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

In both methods, we use QuickSort as our primary sorting algorithm; however, both differ by how the arrange their data into an applicable form.

For Method 1, the shape of the matrix will not affect the number of comparisons or assignments. Method 1 combines all of the elements then sorts a large array. Calling QuickSort externally once, thus runs in `Θ(x * y log(x * y))`.

For Method 2, the shape of the matrix does affect the comparisons and assignments. For instance, if we have a single row matrix, we will sort the single row `Θ(n log(n))`. However, if we have a matrix of 5 rows and 5 columns, we must sort each column and row individually which becomes `x( Θ(y log(y))) + y(Θ(x log(x)))`.

SortingMethod2 saw success by significantly reducing the input size for each call to QuickSort; however, SortingMethod1 saw marginal success by limiting reassignments and swaps by only calling QuickSort a single time.

#### Improving Complexity

When completing this assignment, I originally used the textbook definition of QuickSort. While the provided algorithm completed the job, it was fairly inefficient at two things: choosing a pivot and decision making at lower capacities. After doing some research, I choose the MedianOf3 partition method and wrote a manual sorting method once the size of the array reached three. These two improvements improved outlier scenarios that greatly improved comparison and assignment counts as input size grew.
