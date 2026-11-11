using System;
using System.Runtime;

namespace mini_battle.classes;

public class Player : Character
{
    public Player(string name, int maxHp, int atkDmg, int healPwr) : base(name, maxHp, atkDmg, healPwr)
    {

    }
    public override void TakeTurn(Character atkTarget)
    {
        Console.WriteLine("Your turn! Do you attack or heal? (a/h)");
        bool turn = true;
        while (turn)
        {
            char action = Console.ReadKey(true).KeyChar;

            switch (action)
            {
                case 'a':
                    int atkRoll = DiceRoll.rollTheDice();
                    if (atkRoll == 1)
                    {
                        Console.WriteLine("Yikes! You missed entirely!");
                    }
                    else if (atkRoll == 6)
                    {
                        atkTarget.TakeDamage(atkDmg * 3);
                        Console.WriteLine($"Critical Hit! You dealt {atkDmg * 2} damage! Boom!");
                    }
                    else
                    {
                        atkTarget.TakeDamage(atkDmg);
                        Console.WriteLine($"Hit! You dealt {atkDmg} damage!");
                    }
                    turn = false;
                    break;

                case 'h':

                    if (currentHp == maxHp)
                    {
                        Console.WriteLine("\n How silly of you! You're already full HP!\nDo you want to attack or heal?");
                    }
                    else
                    {
                        int healRoll = DiceRoll.rollTheDice();
                        if (healRoll == 1)
                        {
                            if (currentHp + healPwr / 2 >= maxHp)
                            {
                                Console.WriteLine($"You messed up the spell really bad.\nSomehow you're now full HP though...");
                                currentHp = maxHp;
                            }
                            else
                            {
                                Console.WriteLine($"Your tongue twisted and you only healed {healPwr / 2} HP.");
                                currentHp += healPwr / 2;
                            }
                        }
                        else if (healRoll == 6)
                        {
                            if (currentHp + healPwr * 2 >= maxHp)
                            {
                                Console.WriteLine("The god's themselves have blessed your spell!\nYou're now full HP.");
                                currentHp = maxHp;
                            }
                            else
                            {
                                Console.WriteLine($"Holy power washes over you and you heal for {healPwr * 3}!");
                                currentHp += healPwr * 3;
                            }
                        }
                        else
                        {
                            if (currentHp + healPwr >= maxHp)
                            {
                                Console.WriteLine("You're now full HP.");
                                currentHp = maxHp;
                            }
                            else
                            {
                                Console.WriteLine($"You heal yourself for {healPwr} HP!");
                                currentHp += healPwr;
                            }
                        }
                        turn = false;
                    }
                    break;

                default:
                    Console.WriteLine("You don't have time to mess around! Do you want to attack or heal? (a/h)");
                    break;
            }
        }
    }
}
