
using game_spaceship;
using System.Drawing;

Ventana ventana;
Nave nave;
bool juego = true;


void Iniciar()
{
    // Ventana de juego 
    ventana = new(170, 45, ConsoleColor.Black, limiteSuperior: new Point(5, 3), limiteInferior: new Point(165, 43));
    ventana.DibujarMarco();

    // Nave del jugador
    nave = new Nave(new Point(80, 40), 2, ConsoleColor.DarkBlue, ventana);
    nave.Dibujar();
    

}


void Game()
{
    while (juego)
    {
        nave.Mover();

        nave.Disparar();
        nave.informacion();
        if (nave.Vida <= 0)
        {
            nave.Muerte();
            juego = false;
        }


    }
}


Iniciar();
Game();
Console.ReadKey();
