using System;
using System.Drawing;

namespace game_spaceship;


public enum TipoBala
{
    Normal,
    Especial
}

public class Bala
{
    public Point Posicion { get; set; }
    public ConsoleColor Color { get; set; }

    public TipoBala TipoBalaDisparada { get; set; }

    public List<Point> PosicionesBala { get; set; }

    private DateTime _tiempo;

    public Bala(Point posicion, ConsoleColor color, TipoBala tipoBala)
    {
        Posicion = posicion;
        Color = color;
        TipoBalaDisparada = tipoBala;
        PosicionesBala = new List<Point>();
        _tiempo = DateTime.Now;
    }


    public void Dibujar()
    {
        Console.ForegroundColor = Color;
        int x = Posicion.X;
        int y = Posicion.Y;

        PosicionesBala.Clear();

        switch (TipoBalaDisparada)
        {
            case TipoBala.Normal:
                Console.SetCursorPosition(x, y);
                Console.Write("O");
                PosicionesBala.Add(new Point(x, y));
                break;
            case TipoBala.Especial:
                Console.SetCursorPosition(x, y);
                Console.Write("/A\\");
                Console.SetCursorPosition(x, y + 1);
                Console.Write("╠╬╣");


                PosicionesBala.Add(new Point(x, y));
                PosicionesBala.Add(new Point(x + 1, y));
                PosicionesBala.Add(new Point(x + 2, y));

                PosicionesBala.Add(new Point(x, y + 1));
                PosicionesBala.Add(new Point(x + 1, y + 1));
                PosicionesBala.Add(new Point(x + 2, y + 1));


                break;

        }

    }

    public void Borrar()
    {
        foreach (Point posc in PosicionesBala)
        {
            int x = posc.X;
            int y = posc.Y;
            Console.SetCursorPosition(x, y);
            Console.Write(" ");

        }
    }

    public bool Mover(int velocidad, int limite)
    {

        if (DateTime.Now > _tiempo.AddMilliseconds(30))
        {
            Borrar();

            switch (TipoBalaDisparada)
            {
                case TipoBala.Normal:
                    Posicion = new Point(Posicion.X, Posicion.Y - velocidad);
                    if (Posicion.Y <= limite)
                        return true;
                    break;

                case TipoBala.Especial:
                    Posicion = new Point(Posicion.X, Posicion.Y - velocidad);
                    if (Posicion.Y <= limite)
                        return true;
                    break;

            }
            Dibujar();
            _tiempo = DateTime.Now;
        }
        return false;
    }

}
