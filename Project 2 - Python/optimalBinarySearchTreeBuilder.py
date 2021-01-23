INT_MAX = 2147483647

""" Generate an optimal binary search tree from
the given keys(indexes) and probabilities. """


def optimalSearchTree(keys, prob):
    length = len(keys)

    # 2D matrix buffer for resulting subproblems
    # cost[i][j] = Optimal cost of bst formed from keys[i] to keys[j]
    cost = [[0 for x in range(length)]
            for y in range(length)]

    # Fill diagonal of table,
    # cost is the probability of the key
    for i in range(length):
        cost[i][i] = (keys[i], prob[i])

    # Now we need to consider chains of length >= 2.
    # L is the chain length.
    for L in range(2, length + 1):

        # i is row number in cost
        for i in range(length - L + 2):

            # Get column number j from row number
            # i and chain length L
            j = i + L - 1
            if i >= length or j >= length:
                break
            cost[i][j] = (keys[i], INT_MAX)

            # Try making all keys in interval
            # keys[i..j] as root
            for r in range(i, j + 1):

                # c = cost when keys[r] becomes root
                # of this subtree
                c = 0
                if (r > i):
                    c += cost[i][r - 1][1]
                if (r < j):
                    c += cost[r + 1][j][1]
                c += sublistSum(prob, i, j)
                if (c < cost[i][j][1]):
                    cost[i][j] = (keys[r], c)
    return (cost, cost[0][length - 1][1])


# Returns the sum of the range i to j within a list
def sublistSum(list, i, j):
    return sum(list[i:j + 1])
