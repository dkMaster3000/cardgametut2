using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToPosition(GameObject card, GameObject position)
    {
        //Debug.Log(position + " : " + position.name + " : " + position.transform);
        card.transform.SetParent(position.transform);
        card.transform.localScale = Vector3.one;
        card.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        card.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
