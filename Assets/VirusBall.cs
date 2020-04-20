using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusBall : MonoBehaviour
{
    public static int collisionCount = 0;
    public static int numberOfBalls = 1;

    private float minSpeed = 5; 
    private float maxSpeed = 15;
    private float maxTorque = 100;
    public Rigidbody2D rigidbody2;
    public bool IsVirus;
    public bool IsRandom = false;

    // Start is called before the first frame update

    public enum VirusSpawnMode
    {
        Virus = 0,
        Healthy = 1,
        Random = 2
    }


    void Start()
    {




    }

    public void SpawnCircle(VirusSpawnMode virusSpawnMode)
    {
        this.transform.parent = GameObject.Find("Balls").transform;

        Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.AddTorque(Random.Range(-maxTorque, maxTorque));
        rigidbody.velocity = new Vector2(Random.Range(0f, 1f), Random.Range(0f, 1f)) * Random.Range(minSpeed, maxSpeed);

        int randomNumber = Random.Range(0, 4);

        Material objectMaterial = this.gameObject.GetComponent<Renderer>().material;

        switch (virusSpawnMode)
        {
            case VirusSpawnMode.Healthy:
                objectMaterial.color = Color.green;
                break;
            case VirusSpawnMode.Virus:
                objectMaterial.color = Color.red;
                break;
            case VirusSpawnMode.Random:
                IsVirus = (randomNumber == 1) ? true : false;
                objectMaterial.color = (IsVirus) ? Color.red : Color.green;
                break;

        }


        VirusBallManager.AddBall(this);

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Material material = this.gameObject.GetComponent<Renderer>().material;

        if (material.color == Color.red)
        {
            material.color = Color.green;

            VirusBallManager.HealBall();
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Material objectMaterial = this.gameObject.GetComponent<Renderer>().material;
        Material collidedObjectMaterial = col.gameObject.GetComponent<Renderer>().material;

        if ((objectMaterial.color == Color.green) 
            && (collidedObjectMaterial.color == Color.red))
        {
            objectMaterial.color = Color.red;

            VirusBallManager.InfectBall();
        }

        
    }
}
