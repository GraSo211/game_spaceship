
using game_spaceship;
using System.Drawing;
Ventana ventana = new(170, 45, ConsoleColor.Black,
 limiteSuperior: new Point(5, 5), limiteInferior: new Point(165, 40));

ventana.DibujarMarco();

Console.ReadKey();
