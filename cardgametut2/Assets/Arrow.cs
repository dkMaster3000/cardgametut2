using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;

    public static GameObject[] points;

    public GameObject point;
    public GameObject arrow;

    public static int numberOfPoints = 15;

    public static Vector3 startPoint;

    public Vector3 direction;
    public static Vector3 AITarget;

    /*
     * right now it is just hidden and shown
     * in future it is better to instatiate it when in use    
     */

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

     if (TurnSystem.isPlayerTurn)
        {
            zAngle = (startPoint.x - Input.mousePosition.x) / 10;
            direction = Input.mousePosition;
        }
        else
        {
            zAngle = (-(startPoint.x - Input.mousePosition.x) / 10) + 180;
            direction = AITarget;
        }

        for (int i = 0; i < numberOfPoints; i++)
        {

            points[i].transform.position = Vector3.Slerp(startPoint, direction, i * 0.1f);
        }
        points[numberOfPoints - 1].transform.rotation = Quaternion.Euler(new Vector3(0, 0, zAngle));

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
