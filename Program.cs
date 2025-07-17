
using game_spaceship;
using System.Drawing;

Ventana ventana;
Nave nave;
bool juego = true;
Enemigo enemigo1;
Enemigo enemigo2;
MiniBoss miniBoss1;
Boss boss;

void Iniciar()
{
    // Ventana de juego 
    ventana = new(170, 45, ConsoleColor.Black, limiteSuperior: new Point(5, 3), limiteInferior: new Point(165, 43));
    ventana.DibujarMarco();

    // Nave del jugador
    nave = new Nave(new Point(80, 40), 2, ConsoleColor.DarkBlue, ventana);
    nave.Dibujar();
    enemigo1 = new Enemigo(ConsoleColor.Red, ventana, new Point(50, 10));
    enemigo1.Dibujar();
    enemigo2 = new Enemigo(ConsoleColor.DarkRed, ventana, new Point(100, 5));
    enemigo2.Dibujar();
    miniBoss1 = new MiniBoss(ConsoleColor.DarkMagenta, ventana, new Point(80, 10));
    miniBoss1.Dibujar();

    boss = new Boss(ConsoleColor.DarkRed, ventana, new Point(30, 20));
    boss.Dibujar();
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

        enemigo1.Mover();
        enemigo2.Mover();

        miniBoss1.Mover();

        boss.Mover();
        enemigo1.Disparar();
        

    }
}


Iniciar();
Game();
Console.ReadKey();
