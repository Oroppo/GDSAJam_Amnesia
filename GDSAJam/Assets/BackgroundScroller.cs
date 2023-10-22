using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    public Transform startPoint;
    public Transform EndPoint;

    // Start is called before the first frame update
    void Start()
    {
        moveDirection.y = -0.002f;   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection);
        if(transform.position.y <= EndPoint.transform.position.y)
        {
            gameObject.transform.position = startPoint.transform.position;
        }
    }
}
