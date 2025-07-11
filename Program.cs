
using game_spaceship;
using System.Drawing;

Ventana ventana;
Nave nave;
Boolean juego = true;



void Iniciar()
{
    // Ventana de juego 
    ventana = new(170, 45, ConsoleColor.Black, limiteSuperior: new Point(5, 3), limiteInferior: new Point(165, 43));
    ventana.DibujarMarco();

    // Nave del jugador
    nave = new Nave(new Point(80, 40), 4, ConsoleColor.Green, ventana);
    nave.Dibujar();

    

}
Iniciar();

while (juego)
{
    ConsoleKeyInfo key = Console.ReadKey();
    
    if (ConsoleKey.Escape == key.Key)
    {
        juego = false;
    }

    nave.Mover(key);
}