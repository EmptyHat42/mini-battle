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

    public override void TakeTurn(Character atkTarget)
    {
        Console.WriteLine("It's the enemies turn! Do they attack or heal?");
        int action = DiceRoll.atkOrHeal();
        int critOrNah = DiceRoll.rollTheDice();
        //Thread.Sleep(1000);
        Console.WriteLine("\nThinking...\n");
        //Thread.Sleep(3000);
        if (action == 1)
        {
            Console.WriteLine($"Haha! {name} slipped and took 10 damage! What an idiot!\n");
            currentHp -= 10;
        }
        else if (action == 2 || action == 3)
        {
            Console.WriteLine($"{name} missed and hit the rock next to you.\nIt didn't seem to bother them though...\n");
        }
        else if (action > 3 && action <= 6)
        {
            Console.WriteLine($"{name} is trying to heal themselves...");
            //Thread.Sleep(2000);
            if (currentHp == maxHp)
            {
                Console.WriteLine($"{name} must be dumb! They tried to heal with full hp!\nTheir turn was wasted.\n");
            }
            else if (critOrNah == 1)
            {
                Console.WriteLine($"{name} coughed in the middle of casting and it did nothing.\n");
            }
            else if (critOrNah == 6)
            {
                if (currentHp + healPwr * 2 >= maxHp)
                {
                    Console.WriteLine($"Dangit! {name} healed with extra sparkles!\nThey're back to full HP!\n");
                    currentHp = maxHp;
                }
                else
                {
                    Console.WriteLine($"{name} must have connections with heaven.\nThey healed {healPwr * 2} HP.\n");
                    currentHp += healPwr * 2;
                }
            }
            else
            {
                Console.WriteLine($"{name} succesfully healed for {healPwr} HP.\n");
                currentHp += healPwr;
            }
        }
        else
        {
            Console.WriteLine($"{name} is attacking! Watch out!");
            //Thread.Sleep(2000);
            if (critOrNah == 1)
            {
                Console.WriteLine($"{name} barely grazed your torso.\nStill hurts though...\nYou take {atkDmg / 2} damage.");
                atkTarget.TakeDamage(atkDmg / 2);
            }
            else if (critOrNah == 6)
            {
                Console.WriteLine($"Did you get Critically hit on purpose?!\nYou take {atkDmg * 2} damage.");
                atkTarget.TakeDamage(atkDmg * 2);
            }
            else
            {
                Console.WriteLine($"It's a hit!\nYou take {atkDmg} damage.");
                atkTarget.TakeDamage(atkDmg);
            }
        }
    }
}