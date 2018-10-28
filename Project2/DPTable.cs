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
            for (int i = 0; i < freq.Count; i++)
            {
                this.Add(new List<int>(freq.Count));

                for (int j = 0; j < freq.Count; j++)
                {
                    this[i].Add(0);
                }
            }

            int n = freq.Count - 1;

            for (int i = 0; i < n; i++)
                this[i][i] = freq[i];

            for (int L = 2; L <= n; L++)
            {
                for (int i = 0; i <= n - L + 1; i++)
                {
                    int j = i + L - 1;
                    this[i][j] = int.MaxValue;

                    for (int r = i; r <= j; r++)
                    {
                        int c = ((r > i) ? this[i][r - 1] : 0)
                            + ((r < j) ? this[r + 1][j] : 0) 
                            + Sum(freq.ToArray(), i, j);

                        if (c < this[i][j])
                            this[i][j] = c;
                    }
                }
            }
        }

        internal int Sum (int[] freq, int i, int j)
        {
            int sum = 0;
            for (int k = i; k <= j; k++)
            {
                if (k >= freq.Length)
                    continue;
                sum += freq[k];
            }

            return sum;
        }

        public string ToTree()
        {
            throw new NotImplementedException();
            return ToTree(this, 1, this.Count - 1, 0);
        }

        private string ToTree(List<List<int>> roots, int i, int j, int space_needed)
        {
            throw new NotImplementedException();

            if (i <= j)
            {
                var output = new string(' ', space_needed) + roots[i][j];

                ToTree(roots, i, roots[i][j] - 1, space_needed++);

                ToTree(roots, roots[i][j] + 1, j, space_needed++);
            }
        }

        public override string ToString()
        {
            var output = "";

            for (int i = 0; i < this.Count; i++)
            {
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
