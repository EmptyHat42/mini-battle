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
                    Console.WriteLine("Oh wow, really...? Well... it's your funeral!");
                    return true;
                case 'n':
                    Console.WriteLine("Wow okay... Take your money and get out of here!");
                    return false;
                default:
                    Console.WriteLine("Was something unclear? Do you want to fight again? (y/n)");
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
                    Console.WriteLine("Good on you! One more try!");
                    return true;
                case 'n':
                    Console.WriteLine("Oh okay i guess we just let them kill everyone i guess...!");
                    return false;
                default:
                    Console.WriteLine("Was something unclear? Do you want to fight again? (y/n)");
                    break;
            }
        }
    }
}
