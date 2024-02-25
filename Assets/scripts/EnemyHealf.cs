using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealf : MonoBehaviour
{
    public static float value = 100;
    public static float damage = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public  void DealDamage(float damageToDeal)
    {
        EnemyHealf.value -= damage;
           if (EnemyHealf.value <= 0)
           {
               Destroy(gameObject);
           }
    }
}
