using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x,transform.rotation.y,360f * speed * Time.deltaTime));
    }
}
