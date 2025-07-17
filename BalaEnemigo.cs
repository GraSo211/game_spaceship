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

    public BalaEnemigo(Point posicion, ConsoleColor color, Ventana ventana)
    {
        Daño = 2;
        Posicion = posicion;
        VentanaC = ventana;
        Color = color;
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
        Console.Write("■");
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
        Borrar();
        Point posAux = Posicion;
        bool colision = Colision(posAux);
        if (!colision)
        {
            Posicion = new Point(Posicion.X, Posicion.Y+1);
            Dibujar();

        }
    }

}
