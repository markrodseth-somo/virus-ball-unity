using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployCircles : MonoBehaviour
{
    public GameObject circlePrefab;
    public GameObject wallPrefab; 
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;
    RectTransform canvas;

    // Start is called before the first frame update
    void Start()
    {
        VirusBallManager.Initialise();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        Debug.Log("Screen width " + Screen.width + " Screen Height " + Screen.height); // Width in pixels
        Debug.Log("ScreenBounds x " + screenBounds.x + " ScreenBounds y " + screenBounds.y); // 

        var cam = Camera.main;
        var bottomLeft = cam.ViewportToWorldPoint(new Vector3(0.5f, 0, cam.nearClipPlane));
        var bottomRight = cam.ViewportToWorldPoint(new Vector3(1, 0, cam.nearClipPlane));
        var topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
        var topLeft = cam.ViewportToWorldPoint(new Vector3(0.5f, 1, cam.nearClipPlane));

        // Width
        var wallWidth = topRight.x / 50;

        // Add top wall
        GameObject wall = Instantiate(wallPrefab) as GameObject;
        wall.transform.position = topLeft;
        wall.transform.localScale = new Vector3(topRight.x, wallWidth, wall.transform.localScale.z);

        // Add bottom wall
        wall = Instantiate(wallPrefab) as GameObject;
        wall.transform.position = bottomLeft;
        wall.transform.localScale = new Vector3(topRight.x, wallWidth, wall.transform.localScale.z);

        // Add left wall
        wall = Instantiate(wallPrefab) as GameObject;
        wall.transform.localScale = new Vector3(wallWidth, topRight.y, wall.transform.localScale.z);
        wall.transform.position = cam.ViewportToWorldPoint(new Vector3(0, 0.5f, cam.nearClipPlane));

        // Add right wall
        wall = Instantiate(wallPrefab) as GameObject;
        wall.transform.localScale = new Vector3(wallWidth, topRight.y, wall.transform.localScale.z);
        wall.transform.position = cam.ViewportToWorldPoint(new Vector3(1, 0.5f, cam.nearClipPlane));

        // Spawn first healthy viruas
        GameObject a = Instantiate(circlePrefab) as GameObject;
        var virusBall = a.GetComponent<VirusBall>();
        virusBall.SpawnCircle(VirusBall.VirusSpawnMode.Healthy);
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));


        VirusBallManager.CurrentGameStatus = VirusBallManager.GameStatus.Started;



        StartCoroutine(VirusWave());

       

    }

    private void SpawnVirus()
    {
        GameObject a = Instantiate(circlePrefab) as GameObject;
        var virusBall = a.GetComponent<VirusBall>();
        virusBall.SpawnCircle(VirusBall.VirusSpawnMode.Random);
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));

    }


    IEnumerator VirusWave()
    {
        while (VirusBallManager.CurrentGameStatus == VirusBallManager.GameStatus.Started)
        {
            yield return new WaitForSeconds(respawnTime);

            if (VirusBallManager.CurrentGameStatus == VirusBallManager.GameStatus.Started)
            {
                SpawnVirus();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
     

    }
}
