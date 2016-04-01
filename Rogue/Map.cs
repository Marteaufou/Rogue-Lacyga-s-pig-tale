using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Rogue
{


    public class Map
    {
        private uint width; //Width of the maze
        private uint height; //Height of the maze
        private Cell[,] maze; //Array (dimension 2) which contains all ths cells
        private uint[] posStart;//The position (x, y) of the start
        private uint[] posEnd;//The position (x, y) of the end
        private Random rand; //A random number generator
        public Map(uint width, uint height, uint xStart, uint yStart, uint xEnd, uint yEnd)
        {


            rand = new Random();
            this.width = width;
            this.height = height;
            uint[] postr = { xStart, yStart};
            this.posStart = postr;
            uint[] posen = { xEnd, yEnd };
            this.posEnd = posen;
            maze = new Cell[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    maze[i, j] = new Cell();
                }

            }

            maze[xStart, yStart] = new Cell(Type.START, 0);
            maze[xEnd, yEnd] = new Cell(Type.END);





        }

        #region get/set
        public uint[] endpos
        {
            get { return posEnd; }
        }

        #endregion



        #region Generation
        private List<uint[]> getNotVisitedNeighbor(uint x, uint y)
        {
            List<uint[]> vois = new List<uint[]>();
            if (x > 0 && !maze[x - 1, y].getVisited())
            {
                uint[] pos = {  x - 1, y};
                vois.Add(pos);
            }
            if (x < width - 1 && !maze[x + 1, y].getVisited())
            {
                uint[] pos = { x + 1, y};
                vois.Add(pos);
            }
            if (y > 0 && !maze[x, y - 1].getVisited())
            {
                uint[] pos = { x, y - 1};
                vois.Add(pos);
            }
            if (y < height - 1 && !maze[x, y + 1].getVisited())
            {
                uint[] pos = { x, y + 1};
                vois.Add(pos);
            }
            return vois;
        }
        public void generate()
        {
            generateRec((uint)rand.Next((int)width), (uint)rand.Next((int)height));

        }

        /*private List<uint[]> getNotlinkedNeighbor(uint x, uint y)
        {
            List<uint[]> vois = new List<uint[]>();
            if (x > 0 && !maze[x - 1, y].isLinked(x, y))
            {
                vois.Add(new uint[](x - 1, y));
            }
            if (x < width - 1 && !maze[x + 1, y].isLinked(x, y))
            {
                vois.Add(new uint[](x + 1, y));
            }
            if (y > 0 && !maze[x, y - 1].isLinked(x, y))
            {
                vois.Add(new uint[](x, y - 1));
            }
            if (y < height - 1 && !maze[x, y + 1].isLinked(x, y))
            {
                vois.Add(new uint[](x, y + 1));
            }
            return vois;
        }
        private void eraseWall(int n)
        {
            for (int i = 0; i < n; i++)
            {
                int x = rand.Next((int)width);
                int y = rand.Next((int)height);

                List<uint[]> notlinked = getNotlinkedNeighbor((uint)x, (uint)y);
                int len = notlinked.Count;
                if (len > 0)
                {
                    uint[] c2 = notlinked[rand.Next(notlinked.Count)];

                    uint[] c1 = new uint[]((uint)x, (uint)y);

                    maze[c2.Item1, c2.Item2].addLink(c1);


                    maze[x, y].addLink(c2);

                }


            }
        }
        */
        private void generateRec(uint x, uint y)
        {
            maze[x, y].setVisited(true);

            List<uint[]> vois = getNotVisitedNeighbor(x, y);

            int len = vois.Count;
            while (len > 0)
            {

                uint[] c2 = vois[rand.Next(len)];
                maze[c2[0], c2[1]].setVisited(true);
                maze[x, y].addLink(c2);
                uint[] pos = {x, y };
                maze[c2[0], c2[1]].addLink(pos);
                generateRec(c2[0], c2[1]);
                vois = getNotVisitedNeighbor(x, y);
                len = vois.Count;
            }



        }

        #endregion

    }
}
