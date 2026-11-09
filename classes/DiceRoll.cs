using System;

namespace mini_battle.classes;

public static class DiceRoll
{
    static Random dice = new Random();

    public static int rollTheDice()
    {
        int dTwenty = dice.Next(1, 21);
        return dTwenty;
    }
    
}
