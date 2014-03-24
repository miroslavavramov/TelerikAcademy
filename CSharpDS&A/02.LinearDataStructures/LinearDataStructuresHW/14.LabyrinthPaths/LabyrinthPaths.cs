﻿/*
 * We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x). 
 * We can move from an empty cell to another empty cell if they share common wall. 
 * Given a starting position (*) calculate and fill in the array the minimal distance from this 
 * position to any other cell in the array. Use "u" for all unreachable cells.
*/
using System;

class LabyrithPaths
{
    static string[,] grid = new string[,]
    {
     { "0", "0", "0", "x", "0", "x" },
     { "0", "x", "0", "x", "0", "x" },
     { "0", "0", "x", "0", "x", "0" },
     { "0", "x", "0", "0", "0", "0" },
     { "0", "0", "0", "x", "x", "0" },
     { "0", "0", "0", "x", "0", "x" },
    };

    static void Main()
    {
        //TODO: Solve
    }
}


