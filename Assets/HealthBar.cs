using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject healthBarItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Setting up health bar");



        // Bar Background
        var barBackground = this.gameObject.transform.Find("HealthBarBackground");
        var backgroundRetangle = barBackground.GetComponent<RectTransform>();

        float currentX = 0;
        for (int i = 0; i < 20; i++)
        {
            // Add Health Bar Item and set size and position
            GameObject healthBarItem = Instantiate(healthBarItemPrefab);

            // Set parent to bar and anchor center to left of parent & location
            healthBarItem.transform.SetParent(barBackground, false);
            var healthBarItemTransform = healthBarItem.GetComponent<RectTransform>();
            healthBarItemTransform.sizeDelta = new Vector2((backgroundRetangle.sizeDelta.x / 20), backgroundRetangle.sizeDelta.y);
            healthBarItemTransform.localScale = new Vector3(0.8f, 0.6f, 1);
            healthBarItemTransform.localPosition = new Vector3(currentX + (healthBarItemTransform.sizeDelta.x / 2), 0, 80);
            healthBarItemTransform.anchorMin = new Vector2(0, 0.5f);
            healthBarItemTransform.anchorMax = new Vector2(0, 0.5f);
            healthBarItemTransform.pivot = new Vector2(0.5f, 0.5f);

            currentX = currentX + healthBarItemTransform.sizeDelta.x;


        }


        // Set location

        //healthBarItem.GetComponent<RectTransform>().sizeDelta = new Vector2(backgroundRetangle.sizeDelta.x/30, backgroundRetangle.sizeDelta.y);
        //healthBarItem.transform.position = this.gameObject.transform.Find("HealthBarBackground").transform.position;
        //healthBarItem.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 80);
        //healthBarItem.GetComponent<RectTransform>().

        //healthBarItem.transform.localScale = new Vector3(0f, -6.2f, 80);

        int blah = 0;



        // Set size of health bar item
        //RectTransform barItemRect = healthBarItem.GetComponent<RectTransform>();
        //barItemRect.sizeDelta = new Vector2(barRect.sizeDelta.x, barRect.sizeDelta.y);

        //Debug.Log("Width " + barSize.sizeDelta.x + " Height " + barSize.sizeDelta.y);
        //Debug.Log("x " + barSize.localPosition.x + " y " + barSize.localPosition.y);



        //healthBarItem.transform.SetParent(this, false);
        //healthBarItem.transform.position = new Vector2(-6, -3);
        //healthBarItem.transform.SetParent(this.transform, true);
        //healthBarItem.transform.position.six

    }

    private void AddHealthBarItem()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
