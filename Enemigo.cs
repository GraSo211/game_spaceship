using System;
using System.Drawing;

namespace game_spaceship;

public class Enemigo
{
    public float Vida { get; set; }
    public bool Vivo { get; set; }

    public Ventana VentanaC;

    public Point PosicionActual { get; set; }
    public ConsoleColor Color;
    public List<Point> PosicionesEnemigo { get; set; }
    public DateTime _TiempoMovimiento { get; set; }
    public DateTime _TiempoDireccion { get; set; }
    public Enemigo(ConsoleColor color, Ventana ventana, Point posicionActual)
    {
        Vida = 50;
        PosicionActual = posicionActual;
        PosicionesEnemigo = new List<Point>();
        Color = color;
        VentanaC = ventana;
        _TiempoMovimiento = DateTime.Now;
        _TiempoDireccion = DateTime.Now;
    }

    public void Dibujar()
    {
        int x = PosicionActual.X;
        int y = PosicionActual.Y;


        Console.ForegroundColor = Color;
        Console.SetCursorPosition(x, y);
        Console.Write(" ▄▄ ");

        Console.SetCursorPosition(x, y + 1);
        Console.Write("████");

        Console.SetCursorPosition(x, y + 2);
        Console.Write("▀  ▀");

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
        int rndDuracion = new Random().Next(1000, 2001);
        int rndDireccion = new Random().Next(1, 6);
        Point p;
        if (DateTime.Now > _TiempoDireccion.AddMilliseconds(rndDuracion))
        {
            switch (rndDireccion)
            {
                case 1:
                    p = new Point(PosicionActual.X, PosicionActual.Y - 1);


                    break;
                case 2:
                    p = new Point(PosicionActual.X - 1, PosicionActual.Y);


                    break;
                case 3:
                    p = new Point(PosicionActual.X, PosicionActual.Y + 1);


                    break;
                case 4:
                    p = new Point(PosicionActual.X + 1, PosicionActual.Y);
                    break;
                default:
                    p = new Point(PosicionActual.X, PosicionActual.Y);
                    break;
            }
            PosicionActual = p;
            _TiempoDireccion = DateTime.Now;
        }
    }


    public void Colision(Point posActual)
    {
        if (posActual.Y <= VentanaC.LimiteSuperior.Y)
        {
            
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



        if (DateTime.Now > _TiempoMovimiento.AddMilliseconds(1))
        {
            Borrar();
            GenerarDireccion();
            Point posAux = PosicionActual;
            Colision(PosicionActual);
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