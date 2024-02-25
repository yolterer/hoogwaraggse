using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centre : MonoBehaviour
{
    public Transform Point1;
    public Transform point2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector3.Lerp(Point1.position, point2.position, 0.5f);
    }
}
