using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Rogue
{
    enum Type
    {
        START, //The start of the maze
        END, //The end of the maze
        PATH, //For the cells which belong to the path once the maze solved
        NONE, //Default type
        PLAYER
    };

    class Cell
    {

        private List<uint[]> linked; //Contains the list of the position of the cells which are linked with this cell
        private Type type; //The type of the cell
        private bool visited; //Store if the cell was visited
        private int rank;

        public Cell(Type type = Type.NONE, int rank = -1)
        {
            this.type = type;
            this.linked = new List<uint[]>();
            this.visited = false;
            this.rank = rank;


        }

        #region Initialization
        public Type getType()
        {
            return type;

        }

        public List<uint[]> getLinkedList()
        {

            return linked;
        }


        public void setVisited(bool b)
        {
            visited = b;
        }

        public bool getVisited()
        {
            return visited;
        }

        public int getrank()
        { return rank; }

        public void setrank(int i)
        {
            rank = i;
        }
        #endregion




        #region Generation

        public void addLink(uint[] posToLink)
        {
            linked.Add(posToLink);
        }

        public bool isLinked(uint x, uint y)
        {
            uint[] link = { x, y };
            return linked.Contains(link);

        }
        #endregion

        #region Solve
        public void isPath()
        {
            if (this.type == Type.NONE)
            {
                this.type = Type.PATH;
            }
        }

        public void isPlayer()
        {
            if (this.type == Type.NONE)
            {
                this.type = Type.PLAYER;
            }
        }

        public void isNone()
        {
            this.type = Type.NONE;
        }

        public void isStart()
        {
            if (this.type == Type.NONE)
            {
                this.type = Type.START;
            }
        }
        #endregion


    }
}

