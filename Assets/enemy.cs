using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public List<GameObject> enemyslist;
    public List<Transform> pointslist;

    private void Start()
    {
       // GameObject newenemy = Instantiate(enemyslist[0], pointslist[0].position, Quaternion.identity);
    }
}
