using System;

namespace mini_battle.classes;

// Class for making sure the text looks like a nice RPG //
public static class Textflow
{
    // Makes sure the player can't spam keys while waiting for text to roll //
    private static void NoPressing()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }

    // Write out one letter at a time for an RPG textbox feel //
    public static void RollingText(string text, int wait = 25, bool newLine = true)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);
            Thread.Sleep(wait);
        }
        if (newLine)
        {
            Console.WriteLine("");
        }
        NoPressing();
    }

    // Write out three dots at input speed for extra effect //
    public static void Dots(int speed)
    {
        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(speed);
            Console.Write(".");
        }
        Thread.Sleep(speed);
        NoPressing();
    }

    // Makes sure that the border is consistent regardless of content-length //
    public static void ShowBorder(string content, char symbol, bool rolling = true)
    {
        content = $"{symbol}{symbol} {content} {symbol}{symbol}";
        string msgBorder = new string(symbol, content.Length);
        if (rolling)
        {
            RollingText($"\n{msgBorder}\n{content}\n{msgBorder}\n", 1);
        }
        else
        {
            Console.WriteLine($"\n{msgBorder}\n{content}\n{msgBorder}\n");
        }
    }
}

/*
SIDENOTE: 

I was playing around with having different text-colors for different parts of the game
but inevitebly decided against it since it became crazy complex.
*/
