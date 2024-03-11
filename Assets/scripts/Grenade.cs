using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
        StartCoroutine(ExplosionCoroutine());
    }

   
    private IEnumerator ExplosionCoroutine()
    {
       
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
        var Explosion = Instantiate(explosionPrefab);
        Explosion.transform.position = transform.position;
    }
}
