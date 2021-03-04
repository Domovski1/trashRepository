﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWord.Classes
{
    public class LevenshteinClass
    {
        public static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;



        /// <summary>
        /// Принимает два слова и возврашает число операций, необходимых совершить над первым словом, чтобы  получилось второе
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int Distance (string first, string second)
        {
            int n = first.Length + 1, m = second.Length + 1;
            const int delete = 1, insert = 1;
            var matrix = new int[n, m];

            if (first == null || second == null)
            {
                return -1;
            }

            for (int i = 0; i < n; i++) 
            {
                matrix[i, 0] = i;
            }

            for (int i = 0; i < m; i++)
            {
                matrix[0, i] = i;
            }


            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < m; j++)
                {
                    var sub = first[i - 1] == second[j - 1] ? 0 : 1;

                    matrix[i, j] = Minimum(matrix[i - 1, j] + delete, matrix[i, j - 1] + insert, matrix[i - 1, j - 1] + sub);
                    
                }
            }

            return matrix[n -1, m -1];
        }
        
    }
}
