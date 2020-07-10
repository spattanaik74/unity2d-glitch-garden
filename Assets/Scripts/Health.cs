using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DamageDeal(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DeathVFX();
            Destroy(gameObject);
        }
    }
    private void DeathVFX()
    {
        if (!deathVFX) { return ; }
        GameObject deathVFXobject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXobject, 1f);
    }
    
       
   

}
