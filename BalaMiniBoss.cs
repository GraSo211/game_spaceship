using System;
using System.Drawing;

namespace game_spaceship;

public class BalaMiniBoss : BalaEnemigo
{
    public BalaMiniBoss(Point posicion, ConsoleColor color, Ventana ventana) : base(posicion, color, ventana)
    {
        Daño = 5;
    }

    override public  void Dibujar()
    {
        Console.ForegroundColor = Color;
        Console.SetCursorPosition(Posicion.X, Posicion.Y);
        Console.Write("█");
    }

}
