using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayerController : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletStats bulletStats = collision.gameObject.GetComponent<BulletStats>();
            int damage = bulletStats.GetDamage();

            PlayerStats playerStats = gameObject.GetComponent<PlayerStats>();
            playerStats.SetHealth(damage);
        }

        /*if (collision.gameObject.CompareTag("SimpleSword")) 
        {
            TODOOOOO        

            int damage = collision.gameObject.GetComponent<SimpleSwordStats>().GetDamage();
            gameObject.GetComponent<PlayerStats>().SetHealth(damage);
        } */
    }
}
