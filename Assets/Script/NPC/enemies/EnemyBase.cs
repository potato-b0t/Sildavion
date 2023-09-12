using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public Life life;

    public Armor armor;

    public speed speed;
    public void setDamage(int damage, Elements type)
    {
        ElementArmor armorGetted = armor.find(type);


        life.SetNewLife(damage - (damage * armorGetted.armor));

    }
}
