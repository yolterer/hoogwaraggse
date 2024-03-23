using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairbollController : MonoBehaviour
{
    public float damage = 10;

    public fireball fireballPrefabe;
    public Transform fireballSourceTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           var fireball = Instantiate(fireballPrefabe, fireballSourceTransform.position,fireballSourceTransform.rotation);
           fireball.damage = damage;
        }
        
    }
}
