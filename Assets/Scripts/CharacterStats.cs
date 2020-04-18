using UnityEngine;

public class CharaterStats : MonoBehaviour
{
    protected int currentHealth;
    protected int maxHealth;

    protected int currentStamina;
    protected int maxStamina;

    protected bool isDead = false;

    public int GetHealth()
    {
        return currentHealth;
    }

    public void SetHealth(int currentDamage)
    {
        currentHealth -= currentDamage;
        CheckHealth();
    }

    public int GetStamina()
    {
        return currentStamina;
    }

    public void SetStamina()
    {
        //currentStamina -= ; TODO
    }

    public void CheckHealth()
    {
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }

    public void CheckStamina()
    {
        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        else if (currentStamina <= 0)
        {
            currentStamina = 0;
        }
    }

    public virtual void Die()
    {
        //Override.
    }
}
