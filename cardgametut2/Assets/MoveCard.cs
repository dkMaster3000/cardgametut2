using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
        card.transform.SetParent(position.transform);
        card.transform.localScale = Vector3.one;
        card.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        card.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
