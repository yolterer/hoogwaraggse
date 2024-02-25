using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float damage = 10;
    // Start is called before the first frame update
    private void Start()
    {
        Invoke("DestroyFireball", lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DamageEnemy(collision);        
        DestroyFireball();         
    }
    private void DamageEnemy(Collision collision)
    {
        var EnemyHealf = collision.gameObject.GetComponent<EnemyHealf>();
        if (EnemyHealf != null)
        {
            EnemyHealf.DealDamage(damage);           
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveFireBollUpdate();           
    }
    
    private void MoveFireBollUpdate()
    {
       transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    private void DestroyFireball()
    {
       Destroy(gameObject);
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
