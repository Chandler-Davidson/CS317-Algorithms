from fileParser import parseFile, printTable
from optimalBinarySearchTreeBuilder import optimalSearchTree
from binaryTree import generateTree

# Create two lists of probabilities and indexes
prob = parseFile()
keys = list(range(0, len(prob)))

# Generate optimal binary search tree
results = optimalSearchTree(keys, prob)

table = results[0]
cost = results[1]

tree = generateTree(table)
# printTable('cmd0031.txt', table)
