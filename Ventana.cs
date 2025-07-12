using System;
using System.Drawing;
namespace game_spaceship;

public class Ventana
{
    public int Ancho { get; set; }
    public int Alto { get; set; }

    public Point LimiteSuperior { get; set; }
    public Point LimiteInferior { get; set; }

    public ConsoleColor Color { get; set; }

    public Ventana(int ancho, int alto, ConsoleColor color, Point limiteSuperior, Point limiteInferior)
    {
        Ancho = ancho;
        Alto = alto;
        Color = color;
        LimiteSuperior = limiteSuperior;
        LimiteInferior = limiteInferior;

        init();
    }


    private void init()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.SetWindowSize(Ancho, Alto);
        Console.SetBufferSize(Ancho, Alto);

        Console.Title = "Spaceship Game";
        Console.BackgroundColor = Color;
        Console.Clear();
        Console.CursorVisible = false;

    }



    public void DibujarMarco()
    {
        for (int i = LimiteSuperior.X; i < LimiteInferior.X; i++)
        {
            Console.SetCursorPosition(i, LimiteSuperior.Y);
            Console.Write("═");
            Console.SetCursorPosition(i, LimiteInferior.Y);
            Console.Write("═");
        }

        for (int i = LimiteSuperior.Y; i < LimiteInferior.Y; i++)
        {
            Console.SetCursorPosition(LimiteSuperior.X, i);
            Console.Write("║");
            Console.SetCursorPosition(LimiteInferior.X, i);
            Console.Write("║");
        }


        Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y);
        Console.Write("╔");
        Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y);
        Console.Write("╗");
        Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y);
        Console.Write("╚");
        Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y);
        Console.Write("╝");

    }




}
