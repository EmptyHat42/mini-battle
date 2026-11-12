using System.Runtime.CompilerServices;
using mini_battle.classes;

Textflow.RollingText("Welcome to Mini Battle!\nWhat would you like to name your character?");
string playerName;
while (true)
{
    playerName = Console.ReadLine() ?? "";
    if (playerName == "")
    {
        Textflow.RollingText("Hehe you tried to leave it empty! Your characters name is now Stinky!");
        playerName = "Stinky";
        break;
    }
    else if (playerName.Length > 20)
    {
        Textflow.RollingText("That name is way to long buddy! Keep it under 20 characters!");
    }
    else
    {
        break;
    }
}
Textflow.ShowBorder(playerName, '~');
Thread.Sleep(500);
Textflow.RollingText("\nWelcome to the fight " + playerName + "!\nAre you ready to bonk a bad guy?! (y/n)");
bool ready = false;
int answerCount = 1;

while (!ready)
{
    // Makes us only have to press a key to choose (instead of having to press enter) and not show the key pressed //
    char areYouReady = Console.ReadKey(true).KeyChar;
    switch (areYouReady)
    {
        case 'y':
            Textflow.RollingText("\nYou crazy or something? You're actually gonna fi- OMG HERE THEY COME!!!");
            ready = true;
            break;

        case 'n':
            if (answerCount == 1)
            {
                Textflow.RollingText("\nYou're not eligable to refuse? You wanna try that again? (y/n)");
            }
            else if (answerCount == 2)
            {
                Textflow.RollingText("\nCome on now don't be like that! Please fight? (y/n)");
            }
            else if (answerCount == 3)
            {
                Textflow.RollingText("\nERROR! CAN'T REFUSE! PLEASE ENTER: (y)");
            }
            else if (answerCount == 4)
            {
                Textflow.RollingText("\nYou tried to refuse again?\nListen kid, we all gotta die someday. Time to kill or be killed!");
                ready = true;
            }
            answerCount++;
            break;

        default:
            Textflow.RollingText("What are you doing? Are you ready to bonk or no? (y/n)");
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
    Player player = new Player(
        playerName, //Name is picked at the start of the game

        100, //HP

        10, //Attack Damage

        20 //Healing power
        );

    // ENEMY //
    Enemy enemy = new Enemy(
        "Mr. Bad Evil Man Guy", //Name

        200, //HP

        15, //Attack Damage

        10 //Healing power
        );

    ///////////////////////////////////////

    Textflow.ShowBorder($"{enemy.name} has suddenly appeared", '!');

    Textflow.RollingText($"I guess you can go first since ~{playerName}~ is such an incredible name!\n");
    while (true)
    {
        if (player.currentHp <= 0)
        {
            Textflow.ShowBorder($"{player.name} has died! You Lost!", '-');
            Textflow.RollingText($"It seems {player.name} wasn't strong enough", 25, false);
            Textflow.Dots(700);
            Textflow.RollingText("\nThis means I don't have to pay you hehehe.\nYou have died... try again? (y/n)\n");
            weFighting = TryAgain.Lose();
            break;
        }
        Textflow.ShowBorder($"{player.ShowHp()} ||| {enemy.ShowHp()}", '=', false);
        player.TakeTurn(enemy);


        if (enemy.currentHp <= 0)
        {
            Textflow.ShowBorder($"{playerName} has defeated {enemy.name}! You Win!", '+');
            Textflow.RollingText($"Holy shit I was sure {player.name} was gonna die! Damnit now I have to pay y", 25, false);
            Textflow.Dots(500);
            Textflow.RollingText($"\nI mean... Congratulations on slaying {enemy.name}!!!\nWant to fight them again? Double or nothing? (y/n)\n");
            weFighting = TryAgain.Win();
            break;
        }
        enemy.TakeTurn(player);

    }
}

Textflow.RollingText("\nThank you so much for playing Mini-Battle!\nPress any key to close the program.\n");

Console.ReadKey(true);
Textflow.RollingText("""
EmptyHat is not liable for any damage caused to you, your family or your loved ones during the duration of the game.
If you have a complaint please take it up with the complain department.
If you cannot reach the complain department please go to your nearest payphone and dial 070-WEWONTHELP.
If you have an addiction to Mini-battle and can't stop playing please do nothing and start the game again.
Again thank you for playing.
I love you.
""", 1);