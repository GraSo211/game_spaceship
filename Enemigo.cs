using System;
using System.Drawing;

namespace game_spaceship;

public class Enemigo
{
    public float Vida { get; set; }
    public bool Vivo { get; set; }

    public Ventana VentanaC;

    public Point PosicionInicial { get; set; }
    public ConsoleColor Color;
    public List<Point> PosicionesEnemigo { get; set; }
    public DateTime TiempoMovimiento { get; set; }

    public Enemigo(ConsoleColor color, Ventana ventana, Point posicionInicial)
    {
        Vida = 50;
        PosicionInicial = posicionInicial;
        PosicionesEnemigo = new List<Point>();
        Color = color;
        VentanaC = ventana;
        TiempoMovimiento = DateTime.Now;

    }

    public void Dibujar()
    {
        int x = PosicionInicial.X;
        int y = PosicionInicial.Y;


        Console.ForegroundColor = Color;
        Console.SetCursorPosition(x, y);
        Console.Write(" ▄▄ ");

        Console.SetCursorPosition(x, y + 1);
        Console.Write("████");

        Console.SetCursorPosition(x, y + 2);
        Console.Write("▀  ▀");

        PosicionesEnemigo.Add(new Point(x + 1, y));
        PosicionesEnemigo.Add(new Point(x + 1, y));

        PosicionesEnemigo.Add(new Point(x, y + 1));
        PosicionesEnemigo.Add(new Point(x + 1, y + 1));
        PosicionesEnemigo.Add(new Point(x + 2, y + 1));
        PosicionesEnemigo.Add(new Point(x + 3, y + 1));

        PosicionesEnemigo.Add(new Point(x, y + 2));
        PosicionesEnemigo.Add(new Point(x + 3, y + 2));
    }


    public void Borrar()
    {
        for (int i = 0; i < PosicionesEnemigo.Count; i++)
        {
            Point p = new Point(PosicionesEnemigo[i].X, PosicionesEnemigo[i].Y);
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write(" ");
        }
    }


    public void Mover()
    {
        // Aleatorizamos su movimiento,
        // Generamos un random donde se acumulan probabilidades de .25
        // 1. Norte
        // 2. Oeste
        // 3. Sur
        // 4. Este
        int rnd = new Random().Next(1, 5);
        Borrar();
        switch (rnd)
        {
            case (1):
                Point pN = new Point(PosicionInicial.X, PosicionInicial.Y - 1);
                PosicionInicial = pN;

                break;
            case (2):
                Point pO = new Point(PosicionInicial.X - 1, PosicionInicial.Y);
                PosicionInicial = pO;

                break;
            case (3):
                Point pS = new Point(PosicionInicial.X, PosicionInicial.Y + 1);
                PosicionInicial = pS;

                break;
            case (4):
                Point pE = new Point(PosicionInicial.X + 1, PosicionInicial.Y);
                PosicionInicial = pE;

                break;
            
        }
        if (DateTime.Now >= TiempoMovimiento.AddMilliseconds(1000))
        {
            Dibujar();
        }
        

    }


}

/* █▀▀█ ▄▄██▄▄ █▀▀█  
      ██████████
   █▀██▀ ████ ▀██▀█
     ████████████
    ▀▀██      ██▀▀
    */ 