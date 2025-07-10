
using game_spaceship;
using System.Drawing;

Ventana ventana;
Nave nave;

void Iniciar()
{
    ventana = new(170, 45, ConsoleColor.Black, limiteSuperior: new Point(5, 3), limiteInferior: new Point(165, 43));
    ventana.DibujarMarco();

    nave = new Nave(new Point(60, 30), 5, ConsoleColor.Green, ventana);
    nave.Dibujar();

    Console.ReadKey();

}


Iniciar();