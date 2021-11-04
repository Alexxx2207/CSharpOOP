using System;

public class Warrior
{
    private const int MIN_ATTACK_HP = 30;

    private string name;
    private int damage;
    private int hp;

    //here-ok
    public Warrior(string name, int damage, int hp)
    {
        this.Name = name;
        this.Damage = damage;
        this.HP = hp;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            //here-ok
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name should not be empty or whitespace!");
            }
            //here-ok
            this.name = value;
        }
    }

    public int Damage
    {
        get
        {
            return this.damage;
        }
        private set
        {//here-ok
            if (value <= 0)
            {
                throw new ArgumentException("Damage value should be positive!");
            }
            //here-ok
            this.damage = value;
        }
    }

    public int HP
    {
        get
        {
            return this.hp;
        }
        private set
        {//here-ok
            if (value < 0)
            {
                throw new ArgumentException("HP should not be negative!");
            }
            //here-ok
            this.hp = value;
        }
    }

    public void Attack(Warrior warrior)
    {//here-ok
        if (this.HP <= MIN_ATTACK_HP)
        {
            throw new InvalidOperationException("Your HP is too low in order to attack other warriors!");
        }
        //here-ok
        if (warrior.HP <= MIN_ATTACK_HP)
        {
            throw new InvalidOperationException($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }
        //here-ok
        if (this.HP < warrior.Damage)
        {
            throw new InvalidOperationException($"You are trying to attack too strong enemy");
        }
        //here-ok
        this.HP -= warrior.Damage;
        //here-ok
        if (this.Damage > warrior.HP)
        {
            warrior.HP = 0;
        }
        else
        {
            //here-ok
            warrior.HP -= this.Damage;
        }
    }
}