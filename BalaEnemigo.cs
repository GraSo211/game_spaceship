using System;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;

namespace game_spaceship;

public class BalaEnemigo
{
    public int Daño { get; set; }
    public Point Posicion { get; set; }
    public ConsoleColor Color { get; set; }
    public Ventana VentanaC { get; set; }

    public DateTime TiempoBala { get; set; }

    public BalaEnemigo(Point posicion, ConsoleColor color, Ventana ventana)
    {
        Daño = 2;
        Posicion = posicion;
        VentanaC = ventana;
        Color = color;
        TiempoBala = DateTime.Now;
    }

    public void Borrar()
    {
        Console.SetCursorPosition(Posicion.X, Posicion.Y);
        Console.Write(" ");
    }

    public void Dibujar()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(Posicion.X, Posicion.Y);
        Console.Write("█");
    }



    public void Mover()
    {
        if (DateTime.Now > TiempoBala.AddMilliseconds(50))
        {
            Borrar();

            Posicion = new Point(Posicion.X, Posicion.Y + 1);
            Dibujar();

            TiempoBala = DateTime.Now;
        }

    }

}
