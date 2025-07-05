using System;
using System.Drawing;

namespace game_spaceship;

public class Boss : Enemigo
{
    public Boss(ConsoleColor color, Ventana ventana, Point posicionInicial) : base(color, ventana, posicionInicial) { }


    public override void Dibujar()
    {
        int x = PosicionActual.X;
        int y = PosicionActual.Y;


        Console.ForegroundColor = Color;
        Console.SetCursorPosition(x, y);
        Console.Write("█▀▀█ ▄▄██▄▄ █▀▀█");

        Console.SetCursorPosition(x, y + 1);
        Console.Write("   ██████████   ");

        Console.SetCursorPosition(x, y + 2);
        Console.Write("█▀██▀ ████ ▀██▀█");

        Console.SetCursorPosition(x, y + 3);
        Console.Write("  ████████████  ");

        Console.SetCursorPosition(x, y + 4);
        Console.Write(" ▀▀██      ██▀▀ ");

        PosicionesEnemigo.Clear();

        PosicionesEnemigo.Add(new Point(x + 1, y));
        PosicionesEnemigo.Add(new Point(x + 2, y));

        PosicionesEnemigo.Add(new Point(x, y + 1));
        PosicionesEnemigo.Add(new Point(x + 1, y + 1));
        PosicionesEnemigo.Add(new Point(x + 2, y + 1));
        PosicionesEnemigo.Add(new Point(x + 3, y + 1));

        PosicionesEnemigo.Add(new Point(x, y + 2));
        PosicionesEnemigo.Add(new Point(x + 3, y + 2));

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

/* █▀▀█ ▄▄██▄▄ █▀▀█  
      ██████████
   █▀██▀ ████ ▀██▀█
     ████████████
    ▀▀██      ██▀▀
    */ 
