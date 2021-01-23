class MatrixSorter:
    # Tracks the number of comparisons and assignments
    comparisonCount = 0
    assignmentCount = 0

    # Sorting Method 1: flattens the matrix and sorts the larger array
    def sortingMethod1(self, matrix):
        self.comparisonCount = 0
        self.assignmentCount = 0

        # Flatten matrix into a single array
        flatMatrix = [item for sublist in matrix for item in sublist]

        # Sort the entire array
        sortedFlatMatrix = self.quicksort(flatMatrix, 0, len(flatMatrix) - 1)

        # Return the array to a matrix
        return toMatrix(sortedFlatMatrix, len(matrix[0]))

    # Sorting Method 2: sorts each row, then column of the array individually
    def sortingMethod2(self, matrix):
        self.comparisonCount = 0
        self.assignmentCount = 0

        # Sort each row
        sortedRows = list(
            map(lambda row: self.quicksort(row, 0, len(row) - 1), matrix))

        # Sort each column
        matrix = rotateMatrix(sortedRows)
        sortedCols = list(map(lambda row: self.quicksort(
            row, 0, len(row) - 1), matrix))

        # Return the matrix in the original structure
        return rotateMatrix(sortedCols)

    # Implementation of quick sort using median of 3 method and manual sorting given the array size
    def quicksort(self, arr, low, high):
        size = high - low + 1

        # Manually sorting here reduces the number of assigns/compares (non greedy at this point)
        if size <= 3:
            self.manualSort(arr, low, high)
        else:
            median = self.medianOf3(arr, low, high)
            part = self.partition(arr, low, high, median)

            self.quicksort(arr, low, part - 1)
            self.quicksort(arr, part + 1, high)
        return arr

    # Use for manually sorting the array when it is obvious
    def manualSort(self, arr, low, high):
        size = high - low + 1

        if size <= 1:
            return

        if size == 2:
            if self.greaterThan(arr[low], arr[high]):
                self.swapElements(arr, low, high)
            return

        if self.greaterThan(arr[low], arr[high - 1]):
            self.swapElements(arr, low, high - 1)

        if self.greaterThan(arr[low], arr[high]):
            self.swapElements(arr, low, high)

        if self.greaterThan(arr[high - 1], arr[high]):
            self.swapElements(arr, high - 1, high)

    # Implementation of median of 3 to lower the number of overall assignments
    def medianOf3(self, arr, low, high):
        center = (low + high) // 2

        if self.greaterThan(arr[low], arr[center]):
            self.swapElements(arr, low, center)

        if self.greaterThan(arr[low], arr[high]):
            self.swapElements(arr, low, high)

        if self.greaterThan(arr[center], arr[high]):
            self.swapElements(arr, center, high)

        self.swapElements(arr, center, high - 1)

        return arr[high - 1]

    # Implementation of partion
    def partition(self, arr, low, high, pivot):
        left = low - 1

        for right in range(low, high):
            if self.greaterThan(pivot, arr[right]):
                left = left + 1
                self.swapElements(arr, left, right)
        self.swapElements(arr, left + 1, right)
        return left + 1

    # GREATER THAN
    # Compares two elements within an array, is a member function to store assignments/comparisions
    def greaterThan(self, first, second):
        self.comparisonCount += 1

        return first > second

    # LESS THAN
    # Compares two elements within an array, is a member function to store assignments/comparisions
    def lessThan(self, first, second):
        self.comparisonCount += 1

        return first < second

    # EQUAL TO
    # Compares two elements within an array, is a member function to store assignments/comparisions
    def equalTo(self, first, second):
        self.comparisonCount += 1

        return first == second

    # ASSIGN, swaps the elements between two indices
    # Swaps two elements within an array, is a member function to store assignments/comparisions
    def swapElements(self, arr, indexA, indexB):
        self.assignmentCount += 3

        temp = None
        temp = arr[indexA]
        arr[indexA] = arr[indexB]
        arr[indexB] = temp


def rotateMatrix(matrix):
    # Pivots the matrix 45 degrees
    shiftedMatrix = []

    for i in range(len(matrix[0])):
        shiftedMatrix = shiftedMatrix + [list(map(lambda x: x[i], matrix))]

    return shiftedMatrix


def toMatrix(arr, rowLength):
    # Converts a flat array to a matrix of the given row length
    matrix = []

    for i in range(0, len(arr)):
        if i % rowLength == 0:
            matrix.append([])
        matrix[i // rowLength].append(arr[i])

    return matrix
