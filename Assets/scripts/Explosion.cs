using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float MaxSize = 5;
    public float speed = 1;
    public float damage = 50;
    // Start is called before the first frame update
    void Start()
    {
      transform.localScale = Vector3.zero;        
    }

    // Update is called once per frame
    void Update()
    {   
       transform.localScale += Vector3.one * Time.deltaTime * speed;
       if(transform.localScale.x > MaxSize)
       {
          Destroy(gameObject);
       } 
    }
    private void OnTriggerEnter(Collider other)
    {
        var PlayerHelth = other.GetComponent<PlayerHelth>();
        if (PlayerHelth != null)
        {
            PlayerHelth.DealDamage(damage);
        }

        var EnemyHealf = other.GetComponent<EnemyHealf>();
        if (EnemyHealf != null)
        {
            EnemyHealf.DealDamage(damage);            
        }

    }
}
