using System;

namespace mini_battle.classes;

public static class DiceRoll
{
    static Random dice = new Random();

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
