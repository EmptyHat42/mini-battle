using System;

namespace mini_battle.classes;

public class Player : Character
{
    public Player(string name, int maxHp, int atkDmg, int healPwr) : base(name, maxHp, atkDmg, healPwr)
    {

    }
    public override void TakeTurn()
    {
        Console.WriteLine("Your turn! Do you attack or heal?");

        char action = Console.ReadKey(true).KeyChar;
        switch (action)
        {
            case 'a':
                break;

            case 'h':
                if (currentHp == maxHp)
                {
                    Console.WriteLine("\n How silly of you! You're already full HP!");
                    break;
                }
                else
                {
                    
                }
                break;

            default:
                break;
        }
    }
}
