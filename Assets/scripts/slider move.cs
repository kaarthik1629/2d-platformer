using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidermove : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);

        }
          gameObject.SetActive(false);
    }

}
