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

        PosicionesEnemigo.Add(new Point(x, y));
        PosicionesEnemigo.Add(new Point(x + 1, y));
        PosicionesEnemigo.Add(new Point(x + 2, y));
        PosicionesEnemigo.Add(new Point(x + 3, y));
        PosicionesEnemigo.Add(new Point(x + 4, y));
        PosicionesEnemigo.Add(new Point(x + 5, y));
        PosicionesEnemigo.Add(new Point(x + 6, y));
        PosicionesEnemigo.Add(new Point(x + 7, y));
        PosicionesEnemigo.Add(new Point(x + 8, y));
        PosicionesEnemigo.Add(new Point(x + 9, y));
        PosicionesEnemigo.Add(new Point(x + 10, y));
        PosicionesEnemigo.Add(new Point(x + 11, y));
        PosicionesEnemigo.Add(new Point(x + 12, y));
        PosicionesEnemigo.Add(new Point(x + 13, y));
        PosicionesEnemigo.Add(new Point(x + 14, y));
        PosicionesEnemigo.Add(new Point(x + 15, y));


        PosicionesEnemigo.Add(new Point(x + 3, y + 1));
        PosicionesEnemigo.Add(new Point(x + 4, y + 1));
        PosicionesEnemigo.Add(new Point(x + 5, y + 1));
        PosicionesEnemigo.Add(new Point(x + 6, y + 1));
        PosicionesEnemigo.Add(new Point(x + 7, y + 1));
        PosicionesEnemigo.Add(new Point(x + 8, y + 1));
        PosicionesEnemigo.Add(new Point(x + 9, y + 1));
        PosicionesEnemigo.Add(new Point(x + 10, y + 1));
        PosicionesEnemigo.Add(new Point(x + 11, y + 1));
        PosicionesEnemigo.Add(new Point(x + 12, y + 1));


        PosicionesEnemigo.Add(new Point(x, y + 2));
        PosicionesEnemigo.Add(new Point(x + 1, y + 2));
        PosicionesEnemigo.Add(new Point(x + 2, y + 2));
        PosicionesEnemigo.Add(new Point(x + 3, y + 2));
        PosicionesEnemigo.Add(new Point(x + 4, y + 2));
        PosicionesEnemigo.Add(new Point(x + 6, y + 2));
        PosicionesEnemigo.Add(new Point(x + 7, y + 2));
        PosicionesEnemigo.Add(new Point(x + 8, y + 2));
        PosicionesEnemigo.Add(new Point(x + 9, y + 2));
        PosicionesEnemigo.Add(new Point(x + 11, y + 2));
        PosicionesEnemigo.Add(new Point(x + 12, y + 2));
        PosicionesEnemigo.Add(new Point(x + 13, y + 2));
        PosicionesEnemigo.Add(new Point(x + 14, y + 2));
        PosicionesEnemigo.Add(new Point(x + 15, y + 2));


        PosicionesEnemigo.Add(new Point(x + 2, y + 3));
        PosicionesEnemigo.Add(new Point(x + 3, y + 3));
        PosicionesEnemigo.Add(new Point(x + 4, y + 3));
        PosicionesEnemigo.Add(new Point(x + 5, y + 3));
        PosicionesEnemigo.Add(new Point(x + 6, y + 3));
        PosicionesEnemigo.Add(new Point(x + 7, y + 3));
        PosicionesEnemigo.Add(new Point(x + 8, y + 3));
        PosicionesEnemigo.Add(new Point(x + 9, y + 3));
        PosicionesEnemigo.Add(new Point(x + 10, y + 3));
        PosicionesEnemigo.Add(new Point(x + 11, y + 3));
        PosicionesEnemigo.Add(new Point(x + 12, y + 3));
        PosicionesEnemigo.Add(new Point(x + 13, y + 3));


        PosicionesEnemigo.Add(new Point(x + 1, y + 4));
        PosicionesEnemigo.Add(new Point(x + 2, y + 4));
        PosicionesEnemigo.Add(new Point(x + 3, y + 4));
        PosicionesEnemigo.Add(new Point(x + 4, y + 4));

        PosicionesEnemigo.Add(new Point(x + 11, y + 4));
        PosicionesEnemigo.Add(new Point(x + 12, y + 4));
        PosicionesEnemigo.Add(new Point(x + 13, y + 4));
        PosicionesEnemigo.Add(new Point(x + 14, y + 4));
        


    }


    
    public override void Colision(Point posActual)
    {
        if (posActual.X < VentanaC.LimiteSuperior.X + 2)
        {
            Direccion = Direccion.Este;
        }
        if (posActual.X > VentanaC.LimiteInferior.X - 17)
        {
            Direccion = Direccion.Oeste;
        }
        if (posActual.Y < VentanaC.LimiteSuperior.Y + 5)
        {
            Direccion = Direccion.Sur;
        }
        if (posActual.Y > VentanaC.LimiteSuperior.Y + 10)
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
