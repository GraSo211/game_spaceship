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

    public void Peligro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        DibujarMarco();
        for (int i = 0; i < 6; i++)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(LimiteInferior.X / 2 - 5, LimiteInferior.Y / 2);
            Console.Write("¡¡¡PELIGRO!!!");
            Thread.Sleep(200);
            Console.SetCursorPosition(LimiteInferior.X / 2 - 5, LimiteInferior.Y / 2);
            Console.WriteLine("             ");
            Thread.Sleep(200);
        }
    }
    public void Teclado(ref bool ejecucion, ref bool juego)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                DibujarMarco();
                juego = true;
            }
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                ejecucion = false;
            }
        }
    }
    public void Menu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(LimiteInferior.X / 2 - 5, LimiteInferior.Y / 2 - 1);
        Console.Write("[ENTER] JUGAR");
        Console.SetCursorPosition(LimiteInferior.X / 2 - 5, LimiteInferior.Y / 2);
        Console.Write("[ESC] SALIR");
        
    }


}
