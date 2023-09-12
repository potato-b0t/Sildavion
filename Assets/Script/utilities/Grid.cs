using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class Grid
    {
        private int width;
        private int height;
        private int[,] gridArray;

        public Grid(int width, int height)
        {
            this.width = width;
            this.height = height;

            gridArray = new int[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {

                }
            }
        }

        public void SetValue(int x, int y, int value)
        {
            if (x >= 0 && y >= 0 && x < width && y < height) gridArray[x, y] = value;

        }
    }
}

