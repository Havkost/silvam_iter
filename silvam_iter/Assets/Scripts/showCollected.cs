using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showCollected : MonoBehaviour
{
    public GameObject orbText;
    public static int collectedOrbs;

    private void Update()
    {
        orbText.GetComponent<Text>().text = "Orbs: " + collectedOrbs;
    }
}
