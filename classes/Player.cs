using System;
using System.Runtime;

namespace mini_battle.classes;

public class Player : Character
{
    public Player(string name, int maxHp, int atkDmg, int healPwr) : base(name, maxHp, atkDmg, healPwr)
    {

    }
    /*
    Player method for taking a turn.

    As you can see we only check for the value of the dice rolls here
    and multiply attack/healing values after the fact based on if it's
    a player or an enemy.
    The dice rolls only dictate if it's a Hit/Miss/Crit/etc.
    */
    public override void TakeTurn(Character atkTarget)
    {
        Textflow.RollingText($"\n{name}'s turn! Do you attack or heal? (a/h)", 10);
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
                        Textflow.RollingText($"\nYikes! {name} missed entirely!\n", 10);
                    }
                    else if (atkRoll == 6)
                    {
                        atkTarget.TakeDamage(atkDmg * 3);

                        Textflow.ShowBorder($"Critical Hit! {name} dealt {atkDmg * 3} damage!", '#');
                    }
                    else
                    {
                        atkTarget.TakeDamage(atkDmg);
                        Textflow.RollingText($"\nHit! {name} dealt {atkDmg} damage!\n", 10);
                    }
                    turn = false;
                    break;

                case 'h':

                    if (currentHp == maxHp)
                    {
                        Textflow.RollingText($"\nHow silly of you! {name} is already full HP!\nDo you want to attack or heal?\n", 10);
                    }
                    else
                    {
                        int healRoll = DiceRoll.rollTheDice();
                        if (healRoll == 1)
                        {
                            if (currentHp + healPwr / 2 >= maxHp)
                            {
                                Textflow.RollingText($"\n{name} messed up the spell really bad.\nSomehow {name} is full HP now though...\n", 10);
                                currentHp = maxHp;
                            }
                            else
                            {
                                Textflow.RollingText($"\n{name}'s tongue twisted and only healed for {healPwr / 2} HP.\n", 10);
                                currentHp += healPwr / 2;
                            }
                        }
                        else if (healRoll == 6)
                        {
                            if (currentHp + healPwr * 3 >= maxHp)
                            {
                                Textflow.ShowBorder($"The gods themselves have blessed {name}'s spell! They're now full HP.", '#');
                                currentHp = maxHp;
                            }
                            else
                            {
                                Textflow.ShowBorder($"Holy power washes over {name} and they heal for {healPwr * 3}!", '#');
                                currentHp += healPwr * 3;
                            }
                        }
                        else
                        {
                            if (currentHp + healPwr >= maxHp)
                            {
                                Textflow.RollingText($"\n{name} is now full HP.\n", 10);
                                currentHp = maxHp;
                            }
                            else
                            {
                                Textflow.RollingText($"\n{name} heals themselves for {healPwr} HP!\n", 10);
                                currentHp += healPwr;
                            }
                        }
                        turn = false;
                    }
                    break;

                default:
                    Textflow.RollingText("\nYou don't have time to mess around! Do you want to attack or heal? (a/h)\n", 10);
                    break;
            }
        }
    }
}
