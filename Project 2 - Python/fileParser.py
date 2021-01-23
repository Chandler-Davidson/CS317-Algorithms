from matrixFormatter import addLabeling, formatMatrix


def parseFile(filepath='input.txt'):
    # Open and read file
    file = open(filepath, 'r')
    text = file.read().split('\n')

    # Remove the first line, not necessary
    text.pop(0)

    # Remove any empty rows
    text = filter(lambda x: len(x) != 0, text)

    # Map list to int
    freq = list(map(int, text))

    return freq


# Prints the matrix to screen and given file
def printTable(filename, matrix):
    formattedMatrix = formatMatrix(addLabeling(matrix))

    f = open(filename, "w")
    f.write('Format: (root, cost)')
    f.write(formattedMatrix)
    f.close()

    print('Format: (root, cost)')
    print(formattedMatrix)
