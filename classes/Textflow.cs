using System;

namespace mini_battle.classes;

public static class Textflow
{
    private static void NoPressing()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }
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
