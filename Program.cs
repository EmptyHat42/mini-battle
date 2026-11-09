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

///////////////////////////////////////
/// TWEAK COMBAT STATS UNDER HERE! ////
///////////////////////////////////////
//Fully optional btw don't yell at me//
//Should be balanced as they are     //
//(I hope...)                        //
///////////////////////////////////////

// PLAYER //
int playerHealth = 100;
int playerAtkDmg = 10;
int playerHealPwr = 20;

// ENEMY //
int enemyHealth = 200;
int enemyAtkDmg = 15;
int enemyHealPwr = 10;

///////////////////////////////////////

Player player = new Player(playerName, playerHealth, playerAtkDmg, playerHealPwr);
Enemy enemy = new Enemy("Mr. Bad Evil Man Guy", enemyHealth, enemyAtkDmg, enemyHealPwr);

bool ready = false;
int answerCount = 1;

while (!ready)
{
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

// For the border to work no matter the length of enemy.name //
string combatMsg = $"!! {enemy.name} has suddenly appeared !!";
string msgBorder = new string('!', combatMsg.Length);
Console.WriteLine($"""

{msgBorder}
{combatMsg}
{msgBorder}
""");

bool winOrLose = false;
while (!winOrLose)
{

}

Console.ReadKey();