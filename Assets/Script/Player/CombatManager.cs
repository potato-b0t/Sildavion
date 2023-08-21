using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager instance;

    public bool canReceiveInput;
    public bool inputReceived;
    public bool noMove;
    private void Awake()
    {
        instance = this;
    }
    public void Attack()
    {
        if (canReceiveInput)
        {
            inputReceived = true;
            canReceiveInput = false;
        }
        else
        {
            return;
        }
    }
    public void inputManager()
    {
        if (!canReceiveInput)
        {
            canReceiveInput = false;
        }
        else
        {
            canReceiveInput = true;
        }
    }
}
