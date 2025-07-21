using System;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace game_spaceship;

public class Nave
{

    public float Vida { get; set; }
    public float Sobrecarga { get; set; }
    public bool SobrecargaEstado { get; set; }

    public float BalaEspecial { get; set; }

    public int Velocidad { get; set; }
    public Point Posicion { get; set; }

    public ConsoleColor Color { get; set; }

    public Ventana VentanaC { get; set; }

    public List<Point> PosicionesNave { get; set; }

    public List<Bala> Balas { get; set; }

    public List<Enemigo> Enemigos { get; set; }
    public Nave(Point posicion, int velocidad, ConsoleColor color, Ventana ventana)
    {
        Posicion = posicion;
        Velocidad = velocidad;
        Vida = 100;
        Sobrecarga = 0;
        SobrecargaEstado = false;
        BalaEspecial = 0;
        Color = color;
        VentanaC = ventana;
        PosicionesNave = new List<Point>();
        Balas = new List<Bala>();
        Enemigos = new List<Enemigo>();
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

        //* MOVIMIENTO
        switch (key)
        {
            case ConsoleKey.UpArrow:
                mover = new Point(0, -Velocidad);
                break;
            case ConsoleKey.DownArrow:
                mover = new Point(0, Velocidad);
                break;
            case ConsoleKey.LeftArrow:
                mover = new Point(-Velocidad * 2, 0);
                break;
            case ConsoleKey.RightArrow:
                mover = new Point(Velocidad * 2, 0);
                break;
            default:
                mover = new Point(0, 0);
                break;
        }

        //* DISPARAR
        switch (key)
        {
            case ConsoleKey.Z:
                if (!SobrecargaEstado)
                {
                    Bala balaZ = new Bala(new Point(Posicion.X, Posicion.Y + 1), ConsoleColor.Yellow, TipoBala.Normal);
                    balaZ.Dibujar();
                    Balas.Add(balaZ);
                    Sobrecarga += 1.2f;
                    if (Sobrecarga >= 100)
                    {
                        Sobrecarga = 100;
                        SobrecargaEstado = true;
                    }
                }
                break;

            case ConsoleKey.C:
                if (!SobrecargaEstado)
                {
                    Bala balaC = new Bala(new Point(Posicion.X + 6, Posicion.Y + 1), ConsoleColor.Yellow, TipoBala.Normal);
                    balaC.Dibujar();
                    Balas.Add(balaC);
                    Sobrecarga += 1.2f;
                    if (Sobrecarga > 100)
                    {
                        Sobrecarga = 100;
                        SobrecargaEstado = true;
                    }
                }
                break;
            case ConsoleKey.X:
                if (!SobrecargaEstado)
                {
                    if (BalaEspecial == 100)
                    {
                        Bala balaX = new Bala(new Point(Posicion.X + 2, Posicion.Y - 2), ConsoleColor.DarkYellow, TipoBala.Especial);
                        balaX.Dibujar();
                        Balas.Add(balaX);
                        Sobrecarga += 5f;
                        if (Sobrecarga > 100)
                        {
                            Sobrecarga = 100;
                            SobrecargaEstado = true;
                        }
                        BalaEspecial = 0;
                    }

                }
                break;

        }

        return mover;
    }

    public bool Colision(Point posibleColision)
    {
        if (posibleColision.Y <= VentanaC.LimiteSuperior.Y + 20 ||
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
            bool colision = Colision(posicionProx);
            Posicion = colision == true ? posicionAux : posicionProx;

            Dibujar();
        }




    }



    public void Disparar()
    {
        for (int i = Balas.Count - 1; i >= 0; i--)
        {
            bool balaEliminada = false;

            for (int j = 0; j < Enemigos.Count; j++)
            {
                foreach (Point p in Enemigos[j].PosicionesEnemigo)
                {
                    if ((p.Y == Balas[i].Posicion.Y) && (p.X == Balas[i].Posicion.X))
                    {
                        int daño = (Balas[i].TipoBalaDisparada == TipoBala.Normal) ? 10 : 50;
                        Enemigos[j].Vida -= daño;
                        Enemigos[j].Dibujar();
                        if (Enemigos[j].Vida <= 0)
                        {
                            Enemigos[j].Vida = 0;
                            Enemigos[j].Vivo = false;
                            Enemigos[j].Morir();
                            
                            Enemigos.RemoveAt(j);
                        }
                        
                        Balas[i].Borrar();
                        Balas.RemoveAt(i);
                        balaEliminada = true;
                        break;
                    }
                }

                if (balaEliminada)
                    break;
            }

            if (!balaEliminada && Balas[i].Mover(1, VentanaC.LimiteSuperior.Y))
            {
                Balas.RemoveAt(i);
            }
        }
    }





    public void informacion()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(VentanaC.LimiteSuperior.X, VentanaC.LimiteSuperior.Y - 1);
        Console.Write($"Vida: {(int)Vida} %  ");

        if (Sobrecarga > 0)
        {
            Sobrecarga -= 0.000999f;
        }
        else
        {
            Sobrecarga = 0;
        }

        if (Sobrecarga <= 50) { SobrecargaEstado = false; }

        if (SobrecargaEstado) { Console.ForegroundColor = ConsoleColor.Red; }

        Console.SetCursorPosition(VentanaC.LimiteSuperior.X + 15, VentanaC.LimiteSuperior.Y - 1);
        Console.Write($"Sobrecarga: {(int)Sobrecarga}" + " %  ");

        if (BalaEspecial < 100)
        {
            BalaEspecial += 0.004f;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            BalaEspecial = 100;
        }


        Console.SetCursorPosition(VentanaC.LimiteSuperior.X + 33, VentanaC.LimiteSuperior.Y - 1);
        Console.Write($"Bala Especial: {(int)BalaEspecial}" + " %  ");


    }

    public void Muerte()
    {
        foreach (Point p in PosicionesNave)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write("X");
            Thread.Sleep(200);
        }
        foreach (Point p in PosicionesNave)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write(" ");
            Thread.Sleep(200);
        }
    }
}
