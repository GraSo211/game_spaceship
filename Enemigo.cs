using System;
using System.Drawing;

namespace game_spaceship;

public enum Direccion
{
    Norte,
    Sur,
    Este,
    Oeste,
    Quieto
}
public class Enemigo
{
    public float Vida { get; set; }
    public bool Vivo { get; set; }

    public Ventana VentanaC;

    public Point PosicionActual { get; set; }
    public ConsoleColor Color;
    public List<Point> PosicionesEnemigo { get; set; }
    public DateTime _TiempoMovimiento { get; set; }
    public Direccion Direccion { get; set; }
    public DateTime _TiempoDireccion { get; set; }
    public Enemigo(ConsoleColor color, Ventana ventana, Point posicionActual)
    {
        Vida = 50;
        PosicionActual = posicionActual;
        PosicionesEnemigo = new List<Point>();
        Color = color;
        VentanaC = ventana;
        Direccion = Direccion.Este;
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

        if ((DateTime.Now > _TiempoDireccion.AddMilliseconds(rndDuracion)) && (Direccion == Direccion.Este || Direccion == Direccion.Oeste || Direccion == Direccion.Quieto))
        {
            int rndDireccion = new Random().Next(1, 6);
            switch (rndDireccion)
            {
                case 1:
                    Direccion = Direccion.Norte;
                    break;
                case 2:
                    Direccion = Direccion.Oeste;
                    break;
                case 3:
                    Direccion = Direccion.Sur;
                    break;
                case 4:
                    Direccion = Direccion.Este;
                    break;
                case 5:
                    Direccion = Direccion.Quieto;
                    break;
            }
            _TiempoDireccion = DateTime.Now;

        }
        
        if ((DateTime.Now > _TiempoDireccion.AddMilliseconds(200)) && (Direccion == Direccion.Norte || Direccion == Direccion.Sur))
        {
            int rndDireccion = new Random().Next(1, 4);
            switch (rndDireccion)
            {
                case 1:
                    Direccion = Direccion.Oeste;
                    break;
                case 2:
                    Direccion = Direccion.Este;
                    break;
                case 3:
                    Direccion = Direccion.Quieto;
                    break;
            }
        }

        
    }

    public void GenerarMovimiento()
    {
        Point p;
        switch (Direccion)
        {
            case Direccion.Norte:
                p = new Point(PosicionActual.X, PosicionActual.Y - 1);
                break;
            case Direccion.Oeste:
                p = new Point(PosicionActual.X - 1, PosicionActual.Y);
                break;
            case Direccion.Sur:
                p = new Point(PosicionActual.X, PosicionActual.Y + 1);
                break;
            case Direccion.Este:
                p = new Point(PosicionActual.X + 1, PosicionActual.Y);
                break;
            default:
                p = new Point(PosicionActual.X, PosicionActual.Y);
                break;
        }
        PosicionActual = p;
    }

    public void Colision(Point posActual)
    {
        if (posActual.X < VentanaC.LimiteSuperior.X + 2)
        {
            Direccion = Direccion.Este;
        }
        if (posActual.X > VentanaC.LimiteInferior.X - 5)
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

    public void Mover()
    {

        if (DateTime.Now > _TiempoMovimiento.AddMilliseconds(30))
        {
            Borrar();
            GenerarDireccion();
            GenerarMovimiento();
            Point posAux = PosicionActual;
            Colision(posAux);
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