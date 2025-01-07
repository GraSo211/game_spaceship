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
    public DateTime _TiempoMovimiento { get; set; }
    public DateTime _TiempoDireccion { get; set; }
    public Enemigo(ConsoleColor color, Ventana ventana, Point posicionInicial)
    {
        Vida = 50;
        PosicionInicial = posicionInicial;
        PosicionesEnemigo = new List<Point>();
        Color = color;
        VentanaC = ventana;
        _TiempoMovimiento = DateTime.Now;
        _TiempoDireccion = DateTime.Now;
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
        foreach (Point p in PosicionesEnemigo)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.Write(" ");
        }
    }

    private void GenerarDireccion()
    {
        int rndDireccion = new Random().Next(1, 6);
        Point p;
        switch (rndDireccion)
        {
            case 1:
                p = new Point(PosicionInicial.X, PosicionInicial.Y - 1);


                break;
            case 2:
                p = new Point(PosicionInicial.X - 1, PosicionInicial.Y);


                break;
            case 3:
                p = new Point(PosicionInicial.X, PosicionInicial.Y + 1);


                break;
            case 4:
                p = new Point(PosicionInicial.X + 1, PosicionInicial.Y);
                break;
            default:
                p = new Point(PosicionInicial.X, PosicionInicial.Y);
                break;
        }
        PosicionInicial = p;
        _TiempoDireccion = DateTime.Now;

    }

    public void Mover()
    {
        // Aleatorizamos su movimiento,
        // Generamos un random donde se acumulan probabilidades de .25
        // 1. Norte
        // 2. Oeste
        // 3. Sur
        // 4. Este

        int rndDuracion = new Random().Next(500, 1501);
        DateTime dateNow = DateTime.Now; 
        if (dateNow >= _TiempoMovimiento.AddMilliseconds(30))
        {
            if (dateNow >= _TiempoDireccion.AddMilliseconds(rndDuracion))
            {
                GenerarDireccion();
            }


            Borrar();
            Dibujar();
            _TiempoMovimiento = DateTime.Now;

        }


    }


}

/* █▀▀█ ▄▄██▄▄ █▀▀█  
      ██████████
   █▀██▀ ████ ▀██▀█
     ████████████
    ▀▀██      ██▀▀
    */ 