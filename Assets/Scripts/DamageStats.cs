using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageStats : MonoBehaviour
{
    protected int maxDamage;
    protected int minDamage;
    protected int currentDamage;

    public int GetDamage()
    {
        return currentDamage;
    }

    public void SetDamage(int currentHealth)
    {
        currentDamage = (1 - currentHealth / 100) * 100;
        CheckDamage();
        Debug.Log(currentDamage);

    }

    private void CheckDamage()
    {
        Debug.Log("minDamage : " + minDamage);

        if (currentDamage < minDamage)
        {
            currentDamage = minDamage;
            Debug.Log(true);

        }
        else if (currentDamage >= maxDamage)
        {
            currentDamage = maxDamage;
        }
    }
}
