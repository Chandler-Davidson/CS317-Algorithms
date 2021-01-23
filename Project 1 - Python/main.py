from matrixparser import MatrixParser
from matrixsorter import MatrixSorter

# Parse the given input file
parser = MatrixParser()
matrix = parser.parseFile()

sorter = MatrixSorter()

# Sort the matrix, then print to file and screen
matrix1 = sorter.sortingMethod1(matrix)
parser.printMatrix('cmd0031_1.txt', "SortingMethod1", matrix1,
                   sorter.comparisonCount, sorter.assignmentCount)

# Sort the matrix, then print to file and screen
matrix2 = sorter.sortingMethod2(matrix)
parser.printMatrix('cmd0031_2.txt', "SortingMethod2", matrix2,
                   sorter.comparisonCount, sorter.assignmentCount)
