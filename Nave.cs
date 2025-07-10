using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace game_spaceship;

public class Nave
{

    public float Vida { get; set; }
    public int Velocidad { get; set; }
    public Point Posicion { get; set; }

    public ConsoleColor Color { get; set; }

    public Ventana VentanaC { get; set; }

    public List<Point> PosicionesNave { get; set; }

    public Nave(Point posicion, int velocidad, ConsoleColor color, Ventana ventana)
    {
        Posicion = posicion;
        Velocidad = velocidad;
        Vida = 100;
        Color = color;
        VentanaC = ventana;
        PosicionesNave = new List<Point>();

    }

    public void Dibujar()
    {
        Console.ForegroundColor = Color;
        int x = Posicion.X;
        int y = Posicion.Y;
        Console.SetCursorPosition(x + 3, y);
        Console.Write("A");
        Console.SetCursorPosition(x + 1, y + 1);
        Console.Write("<{x}>");
        Console.SetCursorPosition(x, y + 2);
        Console.Write("± W W ±");

        PosicionesNave.Clear();

        PosicionesNave.Add(new Point(x + 3, y));

        PosicionesNave.Add(new Point(x + 1, y + 1));
        PosicionesNave.Add(new Point(x + 2, y + 1));
        PosicionesNave.Add(new Point(x + 3, y + 1));
        PosicionesNave.Add(new Point(x + 4, y + 1));
        PosicionesNave.Add(new Point(x + 5, y + 1));

        PosicionesNave.Add(new Point(x, y));
        PosicionesNave.Add(new Point(x, y + 2));
        PosicionesNave.Add(new Point(x + 2, y + 2));
        PosicionesNave.Add(new Point(x + 4, y + 2));
        PosicionesNave.Add(new Point(x + 6, y + 2));

    }


    public void Borrar()
    {
        foreach (Point p in PosicionesNave)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write(" ");
        }

    }



    public void Mover(int velocidad)
    {
        Posicion = new Point(Posicion.X + velocidad, Posicion.Y);
    }
}
