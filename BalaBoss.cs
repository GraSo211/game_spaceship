using System;
using System.Drawing;

namespace game_spaceship;

public class BalaBoss : BalaEnemigo
{
    public BalaBoss(Point posicionActual, ConsoleColor color, Ventana ventana) : base(posicionActual, color, ventana)
    {
        Daño = 101;
    }


    public void Dibujar(int stage)
    {
        Console.ForegroundColor = Color;


        switch (stage)
        {
            case 1:

                for (int i = 0; i < VentanaC.LimiteInferior.Y - Posicion.Y; i++)
                {
                    Console.SetCursorPosition(Posicion.X + 2, Posicion.Y + i);
                    Console.Write("||");
                }

                break;
            case 2:
                for (int i = 0; i < VentanaC.LimiteInferior.Y - Posicion.Y; i++)
                {
                    Console.SetCursorPosition(Posicion.X + 1, Posicion.Y + i);
                    Console.Write("||||");
                }
                break;
            case 3:
                for (int i = 0; i < VentanaC.LimiteInferior.Y - Posicion.Y; i++)
                {
                    Console.SetCursorPosition(Posicion.X, Posicion.Y + i);
                    Console.Write("||||||");
                }
                break;
            case 4:
                for (int i = 0; i < VentanaC.LimiteInferior.Y - Posicion.Y; i++)
                {
                    Console.SetCursorPosition(Posicion.X, Posicion.Y + i);
                    Console.Write("██████");
                }
                break;
        }

    }

    public override void Borrar()
    {
        for (int i = 0; i < VentanaC.LimiteInferior.Y - Posicion.Y; i++)
                {
                    Console.SetCursorPosition(Posicion.X, Posicion.Y + i);
                    Console.Write("      ");
                }
    }

}
