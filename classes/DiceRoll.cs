using System;

namespace mini_battle.classes;

/*
Two different rolls for different things.
Could be the same and i input values where needed.
This works though.

I also don't return a multiplied value here for crits etc.
This is handled in the individual Character classes
For easy tweaking of multiplicative values.
*/
public static class DiceRoll
{
    private static Random dice = new Random();

    public static int rollTheDice()
    {
        int dSix = dice.Next(1, 7);
        return dSix;
    }
    public static int atkOrHeal()
    {
        int action = dice.Next(1, 10);
        return action;
    }
    
}
