using System;
using System.Drawing;

namespace game_spaceship;

public class MiniBoss : Enemigo
{
    public MiniBoss(ConsoleColor color, Ventana ventana, Point posicionInicial) : base(color, ventana, posicionInicial) { }


    public override void Dibujar()
    {
        int x = PosicionActual.X;
        int y = PosicionActual.Y;


        Console.ForegroundColor = Color;
        Console.SetCursorPosition(x, y);
        Console.Write(" █▄▄▄▄█ ");

        Console.SetCursorPosition(x, y + 1);
        Console.Write("██ ██ ██");

        Console.SetCursorPosition(x, y + 2);
        Console.Write("█▀▀▀▀▀▀█");

        PosicionesEnemigo.Clear();

        PosicionesEnemigo.Add(new Point(x + 1, y));
        PosicionesEnemigo.Add(new Point(x + 2, y));
        PosicionesEnemigo.Add(new Point(x + 3, y));
        PosicionesEnemigo.Add(new Point(x + 4, y));
        PosicionesEnemigo.Add(new Point(x + 5, y));
        PosicionesEnemigo.Add(new Point(x + 6, y));


        PosicionesEnemigo.Add(new Point(x, y + 1));
        PosicionesEnemigo.Add(new Point(x + 1, y + 1));
        PosicionesEnemigo.Add(new Point(x + 3, y + 1));
        PosicionesEnemigo.Add(new Point(x + 4, y + 1));
        PosicionesEnemigo.Add(new Point(x + 6, y + 1));
        PosicionesEnemigo.Add(new Point(x + 7, y + 1));

        PosicionesEnemigo.Add(new Point(x, y + 2));
        PosicionesEnemigo.Add(new Point(x + 1, y + 2));
        PosicionesEnemigo.Add(new Point(x + 2, y + 2));
        PosicionesEnemigo.Add(new Point(x + 3, y + 2));
        PosicionesEnemigo.Add(new Point(x + 4, y + 2));
        PosicionesEnemigo.Add(new Point(x + 5, y + 2));
        PosicionesEnemigo.Add(new Point(x + 6, y + 2));
        PosicionesEnemigo.Add(new Point(x + 7, y + 2));
    }

    public override void Colision(Point posActual)
    {
        if (posActual.X < VentanaC.LimiteSuperior.X + 8)
        {
            Direccion = Direccion.Este;
        }
        if (posActual.X > VentanaC.LimiteInferior.X - 1)
        {
            Direccion = Direccion.Oeste;
        }
        if (posActual.Y < VentanaC.LimiteSuperior.Y + 2)
        {
            Direccion = Direccion.Sur;
        }
        if (posActual.Y > VentanaC.LimiteSuperior.Y + 15)
        {
            Direccion = Direccion.Norte;
        }
    }
}
