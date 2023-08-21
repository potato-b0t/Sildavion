using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Armor
{
    public ElementArmor[] magicArmor;

    public ElementArmor find(Elements type)
    {
        for (int i = 0; i < magicArmor.Length; i++)
        {
            if (magicArmor[i].name == type)
            {
                Debug.Log("finded");
                return magicArmor[i];
            }
        }
        return new ElementArmor(Elements.physics, 0);
    }

}

[System.Serializable]
public struct ElementArmor
{
    public Elements name;

    [Range(0, 1)]
    public int armor;

    public ElementArmor(Elements element, int armorFloat)
    {
        this.name = element;
        this.armor = armorFloat;
    }
}
