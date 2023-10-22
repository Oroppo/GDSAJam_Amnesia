using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class AngelTarget : MonoBehaviour
{
    Rigidbody2D RB;
    private Vector2 InitPos;
    public float SwayDistance=0.25f, SwaySpeed=5f,SwayDir=1;
    bool reversable = true;
    // Start is called before the first frame update
    private void Awake()
    {
       
        RB = GetComponent<Rigidbody2D>();
        RB.bodyType = RigidbodyType2D.Kinematic;
        InitPos = RB.position;
    }
    private void OnValidate()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.bodyType = RigidbodyType2D.Kinematic;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        RB.velocity = new Vector2(SwaySpeed*SwayDir, 1.5f);

        if (Mathf.Abs(RB.position.x - InitPos.x) > SwayDistance&&reversable)
        {
            SwayDir *= -1;
            reversable = false;
            Invoke(nameof(ResetReverse), 0.5f);
        }
          
    }
    public void ResetReverse()
    {
        reversable = true;
    }
}
