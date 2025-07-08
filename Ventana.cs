using System;

namespace game_spaceship;

public class Ventana
{
    public int Ancho { get; set; }
    public int Alto { get; set; }

    public Ventana(int ancho, int alto)
    {
        Ancho = ancho;
        Alto = alto;
        init();
    }


    private void init()
    {
        Console.SetWindowSize(Ancho, Alto);
        Console.Title = "Spaceship Game";
        
    }
}
