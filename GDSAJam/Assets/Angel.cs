using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Angel : MonoBehaviour
{
    Rigidbody2D RB;
    public Transform Target;
    private void OnValidate()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.bodyType = RigidbodyType2D.Kinematic;
    }
    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        RB.bodyType = RigidbodyType2D.Kinematic;
    }
    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation
             (Target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        RB.velocity = -(transform.position - Target.position).normalized * (transform.position - Target.position).magnitude;
    }
}
