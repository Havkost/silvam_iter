using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbCollection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        showCollected.collectedOrbs += 1;
        Destroy(gameObject);
    }
}