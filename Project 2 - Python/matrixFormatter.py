# Creates a display friendly string from a 2D matrix
def formatMatrix(matrix):
    # return ('\n'.join(['\t\t'.join([str(cell) for cell in row]) for row in matrix]))
    s = [[str(e) for e in row] for row in matrix]
    lens = [max(map(len, col)) for col in zip(*s)]
    fmt = '\t'.join('{{:{}}}'.format(x) for x in lens)
    table = [fmt.format(*row) for row in s]
    return '\n'.join(table)


# Adds table labeling for top row and columns
def addLabeling(matrix):
    # Create column label
    for i, row in enumerate(matrix):
        matrix[i].insert(0, "{:02}".format(i))

    # Create header label
    header = map(lambda x: "{:02}".format(x), range(-1, len(matrix[0])))
    matrix.insert(0, header)

    return matrix
