using System;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;

namespace mini_battle.classes;

public class Enemy : Character
{
    public Enemy(string name, int maxHp, int atkDmg, int healPwr) : base(name, maxHp, atkDmg, healPwr)
    {

    }

    private bool rageModeActive = false;
    // Method for rage mode. Makes sure it doesn't run again if it's already active //
    private void RageMode()
    {
        if (currentHp <= maxHp / 2 && !rageModeActive)
        {
            atkDmg *= 2;
            rageModeActive = true;

            Textflow.ShowBorder("Holy shit you pissed him off! He's enetering rage mode!", '!');
        }
    }

    /*
    Enemy method for taking a turn.

    Largely the same as Player except it runs automatically with no input

    As you can see we only check for the value of the dice rolls here
    and multiply attack/healing values after the fact based on if it's
    a player or an enemy.
    The dice rolls only dictate if it's a Hit/Miss/Crit/etc.

    There's also some extra thread.sleeping for added effect.
    */
    public override void TakeTurn(Character atkTarget)
    {
        RageMode();

        Textflow.RollingText("\nIt's the enemies turn! Do they attack or heal?", 10);
        int action = DiceRoll.atkOrHeal();
        int critOrNah = DiceRoll.rollTheDice();
        Textflow.RollingText("\nThinking", 25, false);
        Textflow.Dots(450);
        Console.WriteLine("");
        if (action == 1)
        {
            Textflow.RollingText($"\nHaha! {name} slipped and took 10 damage! What an idiot!\n", 10);
            currentHp -= 10;
            Thread.Sleep(100);
        }
        else if (action == 2 || action == 3)
        {
            Textflow.RollingText($"\n{name} missed and hit the rock next to you.\nIt didn't seem to bother them though...\n", 10);
            Thread.Sleep(100);
        }
        else if (action > 3 && action <= 6)
        {
            Textflow.RollingText($"\n{name} is trying to heal themselves", 10);
            Textflow.Dots(250);
            if (currentHp == maxHp)
            {
                Textflow.RollingText($"\n{name} must be dumb! They tried to heal with full hp!\nTheir turn was wasted.\n", 10);
            }
            else if (critOrNah == 1)
            {
                Textflow.RollingText($"\n{name} coughed in the middle of casting and it did nothing.\n", 10);
            }
            else if (critOrNah == 6)
            {
                if (currentHp + healPwr * 2 >= maxHp)
                {
                    Textflow.ShowBorder($"Dangit! {name} healed with extra sparkles! They're back to full HP!", '!');
                    currentHp = maxHp;
                }
                else
                {
                    Textflow.ShowBorder($"{name} must have connections with heaven. They healed for {healPwr * 2} HP.", '!');
                    currentHp += healPwr * 2;
                }
            }
            else
            {
                if (currentHp + healPwr >= maxHp)
                {
                    Textflow.RollingText($"\n{name} succesfully healed and they're back to full HP!\n", 10);
                    currentHp = maxHp;
                }
                else
                {
                    Textflow.RollingText($"\n{name} succesfully healed for {healPwr} HP.\n", 10);
                    currentHp += healPwr;
                }
            }
        }
        else
        {
            Textflow.RollingText($"\n{name} is attacking! Watch out!", 10);
            Textflow.Dots(250);
            if (critOrNah == 1)
            {
                Textflow.RollingText($"\n{name} barely grazed your torso.\nStill hurts though...\nYou take {atkDmg / 2} damage.\n", 10);
                atkTarget.TakeDamage(atkDmg / 2);
            }
            else if (critOrNah == 6)
            {
                Textflow.ShowBorder($"OUCH! That one REALLY hurt! You take {atkDmg * 2} damage.", '!');
                atkTarget.TakeDamage(atkDmg * 2);
            }
            else
            {
                Textflow.RollingText($"\nIt's a hit!\nYou take {atkDmg} damage.\n", 10);
                atkTarget.TakeDamage(atkDmg);
            }
        }
    }
}