
using game_spaceship;
using System.Drawing;

Ventana ventana;
Nave nave;
bool juego = true;
Enemigo enemigo1;
Enemigo enemigo2;
Enemigo enemigo3;

MiniBoss miniBoss1;
MiniBoss miniBoss2;
Enemigo enemigo4;
Enemigo enemigo5;

Boss boss;
MiniBoss miniBoss3;
MiniBoss miniBoss4;
Enemigo enemigo6;
Enemigo enemigo7;


int stage = 3;
void Iniciar()
{
    // Ventana de juego 
    ventana = new(170, 45, ConsoleColor.Black, limiteSuperior: new Point(5, 3), limiteInferior: new Point(165, 43));
    ventana.DibujarMarco();

    // Nave del jugador
    nave = new Nave(new Point(80, 40), 2, ConsoleColor.DarkBlue, ventana);
    nave.Dibujar();


    enemigo1 = new Enemigo(ConsoleColor.Red, ventana, new Point(20, 10), nave);
    enemigo2 = new Enemigo(ConsoleColor.Yellow, ventana, new Point(85, 10), nave);
    enemigo3 = new Enemigo(ConsoleColor.Magenta, ventana, new Point(145, 10), nave);

    enemigo4 = new Enemigo(ConsoleColor.Red, ventana, new Point(20, 20), nave);
    enemigo5 = new Enemigo(ConsoleColor.Magenta, ventana, new Point(145, 20), nave);
    miniBoss1 = new MiniBoss(ConsoleColor.DarkMagenta, ventana, new Point(60, 10), nave);
    miniBoss2 = new MiniBoss(ConsoleColor.DarkCyan, ventana, new Point(100, 10), nave);

    boss = new Boss(ConsoleColor.DarkRed, ventana, new Point(78, 5), nave);
    miniBoss3 = new MiniBoss(ConsoleColor.DarkGreen, ventana, new Point(45, 15), nave);
    miniBoss4 = new MiniBoss(ConsoleColor.DarkYellow, ventana, new Point(115, 15), nave);
    enemigo6 = new Enemigo(ConsoleColor.DarkGray, ventana, new Point(10, 20), nave);
    enemigo7 = new Enemigo(ConsoleColor.White, ventana, new Point(155, 20), nave);

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
            nave.Vida = 0;
            nave.Muerte();
            juego = false;
        }


        switch (stage)
        {
            case 1:
                nave.Enemigos.Add(enemigo1);
                nave.Enemigos.Add(enemigo2);
                nave.Enemigos.Add(enemigo3);

                enemigo1.Dibujar();
                enemigo2.Dibujar();
                enemigo3.Dibujar();
                stage = 4;
                break;
            case 2:
                nave.Enemigos.Add(enemigo4);
                nave.Enemigos.Add(enemigo5);
                nave.Enemigos.Add(miniBoss1);
                nave.Enemigos.Add(miniBoss2);

                enemigo4.Dibujar();
                enemigo5.Dibujar();
                miniBoss1.Dibujar();
                miniBoss2.Dibujar();

                stage = 5;
                break;
            case 3:
                stage = 6;
                ventana.Peligro();

                break;
            case 4:
                enemigo1.Mover();
                enemigo2.Mover();
                enemigo3.Mover();

                enemigo1.Disparar();
                enemigo2.Disparar();
                enemigo3.Disparar();
                break;
            case 5:
                enemigo4.Mover();
                enemigo5.Mover();
                miniBoss1.Mover();
                miniBoss2.Mover();

                enemigo4.Disparar();
                enemigo5.Disparar();
                miniBoss1.Disparar();
                miniBoss2.Disparar();
                break;
            case 6:
                nave.Enemigos.Add(boss);
                nave.Enemigos.Add(miniBoss3);
                nave.Enemigos.Add(miniBoss4);
                nave.Enemigos.Add(enemigo6);
                nave.Enemigos.Add(enemigo7);


                boss.Dibujar();
                miniBoss3.Dibujar();
                miniBoss4.Dibujar();
                enemigo6.Dibujar();
                enemigo7.Dibujar();

                stage = 7;
                break;
            case 7:
                boss.Mover();
                miniBoss3.Mover();
                miniBoss4.Mover();
                enemigo6.Mover();
                enemigo7.Mover();

                boss.Disparar();
                miniBoss3.Disparar();
                miniBoss4.Disparar();
                enemigo6.Disparar();
                enemigo7.Disparar();
                break;

        }

        if (stage == 4 && !enemigo1.Vivo  && !enemigo2.Vivo  && !enemigo3.Vivo )
        {
            stage = 2;
        }
        if (stage == 5 && !miniBoss1.Vivo  && !miniBoss2.Vivo  && !enemigo4.Vivo  && !enemigo5.Vivo)
        {
            stage = 3;
        }
        
        if (stage == 7 && !boss.Vivo && !miniBoss3.Vivo  && !miniBoss4.Vivo  && !enemigo6.Vivo && !enemigo7.Vivo )
        {
            juego = false;
        }








    }
}


Iniciar();
Game();
Console.ReadKey();
