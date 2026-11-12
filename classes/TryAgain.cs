using System;

namespace mini_battle.classes;

public static class TryAgain
{

    public static bool Win()
    {
        while (true)
        {
            char tryAgain = Console.ReadKey(true).KeyChar;
            switch (tryAgain)
            {
                case 'y':
                    Textflow.RollingText("Oh wow, really...? Well... it's your funeral!");
                    return true;
                case 'n':
                    Textflow.RollingText("Wow okay... Take your money and get out of here!");
                    return false;
                default:
                    Textflow.RollingText("Was something unclear? Do you want to fight again? (y/n)");
                    break;
            }
        }
    }

    public static bool Lose()
    {
        while (true)
        {
            char tryAgain = Console.ReadKey(true).KeyChar;
            switch (tryAgain)
            {
                case 'y':
                    Textflow.RollingText("Good on you! One more try!");
                    return true;
                case 'n':
                    Textflow.RollingText("Oh okay I guess we just let them kill everyone...!");
                    return false;
                default:
                    Textflow.RollingText("Was something unclear? Do you want to fight again? (y/n)");
                    break;
            }
        }
    }
}
