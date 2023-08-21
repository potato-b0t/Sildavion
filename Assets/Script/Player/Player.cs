using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "Create/Custom Asset/Player")]
public class Player : ScriptableObject
{

    public Life life;

    public Armor armor;

    public speed speed;

#pragma warning disable IDE1006
    public void setDamage(int damage, Elements type)
    {
        ElementArmor armorGetted = armor.find(type);


        life.SetNewLife(damage - (damage * armorGetted.armor));

        Debug.Log(life.LifeValue + " " + damage);
    }

}

[System.Serializable]
public struct Life
{
    [Header("Life Values")]
    //Life values and functions

    public int max_life;

    private int max_life_original;

    public int LifeValue;

    private int life
    {
        set
        {
            LifeValue = Mathf.Clamp(value, 0, max_life);
        }
#pragma warning disable IDE0251
        get
        {
            return LifeValue;
        }
    }

    public void setMaxLifeDefault()
    {
        max_life_original = max_life;
        life = max_life;
    }

    public int getLife()
    {
        return life;
    }
    public void SetNewLife(int newLife)
    {
        Debug.Log(newLife);
        life -= newLife;
    }
    public void SetNewMaxLife(int newAddLife)
    {
        max_life += newAddLife;
    }
    public void SetNewMaxLifeByPorcentage(int newAddLife)
    {
        max_life += max_life_original * newAddLife;
    }


}

[System.Serializable]
public struct speed
{
    private float Speed;
    public float speedDefault;

    public float speedCurrent
    {
#pragma warning disable IDE0251
        get
        {
            return Speed;
        }
        set
        {
            Speed = value;
        }
    }

    public float getSpeed()
    {
        return speedCurrent;
    }

    public void setDefault() { speedCurrent = speedDefault; }

}

