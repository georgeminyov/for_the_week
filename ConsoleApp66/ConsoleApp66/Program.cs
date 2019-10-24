using System;

namespace DontBeMadMan
{
    class Program
    {
        static void Main(string[] args)
        {
            int dice = 0;
            int positions = 20;
            int[] goBackPositions = new int[] { 8, 12, 16 }; // go back 5 positions when landing on these
            int[] goForwardPositions = new int[] { 9, 10, 14 }; // go forward 3 positions when landing on these
            int[] figures = new int[4];
            int P1Sum = 0;
            int P2Sum = 0;
            int P3Sum = 0;
            int P4Sum = 0;
            bool currentFigureActiveP1 = false;
            bool currentFigureActiveP2 = false;
            bool currentFigureActiveP3 = false;
            bool currentFigureActiveP4 = false;
            bool active = false;
            int counterP1 = 0;
            int counterP2 = 0;
            int counterP3 = 0;
            int counterP4 = 0;

            Console.WriteLine("<=><=><=><=><=><=><=>WELCOME TO DON`T BE MAD MAN<=><=><=><=><=><=><=>");
            Console.WriteLine("The goal is to reach the 4 final possitions with all 4 of your figures to win the game!");

            while (counterP1 <= 3 && counterP2 <= 3 && counterP3 <= 3 && counterP4 <= 3)
            {


            NextTurn:



                Console.WriteLine();
                Console.ReadKey();
                // ======================= PLAYER 1
                for (int j = 0; j < figures.Length; j *= 1)
                {
                    dice = Dice();
                    if (!active && !currentFigureActiveP1 && counterP1 == 0)
                    {
                        Console.WriteLine("Player {0}`s first figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP1 && counterP1 == 1)
                    {
                        Console.WriteLine("Player {0}`s second figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP1 && counterP1 == 2)
                    {
                        Console.WriteLine("Player {0}`s third figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP1 && counterP1 == 3)
                    {
                        Console.WriteLine("Player {0}`s fourth figure hasn`t started yet", j + 1);
                    }
                    else
                    {
                        Console.WriteLine("Player {0} is rolling the dice", j + 1);
                    }
                    figures[j] = dice;

                    Console.WriteLine("Player {0} got a {1}", j + 1, figures[j]);

                    if (figures[j] == 6)
                    {
                        if (P1Sum + figures[j] <= positions && currentFigureActiveP1)
                        {
                            P1Sum += figures[j];

                            P1KnockOutP2(ref P2Sum, P1Sum, P2Sum, ref currentFigureActiveP2, ref active);
                            P1KnockOutP3(ref P3Sum, P1Sum, P3Sum, ref currentFigureActiveP3, ref active);
                            P1KnockOutP4(ref P4Sum, P1Sum, P4Sum, ref currentFigureActiveP4, ref active);


                        }

                        active = true;
                        currentFigureActiveP1 = true;
                        continue;
                    }
                    else
                    {
                        active = false;
                    }
                    if (active || currentFigureActiveP1 && P1Sum + figures[j] <= positions)
                    {
                        P1Sum += figures[j];

                        P1KnockOutP2(ref P2Sum, P1Sum, P2Sum, ref currentFigureActiveP2, ref active);
                        P1KnockOutP3(ref P3Sum, P1Sum, P3Sum, ref currentFigureActiveP3, ref active);
                        P1KnockOutP4(ref P4Sum, P1Sum, P4Sum, ref currentFigureActiveP4, ref active);


                    }
                    if (P1Sum == positions)
                    {
                        counterP1++;

                        P1Sum = 0;
                        active = false;
                        currentFigureActiveP1 = false;
                        if (counterP1 == 1)
                        {
                            Console.WriteLine("Player {0} has accommodated his first figure on it`s final destination", j + 1);
                        }
                        else if (counterP1 > 1 && counterP1 < 3)
                        {
                            Console.WriteLine("Player {0} has accommodated another figure", j + 1);
                        }
                        else if (counterP1 == 3)
                        {
                            Console.WriteLine("Player {0} has accommodated his last figure", j + 1);
                        }

                    }
                    for (int k = 0; k < goBackPositions.Length; k++)
                    {
                        if (P1Sum == goBackPositions[k] && counterP1 == 0)
                        {
                            Console.WriteLine("Player {0}`s first figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P1Sum);
                            P1Sum -= 5;
                        }
                        else if (P1Sum == goBackPositions[k] && counterP1 == 1)
                        {
                            Console.WriteLine("Player {0}`s second figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P1Sum);
                            P1Sum -= 5;
                        }
                        else if (P1Sum == goBackPositions[k] && counterP1 == 2)
                        {
                            Console.WriteLine("Player {0}`s third figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P1Sum);
                            P1Sum -= 5;
                        }
                        else if (P1Sum == goBackPositions[k] && counterP1 == 3)
                        {
                            Console.WriteLine("Player {0}`s fourth figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P1Sum);
                            P1Sum -= 5;
                        }
                    }

                    for (int k = 0; k < goForwardPositions.Length; k++)
                    {
                        if (P1Sum == goForwardPositions[k] && counterP1 == 0 && P1Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s first figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P1Sum);
                            P1Sum += 3;
                        }
                        else if (P1Sum == goForwardPositions[k] && counterP1 == 1 && P1Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s second figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P1Sum);
                            P1Sum += 3;
                        }
                        else if (P1Sum == goForwardPositions[k] && counterP1 == 2 && P1Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s third figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P1Sum);
                            P1Sum += 3;
                        }
                        else if (P1Sum == goForwardPositions[k] && counterP1 == 3 && P1Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s fourth figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P1Sum);
                            P1Sum += 3;
                        }

                    }
                    if (counterP1 == 0)
                    {
                        Console.WriteLine("Player {0}`s first figure is on possition : {1}", j + 1, P1Sum);
                    }
                    else if (counterP1 == 1)
                    {
                        Console.WriteLine("Player {0}`s second figure is on possition : {1}", j + 1, P1Sum);
                    }
                    else if (counterP1 == 2)
                    {
                        Console.WriteLine("Player {0}`s third figure is on possition : {1}", j + 1, P1Sum);
                    }
                    else if (counterP1 == 3)
                    {
                        Console.WriteLine("Player {0}`s fourth figure is on possition : {1}", j + 1, P1Sum);
                    }

                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
                if (counterP1 > 3)
                {
                    Console.WriteLine("Player 1 won the game!!!");
                    break;


                }
                // =========================== PLAYER 2
                for (int j = 1; j < figures.Length; j *= 1)
                {
                    dice = Dice();
                    if (!active && !currentFigureActiveP2 && counterP2 == 0)
                    {
                        Console.WriteLine("Player {0}`s first figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP2 && counterP2 == 1)
                    {
                        Console.WriteLine("Player {0}`s second figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP2 && counterP2 == 2)

                    {
                        Console.WriteLine("Player {0}`s third figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP2 && counterP2 == 3)
                    {
                        Console.WriteLine("Player {0}`s fourth figure hasn`t started yet", j + 1);
                    }
                    else
                    {
                        Console.WriteLine("Player {0} is rolling the dice", j + 1);
                    }
                    figures[j] = dice;

                    Console.WriteLine("Player {0} got a {1}", j + 1, figures[j]);


                    if (figures[j] == 6)
                    {
                        if (P2Sum + figures[j] <= positions && currentFigureActiveP2)
                        {
                            P2Sum += figures[j];

                            P2KnockOutP1(ref P1Sum, P2Sum, P1Sum, ref currentFigureActiveP1, ref active);
                            P2KnockOutP3(ref P3Sum, P2Sum, P3Sum, ref currentFigureActiveP3, ref active);
                            P2KnockOutP4(ref P4Sum, P2Sum, P4Sum, ref currentFigureActiveP4, ref active);


                        }
                        active = true;
                        currentFigureActiveP2 = true;
                        continue;
                    }
                    else
                    {
                        active = false;
                    }
                    if (active || currentFigureActiveP2 && P2Sum + figures[j] <= positions)
                    {
                        P2Sum += figures[j];

                        P2KnockOutP1(ref P1Sum, P2Sum, P1Sum, ref currentFigureActiveP1, ref active);
                        P2KnockOutP3(ref P3Sum, P2Sum, P3Sum, ref currentFigureActiveP3, ref active);
                        P2KnockOutP4(ref P4Sum, P2Sum, P4Sum, ref currentFigureActiveP4, ref active);


                    }
                    if (P2Sum == positions)
                    {

                        counterP2++;

                        P2Sum = 0;
                        active = false;
                        currentFigureActiveP2 = false;
                        if (counterP2 == 1)
                        {
                            Console.WriteLine("Player {0} has accommodated his first figure on it`s final destination", j + 1);
                        }
                        else if (counterP2 > 1 && counterP2 < 3)
                        {
                            Console.WriteLine("Player {0} has accommodated another figure", j + 1);
                        }
                        else if (counterP2 == 3)
                        {
                            Console.WriteLine("Player {0} has accommodated his last figure", j + 1);
                        }
                    }
                    for (int k = 0; k < goBackPositions.Length; k++)
                    {

                        if (P2Sum == goBackPositions[k] && counterP2 == 0)
                        {
                            Console.WriteLine("Player {0}`s first figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P2Sum);
                            P2Sum -= 5;
                        }
                        if (P2Sum == goBackPositions[k] && counterP2 == 1)
                        {
                            Console.WriteLine("Player {0}`s second figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P2Sum);
                            P2Sum -= 5;
                        }
                        if (P2Sum == goBackPositions[k] && counterP2 == 2)
                        {
                            Console.WriteLine("Player {0}`s third figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P2Sum);
                            P2Sum -= 5;
                        }
                        if (P2Sum == goBackPositions[k] && counterP2 == 3)
                        {
                            Console.WriteLine("Player {0}`s fourth figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P2Sum);
                            P2Sum -= 5;
                        }
                    }

                    for (int k = 0; k < goForwardPositions.Length; k++)
                    {
                        if (P2Sum == goForwardPositions[k] && counterP2 == 0 && P2Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s first figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P2Sum);
                            P2Sum += 3;
                        }
                        if (P2Sum == goForwardPositions[k] && counterP2 == 1 && P2Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s second figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P2Sum);
                            P2Sum += 3;
                        }
                        if (P2Sum == goForwardPositions[k] && counterP2 == 2 && P2Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s third figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P2Sum);
                            P2Sum += 3;
                        }
                        if (P2Sum == goForwardPositions[k] && counterP2 == 3 && P2Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s fourth figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P2Sum);
                            P2Sum += 3;
                        }
                    }
                    if (counterP2 == 0)
                    {
                        Console.WriteLine("Player {0}`s first figure is on possition : {1}", j + 1, P2Sum);
                    }
                    if (counterP2 == 1)
                    {
                        Console.WriteLine("Player {0}`s second figure is on possition : {1}", j + 1, P2Sum);
                    }
                    if (counterP2 == 2)
                    {
                        Console.WriteLine("Player {0}`s third figure is on possition : {1}", j + 1, P2Sum);
                    }
                    if (counterP2 == 3)
                    {
                        Console.WriteLine("Player {0}`s fourth figure is on possition : {1}", j + 1, P2Sum);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }

                if (counterP2 > 3)
                {
                    Console.WriteLine("Player 2 won the game !!!");
                    break;


                }
                // ============================= PLAYER 3
                for (int j = 2; j < figures.Length; j *= 1)
                {
                    dice = Dice();
                    if (!active && !currentFigureActiveP3 && counterP3 == 0)
                    {
                        Console.WriteLine("Player {0}`s first figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP3 && counterP3 == 1)
                    {
                        Console.WriteLine("Player {0}`s second figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP3 && counterP3 == 2)
                    {
                        Console.WriteLine("Player {0}`s third figure hasn`t started yet", j + 1);
                    }
                    if (!active && !currentFigureActiveP3 && counterP3 == 3)
                    {
                        Console.WriteLine("Player {0}`s fourth figure hasn`t started yet", j + 1);
                    }
                    else
                    {
                        Console.WriteLine("Player {0} is rolling the dice", j + 1);
                    }
                    figures[j] = dice;

                    Console.WriteLine("Player {0} got a {1}", j + 1, figures[j]);


                    if (figures[j] == 6)
                    {
                        if (P3Sum + figures[j] <= positions && currentFigureActiveP3)
                        {
                            P3Sum += figures[j];

                            P3KnockOutP1(ref P1Sum, P3Sum, P1Sum, ref currentFigureActiveP1, ref active);
                            P3KnockOutP2(ref P2Sum, P3Sum, P2Sum, ref currentFigureActiveP2, ref active);
                            P3KnockOutP4(ref P4Sum, P3Sum, P4Sum, ref currentFigureActiveP4, ref active);

                        }
                        active = true;
                        currentFigureActiveP3 = true;
                        continue;
                    }
                    else
                    {
                        active = false;
                    }
                    if (active || currentFigureActiveP3 && P3Sum + figures[j] <= positions)
                    {
                        P3Sum += figures[j];

                        P3KnockOutP1(ref P1Sum, P3Sum, P1Sum, ref currentFigureActiveP1, ref active);
                        P3KnockOutP2(ref P2Sum, P3Sum, P2Sum, ref currentFigureActiveP2, ref active);
                        P3KnockOutP4(ref P4Sum, P3Sum, P4Sum, ref currentFigureActiveP4, ref active);


                    }

                    if (P3Sum == positions)
                    {

                        counterP3++;

                        P3Sum = 0;
                        active = false;
                        currentFigureActiveP3 = false;
                        if (counterP3 == 1)
                        {
                            Console.WriteLine("Player {0} has accommodated his first figure on it`s final destination", j + 1);
                        }
                        else if (counterP3 > 1 && counterP3 < 3)
                        {
                            Console.WriteLine("Player {0} has accommodated another figure", j + 1);
                        }
                        else if (counterP3 == 3)
                        {
                            Console.WriteLine("Player {0} has accommodated his last figure", j + 1);
                        }
                    }
                    for (int k = 0; k < goBackPositions.Length; k++)
                    {
                        if (P3Sum == goBackPositions[k] && counterP3 == 0)
                        {
                            Console.WriteLine("Player {0}`s first figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P3Sum);
                            P3Sum -= 5;
                        }
                        if (P3Sum == goBackPositions[k] && counterP3 == 1)
                        {
                            Console.WriteLine("Player {0}`s second figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P3Sum);
                            P3Sum -= 5;
                        }
                        if (P3Sum == goBackPositions[k] && counterP3 == 2)
                        {
                            Console.WriteLine("Player {0}`s third figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P3Sum);
                            P3Sum -= 5;
                        }
                        if (P3Sum == goBackPositions[k] && counterP3 == 3)
                        {
                            Console.WriteLine("Player {0}`s fourth figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P3Sum);
                            P3Sum -= 5;
                        }
                    }

                    for (int k = 0; k < goForwardPositions.Length; k++)
                    {
                        if (P3Sum == goForwardPositions[k] && counterP3 == 0 && P3Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s first figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P3Sum);
                            P3Sum += 3;
                        }
                        if (P3Sum == goForwardPositions[k] && counterP3 == 1 && P3Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s second figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P3Sum);
                            P3Sum += 3;
                        }
                        if (P3Sum == goForwardPositions[k] && counterP3 == 2 && P3Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s third figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P3Sum);
                            P3Sum += 3;
                        }
                        if (P3Sum == goForwardPositions[k] && counterP3 == 3 && P3Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s fourth figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P3Sum);
                            P3Sum += 3;
                        }
                    }
                    if (counterP3 == 0)
                    {
                        Console.WriteLine("Player {0}`s first figure is on possition : {1}", j + 1, P3Sum);
                    }
                    if (counterP3 == 1)
                    {
                        Console.WriteLine("Player {0}`s second figure is on possition : {1}", j + 1, P3Sum);
                    }
                    if (counterP3 == 2)
                    {
                        Console.WriteLine("Player {0}`s third figure is on possition : {1}", j + 1, P3Sum);
                    }
                    if (counterP3 == 3)
                    {
                        Console.WriteLine("Player {0}`s fourth figure is on possition : {1}", j + 1, P3Sum);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
                if (counterP3 > 3)
                {
                    Console.WriteLine("Player 3 won the game !!!");
                    break;


                }
                // ================================== PLAYER 4 
                for (int j = 3; j < figures.Length; j *= 1)
                {
                    dice = Dice();
                    if (!active && !currentFigureActiveP4 && counterP4 == 0)
                    {
                        Console.WriteLine("Player {0}`s first figure hasn`t started yet", j + 1);
                    }
                    else if (!active && !currentFigureActiveP4 && counterP4 == 1)
                    {

                        Console.WriteLine("Player {0}`s second figure hasn`t started yet", j + 1);
                    }
                    else if (!active && !currentFigureActiveP4 && counterP4 == 2)
                    {
                        Console.WriteLine("Player {0}`s third figure hasn`t started yet", j + 1);
                    }
                    else if (!active && !currentFigureActiveP4 && counterP4 == 3)
                    {
                        Console.WriteLine("Player {0}`s fourth figure hasn`t started yet", j + 1);
                    }
                    figures[j] = dice;

                    Console.WriteLine("Player {0} got a {1}", j + 1, figures[j]);


                    if (figures[j] == 6)
                    {
                        if (P4Sum + figures[j] <= positions && currentFigureActiveP4)
                        {
                            P4Sum += figures[j];

                            P4KnockOutP1(ref P1Sum, P4Sum, P1Sum, ref currentFigureActiveP1, ref active);
                            P4KnockOutP2(ref P2Sum, P4Sum, P2Sum, ref currentFigureActiveP2, ref active);
                            P4KnockOutP3(ref P3Sum, P4Sum, P3Sum, ref currentFigureActiveP3, ref active);


                        }
                        active = true;
                        currentFigureActiveP4 = true;
                        continue;
                    }
                    else
                    {
                        active = false;
                    }
                    if (active || currentFigureActiveP4 && P4Sum + figures[j] <= positions)
                    {
                        P4Sum += figures[j];

                        P4KnockOutP1(ref P1Sum, P4Sum, P1Sum, ref currentFigureActiveP1, ref active);
                        P4KnockOutP2(ref P2Sum, P4Sum, P2Sum, ref currentFigureActiveP2, ref active);
                        P4KnockOutP3(ref P3Sum, P4Sum, P3Sum, ref currentFigureActiveP3, ref active);


                    }
                    if (P4Sum == positions)
                    {
                        counterP4++;

                        P4Sum = 0;
                        active = false;
                        currentFigureActiveP4 = false;
                        if (counterP4 == 1)
                        {
                            Console.WriteLine("Player {0} has accommodated his first figure on it`s final destination", j + 1);
                        }
                        else if (counterP4 > 1 && counterP4 < 3)
                        {
                            Console.WriteLine("Player {0} has accommodated another figure", j + 1);
                        }
                        else if (counterP4 == 3)
                        {
                            Console.WriteLine("Player {0} has accommodated his last figure", j + 1);
                        }
                    }
                    for (int k = 0; k < goBackPositions.Length; k++)
                    {
                        if (P4Sum == goBackPositions[k] && counterP4 == 0)
                        {
                            Console.WriteLine("Player {0}`s first figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P4Sum);
                            P4Sum -= 5;
                        }
                        if (P4Sum == goBackPositions[k] && counterP4 == 1)
                        {
                            Console.WriteLine("Player {0}`s second figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P4Sum);
                            P4Sum -= 5;
                        }
                        if (P4Sum == goBackPositions[k] && counterP4 == 2)
                        {
                            Console.WriteLine("Player {0}`s third figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P3Sum);
                            P4Sum -= 5;
                        }
                        if (P4Sum == goBackPositions[k] && counterP4 == 3)
                        {
                            Console.WriteLine("Player {0}`s fourth figure has landed on a BOMB position {1} and goes back 5 positions.", j + 1, P4Sum);
                            P4Sum -= 5;
                        }
                    }

                    for (int k = 0; k < goForwardPositions.Length; k++)
                    {
                        if (P4Sum == goForwardPositions[k] && counterP4 == 0 && P4Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s first figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P4Sum);
                            P4Sum += 3;
                        }
                        else if (P4Sum == goForwardPositions[k] && counterP4 == 1 && P4Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s second figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P4Sum);
                            P4Sum += 3;
                        }
                        else if (P4Sum == goForwardPositions[k] && counterP4 == 2 && P4Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s third figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P4Sum);
                            P4Sum += 3;
                        }
                        else if (P4Sum == goForwardPositions[k] && counterP4 == 3 && P4Sum + 3 < positions)
                        {
                            Console.WriteLine("Player {0}`s fourth figure has landed on a FAST FORWARD position {1} and goes forward 3 positions.", j + 1, P4Sum);
                            P4Sum += 3;
                        }
                    }
                    if (counterP4 == 0)
                    {
                        Console.WriteLine("Player {0}`s first figure is on possition : {1}", j + 1, P4Sum);
                    }
                    if (counterP4 == 1)
                    {
                        Console.WriteLine("Player {0}`s second figure is on possition : {1}", j + 1, P4Sum);
                    }
                    if (counterP4 == 2)
                    {
                        Console.WriteLine("Player {0}`s third figure is on possition : {1}", j + 1, P4Sum);
                    }
                    if (counterP4 == 3)
                    {
                        Console.WriteLine("Player {0}`s fourth figure is on possition : {1}", j + 1, P4Sum);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
                if (counterP4 > 3)
                {
                    Console.WriteLine("Player 4 won the game !!!");
                    break;


                }


                goto NextTurn;




            }




        }

        static int Dice()
        {
            Random number = new Random();
            return number.Next(1, 7);

        }
        static void P1KnockOutP2(ref int P2Sum, int p1Possition, int p2Possition, ref bool currentFigureActiveP2, ref bool active)
        {
            if (p1Possition == p2Possition && p1Possition > 0 && p2Possition > 0)
            {
                Console.WriteLine("Player 2 has been knosked out by, Player 1!");
                P2Sum = 0;
                currentFigureActiveP2 = false;
                active = false;
                Console.WriteLine("Player 2 is at posssition : " + P2Sum);
            }
        }
        static void P1KnockOutP3(ref int P3Sum, int p1Possition, int p3Possition, ref bool currentFigureActiveP3, ref bool active)
        {
            if (p1Possition == p3Possition && p1Possition > 0 && p3Possition > 0)
            {
                Console.WriteLine("Player 3 has been knosked out by, Player 1!");
                P3Sum = 0;
                currentFigureActiveP3 = false;
                active = false;
                Console.WriteLine("Player 3 is at posssition : " + P3Sum);
            }
        }
        static void P1KnockOutP4(ref int P4Sum, int p1Possition, int p4Possition, ref bool currentFigureActiveP4, ref bool active)
        {
            if (p1Possition == p4Possition && p1Possition > 0 && p4Possition > 0)
            {
                Console.WriteLine("Player 4 has been knosked out by, Player 1!");
                P4Sum = 0;
                currentFigureActiveP4 = false;
                active = false;
                Console.WriteLine("Player 4 is at posssition : " + P4Sum);
            }
        }
        static void P2KnockOutP1(ref int P1Sum, int p2Possition, int p1Possition, ref bool currentFigureActiveP1, ref bool active)
        {
            if (p2Possition == p1Possition && p2Possition > 0 && p1Possition > 0)
            {
                Console.WriteLine("Player 1 has been knosked out by, Player 2!");
                P1Sum = 0;
                currentFigureActiveP1 = false;
                active = false;
                Console.WriteLine("Player 1 is at posssition : " + P1Sum);
            }
        }
        static void P2KnockOutP3(ref int P3Sum, int p2Possition, int p3Possition, ref bool currentFigureActiveP3, ref bool active)
        {
            if (p2Possition == p3Possition && p2Possition > 0 && p3Possition > 0)
            {
                Console.WriteLine("Player 3 has been knosked out by, Player 2!");
                P3Sum = 0;
                currentFigureActiveP3 = false;
                active = false;
                Console.WriteLine("Player 3 is at posssition : " + P3Sum);
            }
        }
        static void P2KnockOutP4(ref int P4Sum, int p2Possition, int p4Possition, ref bool currentFigureActiveP4, ref bool active)
        {
            if (p2Possition == p4Possition && p2Possition > 0 && p4Possition > 0)
            {
                Console.WriteLine("Player 4 has been knosked out by, Player 2!");
                P4Sum = 0;
                currentFigureActiveP4 = false;
                active = false;
                Console.WriteLine("Player 4 is at posssition : " + P4Sum);
            }
        }
        static void P3KnockOutP1(ref int P1Sum, int p3Possition, int p1Possition, ref bool currentFigureActiveP1, ref bool active)
        {
            if (p3Possition == p1Possition && p3Possition > 0 && p1Possition > 0)
            {
                Console.WriteLine("Player 1 has been knosked out by, Player 3!");
                P1Sum = 0;
                currentFigureActiveP1 = false;
                active = false;
                Console.WriteLine("Player 1 is at posssition : " + P1Sum);
            }
        }
        static void P3KnockOutP2(ref int P2Sum, int p3Possition, int p2Possition, ref bool currentFigureActiveP2, ref bool active)
        {
            if (p3Possition == p2Possition && p3Possition > 0 && p2Possition > 0)
            {
                Console.WriteLine("Player 2 has been knosked out by, Player 3!");
                P2Sum = 0;
                currentFigureActiveP2 = false;
                active = false;
                Console.WriteLine("Player 2 is at  posssition : " + P2Sum);
            }
        }
        static void P3KnockOutP4(ref int P4Sum, int p3Possition, int p4Possition, ref bool currentFigureActiveP4, ref bool active)
        {
            if (p3Possition == p4Possition && p3Possition > 0 && p4Possition > 0)
            {
                Console.WriteLine("Player 4 has been knosked out by, Player 3!");
                P4Sum = 0;
                currentFigureActiveP4 = false;
                active = false;
                Console.WriteLine("Player 4 is at posssition : " + P4Sum);
            }
        }
        static void P4KnockOutP1(ref int P1Sum, int p4Possition, int p1Possition, ref bool currentFigureActiveP1, ref bool active)
        {
            if (p4Possition == p1Possition && p4Possition > 0 && p1Possition > 0)
            {
                Console.WriteLine("Player 1 has been knosked out by, Player 4!");
                P1Sum = 0;
                currentFigureActiveP1 = false;
                active = false;
                Console.WriteLine("Player 1 is at posssition : " + P1Sum);
            }
        }
        static void P4KnockOutP2(ref int P2Sum, int p4Possition, int p2Possition, ref bool currentFigureActiveP2, ref bool active)
        {
            if (p4Possition == p2Possition && p4Possition > 0 && p2Possition > 0)
            {
                Console.WriteLine("Player 2 has been knosked out by, Player 4!");
                P2Sum = 0;
                currentFigureActiveP2 = false;
                active = false;
                Console.WriteLine("Player 2 is at posssition : " + P2Sum);
            }
        }
        static void P4KnockOutP3(ref int P3Sum, int p4Possition, int p3Possition, ref bool currentFigureActiveP3, ref bool active)
        {
            if (p4Possition == p3Possition && p4Possition > 0 && p3Possition > 0)
            {
                Console.WriteLine("Player 3 has been knosked out by, Player 4!");
                P3Sum = 0;
                currentFigureActiveP3 = false;
                active = false;
                Console.WriteLine("Player 3 is at posssition : " + P3Sum);
            }
        }
    }
}