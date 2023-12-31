using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallableDestroyScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fallable"))
        {
            Destroy(collision.gameObject);
        }
    }
}
