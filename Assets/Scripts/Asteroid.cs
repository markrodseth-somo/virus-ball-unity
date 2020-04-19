using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public float maxThrust;
    public float maxTorque;
    public Rigidbody2D rigidbody2;


    // Start is called before the first frame update
    void Start()
    {

        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rigidbody2.AddForce(thrust);
        rigidbody2.AddTorque(torque);
        
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
