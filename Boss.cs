using System;
using System.Drawing;

namespace game_spaceship;

public class Boss : Enemigo
{
    public bool PermitirMovimiento { get; set; }
    public DateTime EventoDisparo { get; set; }
    public int ContDisparo { get; set; }
    public Boss(ConsoleColor color, Ventana ventana, Point posicionInicial, Nave nave) : base(color, ventana, posicionInicial, nave)
    {
        Vida = 200;
        PermitirMovimiento = true;
        EventoDisparo = DateTime.Now;
        ContDisparo = 1;
    }


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


    public override void Disparar()
    {
        if (DateTime.Now >= EventoDisparo.AddMilliseconds(500))
        {
            BalaBoss bala = new BalaBoss(new Point(PosicionActual.X + 5, PosicionActual.Y + 5), ConsoleColor.DarkRed, VentanaC);

            switch (ContDisparo)
            {

                case 1:
                    ContDisparo += 1;
                    PermitirMovimiento = false;
                    bala.Dibujar(1);
                    EventoDisparo = DateTime.Now;
                    break;
                case 2:
                    ContDisparo += 1;
                    bala.Dibujar(2);
                    EventoDisparo = DateTime.Now;
                    break;
                case 3:
                    ContDisparo += 1;
                    bala.Dibujar(3);
                    EventoDisparo = DateTime.Now;
                    break;
                case 4:
                    ContDisparo += 1;
                    bala.Dibujar(4);
                    foreach (Point navePos in NaveC.PosicionesNave)
                    {
                        if ((navePos.X >= PosicionActual.X + 5) && (navePos.X <= PosicionActual.X + 11))
                        {
                            NaveC.Vida = 0;
                        }
                    }

                    EventoDisparo = DateTime.Now;

                    break;
                case 5:
                    ContDisparo = 1;
                    PermitirMovimiento = true;
                    bala.Dibujar(4);
                    EventoDisparo = DateTime.Now.AddSeconds(5);
                    bala.Borrar();
                    break
                    ;
            }

        }
    }

    public override void Mover()
    {
        if (DateTime.Now > _TiempoMovimiento.AddMilliseconds(30) && Vivo && PermitirMovimiento)
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

    public override void Colision(Point posActual)
    {
        if (posActual.X < VentanaC.LimiteSuperior.X + 3)
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
