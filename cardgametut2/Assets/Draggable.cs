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

    private GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;

    private ThisCard ThisCard;

    private void Start()
    {
        Canvas = GameObject.Find("Canvas");
        TurnSystem = GameObject.Find("TurnSystem").GetComponent<TurnSystem>();
        ThisCard = gameObject.GetComponent<ThisCard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        if (!ThisCard.CanBeSummoned() || ThisCard.summoned) return;
        startParent = transform.parent.gameObject;
        startPosition = transform.position;
        isDragging = true;;
    }

    public void EndDrag()
    {
        if (!ThisCard.CanBeSummoned() || ThisCard.summoned) return;
        isDragging = false;
        if (isOverDropZone && TurnSystem.isPlayerTurn)
        {
            transform.SetParent(dropZone.transform, false);
            ThisCard.Summon();
        }
        else  
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }
    }
}
