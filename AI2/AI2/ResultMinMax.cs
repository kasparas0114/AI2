using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI2
{
    class ResultMinMax
    {
        public string[] matrix;
        public int score;
        public int depth;
        public ResultMinMax(string[] matrix, int score, int depth)
        {
            this.matrix = matrix;
            this.score = score;
            this.depth = depth;
        }
        public void updateMatrix(string[] matrix)
        {
            this.matrix = matrix;
        }
        public int getScore()
        {
            return score;
        }
        public int getIntrus()
        {
            for (int i = 0; i < 9; i++)
                if (matrix[i].Equals("o"))
                    return i;
            return -1;
        }
    }
}
