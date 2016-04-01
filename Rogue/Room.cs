using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum Type
{
    SINGLE,
    LINE,
    COLUMN,
    SQUARE
};

public class Room : MonoBehaviour
{

    List<Standard> Pieces;
    int x, y;
    public Type type;

    public Room()
    {
        this.type = type;
        List<Standard> Pieces = new List<Standard>();
        switch (type)
        {
            case Type.SINGLE:
                Pieces = Single();
                break;

            case Type.LINE:
                break;

            case Type.COLUMN:
                break;

            case Type.SQUARE:
                break;

            default:
                break;
        }
    }

    #region Salles
    List<Standard> Single()//Salles simples
    {
        List<Standard> single = new List<Standard>();


        List<Link> Walls = new List<Link>();
        Walls.Add(new Link(Position.TOP)); // met 4 murs à un standard
        Walls.Add(new Link(Position.BOT));
        Walls.Add(new Link(Position.RIGHT));
        Walls.Add(new Link(Position.LEFT));

        Standard simple = new Standard(this, x, y, Walls);


        single.Add(simple);

        return single;
    }

    List<Standard> Line()
    {
        List<Standard> line = new List<Standard>();


        List<Link> Walls = new List<Link>();
        Walls.Add(new Link(Position.TOP));
        Walls.Add(new Link(Position.BOT));
        Walls.Add(new Link(Position.LEFT));

        Standard left = new Standard(this, x, y, Walls);
        line.Add(left);

        Walls = new List<Link>();
        Walls.Add(new Link(Position.TOP));
        Walls.Add(new Link(Position.BOT));
        Walls.Add(new Link(Position.RIGHT));

        Standard right = new Standard(this, x + 1, y, Walls);
        line.Add(right);

        return line;
    }

    #endregion
}
