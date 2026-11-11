using System.Runtime.CompilerServices;
using mini_battle.classes;

Console.WriteLine("Welcome to Mini Battle!\nWhat is your name?");
string playerName = Console.ReadLine();
if (playerName == "")
{
    Console.WriteLine("Hehe you tried to leave it empty! Your name is now Stinky!");
    playerName = "Stinky";
}
Console.WriteLine("\nWelcome to the fight soldier " + playerName + "!\nAre you ready to bonk a bad guy?! (y/n)");

bool ready = false;
int answerCount = 1;

while (!ready)
{
    // Makes us only have to press a key to choose and not show the key pressed //
    char areYouReady = Console.ReadKey(true).KeyChar;
    switch (areYouReady)
    {
        case 'y':
            Console.WriteLine("\nYou crazy or something? You're gonna fi- OMG HERE HE COMES!!!");
            ready = true;
            break;

        case 'n':
            if (answerCount == 1)
            {
                Console.WriteLine("\nYou're not eligable to refuse? You wanna try that again? (y/n)");
            }
            else if (answerCount == 2)
            {
                Console.WriteLine("\nCome on now don't be like that! Please fight? (y/n)");
            }
            else if (answerCount == 3)
            {
                Console.WriteLine("\nERROR! CAN'T REFUSE! PLEASE ENTER: (y)");
            }
            else if (answerCount == 4)
            {
                Console.WriteLine("\nListen kid, we all gotta die someday. Time to kill or be killed!");
                ready = true;
            }
            answerCount++;
            break;

        default:
            Console.WriteLine("What are you doing? are you ready to bonk or no? (y/n)");
            break;
    }
}

bool weFighting = true;
while (weFighting)
{
    ///////////////////////////////////////
    /// TWEAK COMBAT STATS UNDER HERE!  ///
    ///////////////////////////////////////
    //Fully optional btw don't yell at me//
    //Should be balanced as they are     //
    //(I hope...)                        //
    //                                   //
    //(name, maxHp, atkDmg, healPwr)     //
    ///////////////////////////////////////

    // PLAYER //
    Player player = new Player(playerName, 100, 10, 20);

    // ENEMY //
    Enemy enemy = new Enemy("Mr. Bad Evil Man Guy", 200, 15, 10);

    ///////////////////////////////////////

    // For the border to work no matter the length of enemy.name //
    string combatMsg = $"!! {enemy.name} has suddenly appeared !!";
    string msgBorder = new string('!', combatMsg.Length);
    Console.WriteLine($"\n{msgBorder}\n{combatMsg}\n{msgBorder}\n");

    Console.WriteLine($"I guess you can go first since {playerName} is such an incredible name!");
    bool battle = true;
    while (battle)
    {
        if (player.currentHp <= 0)
        {
            Console.WriteLine("It seems you weren't strong enough...\nThis means i don't have to pay you hehehe.\nYou have died... try again? (y/n)");
            battle = false;
            weFighting = TryAgain.Lose();
        }
        player.TakeTurn(enemy);
        player.ShowHp();
        enemy.ShowHp();

        if (enemy.currentHp <= 0)
        {
            Console.WriteLine($"Holy shit i was sure you were gonna die! Damnit now i have to pay y...\nI mean... Congratulations on slaying {enemy.name}!!!\nWant to fight them again? Double or nothing? (y/n)");
            battle = false;
            weFighting = TryAgain.Win();
        }
        enemy.TakeTurn(player);
        player.ShowHp();
        enemy.ShowHp();
    }
}

Console.WriteLine("Thank you so much for playing Mini-Battle!\nPress any key to close the program.");

Console.ReadKey();