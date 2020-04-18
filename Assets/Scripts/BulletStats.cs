using UnityEngine;

public class BulletStats : MonoBehaviour
{
    private const int maxDamage = 45;
    private const int minDamage = 5;
    private int currentDamage;

    public int GetDamage()
    {
        return currentDamage;
    }

    public void SetDamage(int currentHealth)
    {
        currentDamage = (1 - currentHealth / 100) * 100;
        CheckDamage();
    }

    private void CheckDamage()
    {
        if (currentDamage < minDamage)
        {
            currentDamage = minDamage;
        }
        else if (currentDamage >= maxDamage)
        {
            currentDamage = maxDamage;
        }
    }
}