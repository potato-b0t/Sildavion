using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


[CreateAssetMenu(fileName = "Player", menuName = "Create/Custom Asset/Player")]
public class Player : ScriptableObject
{

    #region Main Players Feactures
    [Header("Main Player")]
    public Life life;

    public Armor armor;

    public speed speed;

    public float damageValue;

    public Damage damage = new Damage();

#pragma warning disable IDE1006

    [System.Serializable]
    public delegate void Damages(List<EnemyBase> enemies);

    public Damages damages;

    [System.Serializable]
    public delegate void Passives();
    public Passives passives;

    #endregion

    #region Second Players Feactures

    [Header("Second Player")]

    public Life secondPlayer;

    #endregion

    #region General

    public void DamageDefault(List<EnemyBase> enemies)

    {
        Debug.Log("yes");
        enemies.ForEach(enemy =>
        {
            enemy.setDamage((int)Mathf.Round((damage.damage + damage.increment) * 0.25f), damage.elementsDefault);
            Debug.Log(enemy.transform.name);
        });
    }

    public void setDamage(int damage, Elements type)
    {
        ElementArmor armorGetted = armor.find(type);


        life.SetNewLife(damage - (damage * armorGetted.armor));

        Debug.Log(life.LifeValue + " " + damage);
    }

    #endregion

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

[System.Serializable]
public struct Damage
{
    public float damage;
    public float increment;
    public Elements elementsDefault;

    public Damage(float damage, Elements elements, float increment = 0)
    {
        this.damage = damage;
        this.elementsDefault = elements;
        this.increment = increment;
    }
}
