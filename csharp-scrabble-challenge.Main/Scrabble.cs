﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble
    {
        
        private readonly string word;
        private static readonly Dictionary<char, int> letterScores = new Dictionary<char, int>
        {
            {'A', 1}, {'E', 1}, {'I', 1}, {'O', 1}, {'U', 1}, {'L', 1}, {'N', 1}, {'R', 1}, {'S', 1}, {'T', 1},
            {'D', 2}, {'G', 2},
            {'B', 3}, {'C', 3}, {'M', 3}, {'P', 3},
            {'F', 4}, {'H', 4}, {'V', 4}, {'W', 4}, {'Y', 4},
            {'K', 5},
            {'J', 8}, {'X', 8},
            {'Q', 10}, {'Z', 10}
        };
        public Scrabble(string word)
        {
            this.word = word.ToUpper();
        }

        public int score()
        {
            int score = 0;
            int multiplier = 1;

            foreach (char letter in word)
            {
                if (letter == '{')
                {
                    // Double word
                    multiplier *= 2;
                }
                else if (letter == '[')
                {
                    // Triple word
                    multiplier *= 3;
                }
                else
                {
                    if (letterScores.TryGetValue(letter, out int letterScore))
                    {
                        score += letterScore;
                    }
                }
            }

            return score * multiplier;
        }
    }
}
