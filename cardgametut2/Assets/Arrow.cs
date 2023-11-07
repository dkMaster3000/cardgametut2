using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public static GameObject[] points;

    public GameObject point;
    public GameObject arrow;

    public static int numberOfPoints = 30;

    public static Vector2 startPoint;

    public float distance;

    public Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        points = new GameObject[numberOfPoints];

        for (int i = 0; i < numberOfPoints; i++)
        {
            if(i != numberOfPoints - 1)
            {
                points[i] = Instantiate(point, transform.position, Quaternion.identity);
                points[i].SetActive(false);
            } else
            {
                points[i] = Instantiate(arrow, transform.position, Quaternion.identity);
                points[i].SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startPoint != null)
        {
            for (int i = 0; i < numberOfPoints; i++)
            {

                direction = Input.mousePosition;

                points[i].transform.position = Vector2.Lerp(startPoint, direction, i * 0.1f);          

                distance = Vector2.Distance(startPoint, direction);
            }
        }

    }

    public static void Show()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].SetActive(true);
        }
    }

    public static void Hide()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].SetActive(false);
        }
    }

}
