using System;
using System.Dynamic;

namespace mini_battle.classes;

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
    public abstract void TakeTurn();
}
