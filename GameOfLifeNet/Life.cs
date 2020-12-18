using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GameOfLifeNet
{
    public enum Status
    {
        Dead,
        Alive,
        Dead2
    }

    public class Life
    {
        public PictureBox PictureBox;
        Graphics g;
        Bitmap BitmapCanvas;
        readonly Brush BrushBlack = new SolidBrush(Color.Black);
        readonly Brush BrushWhite = new SolidBrush(Color.White);
        readonly Brush BrushYellow = new SolidBrush(Color.Yellow);
        readonly int TileWidth = 8;
        readonly int TileHeight = 8;
        int Rows;
        int Columns;
        Status[,] grid;
        int Count = 0;
        Random Random = new Random();
        int Frame = 0;

        public void Init()
        {
            Random Random = new Random();
            BitmapCanvas = new Bitmap(PictureBox.Width, PictureBox.Height);
            g = Graphics.FromImage(BitmapCanvas);
            Rows = PictureBox.Width / TileWidth;
            Columns = PictureBox.Height / TileHeight;
            grid = new Status[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    grid[row, column] = (Status)Random.Next(2);
                }
            }
        }

        void AddPixel()
        {
            int X = Random.Next(Rows - 2) + 1;
            int Y = Random.Next(Columns - 2) + 1;
            grid[X - 1, Y] = (Status)1;
            grid[X + 1, Y] = (Status)1;
            grid[X, Y - 1] = (Status)1;
            grid[X, Y + 1] = (Status)1;
        }

        public void Draw()
        {
            Print(grid);
            PictureBox.Image = BitmapCanvas;
            Frame++;
            grid = NextGeneration(grid);
            Count++;
            if (Count == 100)
            {
                Count = 0;
                AddPixel();
            }
        }

        void Save()
        {
            string Filename = "img/frame" + Frame.ToString("000000#") + ".png";
            BitmapCanvas.Save(Filename);
            //Debug.WriteLine(Filename);
        }

        Status[,] NextGeneration(Status[,] currentGrid)
        {
            Status[,] nextGeneration = new Status[Rows, Columns];
            for (int row = 1; row < Rows - 1; row++)
                for (int column = 1; column < Columns - 1; column++)
                {
                    int aliveNeighbors = 0;
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            aliveNeighbors += currentGrid[row + i, column + j] == Status.Alive ? 1 : 0;
                        }
                    }
                    Status currentCell = currentGrid[row, column];
                    aliveNeighbors -= currentCell == Status.Alive ? 1 : 0;
                    if (currentCell == Status.Alive && aliveNeighbors < 2)
                    {
                        nextGeneration[row, column] = Status.Dead;
                    }
                    else if (currentCell == Status.Alive && aliveNeighbors > 3)
                    {
                        nextGeneration[row, column] = Status.Dead2;
                    }
                    else if (currentCell != Status.Alive && aliveNeighbors == 3)
                    {
                        nextGeneration[row, column] = Status.Alive;
                    }
                    else
                    {
                        nextGeneration[row, column] = currentCell;
                    }
                }
            return nextGeneration;
        }

        void Print(Status[,] future)
        {
            Status cell;
            Rectangle Rect;
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    Rect = new Rectangle()
                    {
                        X = row * TileWidth,
                        Y = column * TileHeight,
                        Width = TileWidth,
                        Height = TileHeight
                    };
                    cell = future[row, column];
                    if (cell == Status.Alive)
                    {
                        g.FillRectangle(BrushWhite, Rect);
                    }
                    else if (cell == Status.Dead)
                    {
                        g.FillRectangle(BrushBlack, Rect);
                    }
                    else
                    {
                        g.FillRectangle(BrushBlack, Rect);
                    }
                }
            }
        }



    }



}
