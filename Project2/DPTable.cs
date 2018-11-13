using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class DPTable : List<List<int>>
    {
        /// <summary>
        /// Builds a Dynamic Programming Table 
        /// representing an Optimal Binary Search Tree
        /// </summary>
        /// <param name="freq"></param>
        public DPTable(List<int> freq)
        {
            int n = freq.Count;

            // 2D Array as DP Table to store sub-problems,
            // Inits all indexes to zero
            int[,] table = new int[n + 1, n + 1];

            // Fill in initial probabilities
            for (int i = 0; i < n; i++)
                table[i, i] = freq[i];

            // Iterate through the chains of the tree
            for (int chain = 2; chain <= n; chain++)
            {

                // Iterate through each row
                for (int row = 0; row <= n - chain + 1; row++)
                {

                    // Get the column index
                    int col = row + chain - 1;
                    table[row, col] = int.MaxValue; // Initial max value

                    // Minimizing Reccurrance
                    for (int r = row; r <= col; r++)
                    {

                        // Cost when keys[r] becomes root of this subtree
                        int cost = ((r > row) ? table[row, r - 1] : 0)
                            + ((r < col) ? table[r + 1, col] : 0) + sum(freq.ToArray(), row, col);

                        // Choose the smaller value
                        if (cost < table[row, col])
                            table[row, col] = cost;
                    }
                }
            }

            // Local function to get the sum of arr[i] to arr[j]
            int sum(int[] arr, int i, int j)
            {
                int s = 0;
                for (int k = i; k <= j; k++)
                {
                    if (k >= arr.Length)
                        continue;
                    s += freq[k];
                }

                return s;
            }

            // Copy the results of cost[,] to the List<List<int>>
            for (int i = 0; i < freq.Count; i++)
            {
                this.Add(new List<int>());
                for (int j = 0; j < freq.Count; j++)
                    this[i].Add(table[i, j]);
            }
        }



        public void ToTree()
        {
            //throw new NotImplementedException();
            ToTree(this, 1, this.Count - 1, 0);
        }

        private void ToTree(List<List<int>> roots, int i, int j, int space_needed)
        {
            //throw new NotImplementedException();

            if (i <= j)
            {
                Console.WriteLine(new string(' ', space_needed) + roots[i][j]);

                ToTree(roots, i, roots[i][j] - 1, space_needed++);

                ToTree(roots, roots[i][j] + 1, j, space_needed++);
            }
        }

        public override string ToString()
        {
            var output = "  ";

            for (int i = 0; i < this[0].Count; i++)
                output += i.ToString().PadLeft(5);
            output += "\n\n\n";

            for (int i = 0; i < this.Count; i++)
            {
                output += i.ToString() + "  ";
                for (int j = 0; j < this[i].Count; j++)
                {
                    output += this[i][j].ToString().PadLeft(5);
                }

                output += "\n\n";
            }

            return output;
        }
    }
}
