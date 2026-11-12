using System;
using System.Dynamic;

namespace mini_battle.classes;

// Base class for Characters. Parent to Player and Enemy //
abstract public class Character
{
    public string name {get; set;}
    public int maxHp {get; set;}
    public int currentHp {get; set;}
    public int atkDmg {get; set;}
    public int healPwr {get; set;}

    public Character(string name, int maxHp, int atkDmg, int healPwr)
    {
        this.name = name;
        this.maxHp = maxHp;
        this.currentHp = maxHp;
        this.atkDmg = atkDmg;
        this.healPwr = healPwr;
    }
    // Method for taking a turn. Overridden differently for player and enemy //
    public abstract void TakeTurn(Character atkTarget);

    // Makes sure that a character can't go too far below 0 //
    public void TakeDamage(int dmg)
    {
        currentHp -= dmg;
        if (currentHp < 0)
        {
            currentHp = 0;
        }
    }
    
    public string ShowHp()
    {
        return $"{name} HP: {currentHp}/{maxHp}";
    }
}
