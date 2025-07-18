using System;
using System.Drawing;
using System.Reflection.Metadata;

namespace game_spaceship;

public class MiniBoss : Enemigo
{
    public MiniBoss(ConsoleColor color, Ventana ventana, Point posicionInicial, Nave nave) : base(color, ventana, posicionInicial, nave)
    {
        Vida = 100;
    }

    override public void Disparar()
    {
        if (Vivo)
        {
            if (DateTime.Now > TiempoDisparo.AddMilliseconds(400))
            {
                BalaMiniBoss bala1 = new BalaMiniBoss(new Point(PosicionActual.X + 3, PosicionActual.Y + 3), Color, VentanaC);
                Balas.Add(bala1);
                BalaMiniBoss bala2 = new BalaMiniBoss(new Point(PosicionActual.X + 4, PosicionActual.Y + 3), Color, VentanaC);
                Balas.Add(bala2);
                BalaMiniBoss bala3 = new BalaMiniBoss(new Point(PosicionActual.X + 5, PosicionActual.Y + 3), Color, VentanaC);
                Balas.Add(bala3);
                BalaMiniBoss bala4 = new BalaMiniBoss(new Point(PosicionActual.X + 6, PosicionActual.Y + 3), Color, VentanaC);
                Balas.Add(bala4);
                BalaMiniBoss bala5 = new BalaMiniBoss(new Point(PosicionActual.X + 2, PosicionActual.Y + 3), Color, VentanaC);
                Balas.Add(bala5);
                TiempoDisparo = DateTime.Now;
            }

            for (int i = 0; i < Balas.Count; i++)
            {
                for (int j = 0; j < NaveC.PosicionesNave.Count; j++)
                {
                    if ((Balas[i].Posicion.Y == NaveC.PosicionesNave[j].Y) && (Balas[i].Posicion.X == NaveC.PosicionesNave[j].X))
                    {
                        NaveC.Vida -= Balas[i].Daño;
                        Balas[i].Borrar();
                        NaveC.Dibujar();
                        Balas.Remove(Balas[i]);
                    }
                }



                if (!(Balas[i].Posicion.Y > VentanaC.LimiteInferior.Y - 2))
                {
                    Balas[i].Mover();
                }
                else
                {
                    Balas[i].Borrar();
                    Balas.Remove(Balas[i]);
                }

            }
        }


    }
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
        if (posActual.X < VentanaC.LimiteSuperior.X + 3)
        {
            Direccion = Direccion.Este;
        }
        if (posActual.X > VentanaC.LimiteInferior.X - 9)
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
