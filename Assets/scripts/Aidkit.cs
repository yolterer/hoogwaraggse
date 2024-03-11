using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float healAmount = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        var PlayerHelth = other.gameObject.GetComponent<PlayerHelth>();
        if(PlayerHelth != null)
        {
            PlayerHelth.AddHealth(healAmount);
            Destroy(gameObject);
        }
                
    }
}
