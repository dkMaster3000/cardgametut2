using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public GameObject canvas;
    public bool isArrow;

    void Start()
    {
        canvas = GameObject.Find("Canvas");

        transform.SetParent(canvas.transform);
        transform.localScale = Vector3.one;
    }
}
