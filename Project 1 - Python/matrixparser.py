class MatrixParser:

    # Parses the given file to a 2D array of float
    def parseFile(self, filepath='input.txt'):
        # Open and read file
        file = open(filepath, 'r')
        text = file.read().split('\n')

        # Remove the first line, not necessary
        text.pop(0)

        # Remove any empty rows
        text = list(filter(lambda x: len(x) != 0, text))

        # Parse file's text and convert to a 2D float array
        return rowsToNumbers(text)

    # Prints the matrix to screen and given file
    def printMatrix(self, filename, sortingMethod, matrix, comparisons, assignments):
        matrixStr = matrixToString(matrix)

        f = open(filename, "w")
        f.write(sortingMethod + "\n")
        f.write("Comparisons: " + str(comparisons) + "\n")
        f.write("Assignments: " + str(assignments) + "\n\n")
        f.write(matrixStr)
        f.close()

        print(sortingMethod + "\n")
        print("Comparisons: " + str(comparisons) + "\n")
        print("Assignments: " + str(assignments) + "\n\n")
        print(matrixStr)


# Splits elements by removing whitespace and parses floats
def rowsToNumbers(arr):
    # Split elements into sub arrays
    rowsStr = [row.split() for row in arr]

    # Iterate through each element of 2D array and parse
    rowsNum = [[float(el) for el in row] for row in rowsStr]

    return rowsNum


# Returns a 2D matrix in a pretty string
def matrixToString(matrix):
    result = ''

    # Concat each row of the matrix
    for row in matrix:
        result += ''.join(map(lambda x: str(x).rjust(8), row))
        result += '\n\n'

    return result
