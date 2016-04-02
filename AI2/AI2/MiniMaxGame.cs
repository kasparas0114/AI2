using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI2
{
    class MiniMaxGame
    {
        static public string[] gameBoard = new string[9];
        static public int depth;
       
        public string inverse(string level)
        {
            return (level.Equals("MIN")) ? "MAX" : "MIN";
        }
        public bool drawGame(string[] tempBoard)
        {
            for (int i = 0; i < 9; i++)
                if (tempBoard[i].Equals(" "))
                    return false;
            return true;
        }
        public bool GameOver(string[] tempBoard)
        {
            return ((Evaluate(tempBoard) != 0) ? true : false);
        }
        public bool HasWon(string[] b)
        { 
            if ((b[0].ToLower() == "o" && b[1].ToLower() == "0" && b[2].ToLower() == "o") ||//3 lines
                (b[3].ToLower() == "o" && b[4].ToLower() == "0" && b[5].ToLower() == "o") ||
                (b[6].ToLower() == "o" && b[7].ToLower() == "0" && b[8].ToLower() == "o") ||
                (b[0].ToLower() == "o" && b[3].ToLower() == "0" && b[6].ToLower() == "o") ||//3 rows
                (b[1].ToLower() == "o" && b[4].ToLower() == "0" && b[7].ToLower() == "o") ||
                (b[2].ToLower() == "o" && b[5].ToLower() == "0" && b[8].ToLower() == "o") ||
                (b[0].ToLower() == "o" && b[4].ToLower() == "0" && b[8].ToLower() == "o") ||//2 diagonals
                (b[6].ToLower() == "o" && b[4].ToLower() == "0" && b[2].ToLower() == "o"))
            {
                return true;
            }
            if ((b[0].ToLower() == "x" && b[1].ToLower() == "x" && b[2].ToLower() == "x") ||//3 lines
                (b[3].ToLower() == "x" && b[4].ToLower() == "x" && b[5].ToLower() == "x") ||
                (b[6].ToLower() == "x" && b[7].ToLower() == "x" && b[8].ToLower() == "x") ||
                (b[0].ToLower() == "x" && b[3].ToLower() == "x" && b[6].ToLower() == "x") ||//3 rows
                (b[1].ToLower() == "x" && b[4].ToLower() == "x" && b[7].ToLower() == "x") ||
                (b[2].ToLower() == "x" && b[5].ToLower() == "x" && b[8].ToLower() == "x") ||
                (b[0].ToLower() == "x" && b[4].ToLower() == "x" && b[8].ToLower() == "x") ||//2 diagonals
                (b[6].ToLower() == "x" && b[4].ToLower() == "x" && b[2].ToLower() == "x"))
            {
                return true;
            }
            return false;
        }
       
        public List<string[]> generateNodeChildren(string[] demo, string level)
        {//generate successor  
         //if level is MAX, generate successor with o (o in lowercase)  
         //if level is MIN, generate successor with x (x in lowercase)
         //if demo has no successor, return null  
            List<string[]> succ = new List<string[]>();
            for (int i = 0; i < 9; i++)
            {
                if (demo[i]==" ")
                {
                    string[] child = new string[9];
                    for (int j = 0; j < 9; j++)
                        child[j] = demo[j];
                    if (level.Equals("MAX"))
                        child[i] = "o";
                    else
                        child[i] = "x";
                    succ.Add(child);
                }
            }
            return (succ.Count() == 0) ? null : succ;
        }

        public ResultMinMax MinMax(string[] tempBoard,string level,int depth, int fils)
        {
          // generating child nodes
          List<string[]> children = generateNodeChildren(tempBoard,level);
          //check if there is children 
          if (children == null )
          {
              return new ResultMinMax(tempBoard, Evaluate(tempBoard), depth);
          }
          //there is children
            else
            {
                //recursion for all children
                List<ResultMinMax> resultList = new List<ResultMinMax>();
                foreach(var listItem in children)
                {
                    resultList.Add(MinMax(listItem, inverse(level), depth + 1,1));
                }
                //choose correct answer MIN or MAX
                ResultMinMax correctResult = chooseCorrectResult(resultList,level);
                if (fils == 1) { correctResult.updateMatrix(tempBoard); }
                return correctResult;
            }
        }
        public ResultMinMax chooseCorrectResult(List<ResultMinMax> resultList, string level)
        {
            ResultMinMax tempResult = resultList.First();
            if (level == "MAX")
            {
                foreach(var result in resultList)
                {
                   if((tempResult.getScore() < result.getScore()) ||((tempResult.getScore() == result.getScore()&&(result.depth<tempResult.depth))))
                    {
                        tempResult = result;
                    }
                }
            }
            else
            {
                foreach (var result in resultList)
                {
                    if ((tempResult.getScore() > result.getScore()) || ((tempResult.getScore() == result.getScore() && (result.depth < tempResult.depth))))
                    {
                        tempResult = result;
                    }
                }
            }
            return tempResult;
        }
        private int Evaluate(string[] gameBoard)
        {
            int score = 0;
            score += EvaluateLine(0, 1, 2, gameBoard);
            score += EvaluateLine(3, 4, 5, gameBoard);
            score += EvaluateLine(6, 7, 8, gameBoard);
            score += EvaluateLine(0, 3, 6, gameBoard);
            score += EvaluateLine(1, 4, 7, gameBoard);
            score += EvaluateLine(2, 5, 8, gameBoard);
            score += EvaluateLine(0, 4, 8, gameBoard);
            score += EvaluateLine(0, 4, 8, gameBoard);
            return score;
        }
        public int EvaluateLine(int cell1, int cell2, int cell3, string[] gameBoard)
        {
            int score = 0;
            if (gameBoard[cell1].ToLower() == "o")
            {
                score = 1;
            }
            else if (gameBoard[cell1].ToLower() == "x")
            {
                score = -1;
            }
            // Second cell
            if (gameBoard[cell2].ToLower() == "o")
            {
                if (score == 1)
                {   // cell1 is mySeed
                    score = 10;
                }
                else if (score == -1)
                {  // cell1 is oppSeed
                    return 0;
                }
                else {  // cell1 is empty
                    score = 1;
                }
            }
            else if (gameBoard[cell2].ToLower() == "x")
            {
                if (score == -1)
                { // cell1 is oppSeed
                    score = -10;
                }
                else if (score == 1)
                { // cell1 is mySeed
                    return 0;
                }
                else {  // cell1 is empty
                    score = -1;
                }
            }

            // Third cell
            if (gameBoard[cell3].ToLower() == "o")
            {
                if (score > 0)
                {  // cell1 and/or cell2 is mySeed
                    score *= 10;
                }
                else if (score < 0)
                {  // cell1 and/or cell2 is oppSeed
                    return 0;
                }
                else {  // cell1 and cell2 are empty
                    score = 1;
                }
            }
            else if (gameBoard[cell3].ToLower() == "x")
            {
                if (score < 0)
                {  // cell1 and/or cell2 is oppSeed
                    score *= 10;
                }
                else if (score > 1)
                {  // cell1 and/or cell2 is mySeed
                    return 0;
                }
                else {  // cell1 and cell2 are empty
                    score = -1;
                }
            }
            return score;
        }

    }
}
