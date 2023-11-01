using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class Draggable : MonoBehaviour
{
    public GameObject Canvas;
    public TurnSystem TurnSystem;

    private bool isDragging = false;
    private bool isOverDropZone = false;
    private bool isDraggable = true;


    private GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y - 800);
            transform.SetParent(Canvas.transform, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Enter");
        isOverDropZone = true;
            Debug.Log(collision.gameObject);
            dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Exit");
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        Debug.Log("Start StartDrag");
        if (!isDraggable) return;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;
        Debug.Log("End StartDrag");
    }

    public void EndDrag()
    {
        Debug.Log("Start EndDrag");
        if (!isDraggable) return;
        isDragging = false;
        if (isOverDropZone && TurnSystem.isYourTurn)
        {
            Debug.Log(dropZone);
            Debug.Log(dropZone.transform);
            transform.SetParent(dropZone.transform, false);
            isDraggable = false;
            //PlayerManager.PlayCard(gameObject);
            Debug.Log("OverDropZone");
            Debug.Log(transform);
            Debug.Log(transform.parent);
            Debug.Log(transform.parent.name);
        }
        else  
        {
            Debug.Log("in else");
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }

        Debug.Log("End EndDrag");
    }
}
