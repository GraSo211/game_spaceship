using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace game_spaceship;

public class Nave
{

    public float Vida { get; set; }
    public float Sobrecarga { get; set; }
    public int Velocidad { get; set; }
    public Point Posicion { get; set; }

    public ConsoleColor Color { get; set; }

    public Ventana VentanaC { get; set; }

    public List<Point> PosicionesNave { get; set; }

    public List<Bala> Balas { get; set; }
    public Nave(Point posicion, int velocidad, ConsoleColor color, Ventana ventana)
    {
        Posicion = posicion;
        Velocidad = velocidad;
        Vida = 100;
        Sobrecarga = 0;
        Color = color;
        VentanaC = ventana;
        PosicionesNave = new List<Point>();
        Balas = new List<Bala>();
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


    private Point Teclado()
    {
        ConsoleKey key = Console.ReadKey(true).Key;
        Point mover;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                mover = new Point(0, -Velocidad);
                break;
            case ConsoleKey.DownArrow:
                mover = new Point(0, Velocidad);
                break;
            case ConsoleKey.LeftArrow:
                mover = new Point(-Velocidad, 0);
                break;
            case ConsoleKey.RightArrow:
                mover = new Point(Velocidad, 0);
                break;
            default:
                mover = new Point(0, 0);
                break;
        }

        switch (key)
        {
            case ConsoleKey.Z:
                Bala balaZ = new Bala(new Point(Posicion.X, Posicion.Y + 1), ConsoleColor.Yellow, TipoBala.Normal);
                balaZ.Dibujar();
                Balas.Add(balaZ);
                break;
            case ConsoleKey.C:
                Bala balaC = new Bala(new Point(Posicion.X + 6, Posicion.Y + 1), ConsoleColor.Yellow, TipoBala.Normal);
                balaC.Dibujar();
                Balas.Add(balaC);

                break;
            case ConsoleKey.X:
                Bala balaX = new Bala(new Point(Posicion.X + 2, Posicion.Y - 2), ConsoleColor.DarkYellow, TipoBala.Especial);
                balaX.Dibujar();
                Balas.Add(balaX);

                break;

        }

        return mover;
    }

    public Boolean Colision(Point posibleColision)
    {
        if (posibleColision.Y <= VentanaC.LimiteSuperior.Y ||
            posibleColision.Y + 2 >= VentanaC.LimiteInferior.Y ||
            posibleColision.X <= VentanaC.LimiteSuperior.X ||
            posibleColision.X + 6 >= VentanaC.LimiteInferior.X)
        { return true; }
        return false;

    }


    public void Mover()
    {
        if (Console.KeyAvailable)
        {
            Borrar();
            Point posicionAux = Posicion;

            Point mover = Teclado();
            Point posicionProx = new Point(Posicion.X + mover.X, Posicion.Y + mover.Y);
            Boolean colision = Colision(posicionProx);
            Posicion = colision == true ? posicionAux : posicionProx;

            Dibujar();
        }




    }


    public void Disparar()
    {
        for (int i = 0; i < Balas.Count; i++)
        {
            if (Balas[i].Mover(1, VentanaC.LimiteSuperior.Y))
            {
                Balas.Remove(Balas[i]);
            }
        }
    }


    public void informacion()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(VentanaC.LimiteSuperior.X, VentanaC.LimiteSuperior.Y - 1);
        Console.Write($"Vida: {(int)Vida}%");
        
        Console.SetCursorPosition(VentanaC.LimiteSuperior.X + 15, VentanaC.LimiteSuperior.Y - 1);
        Console.Write($"Sobrecarga: {(int)Sobrecarga}%");

    }

}
