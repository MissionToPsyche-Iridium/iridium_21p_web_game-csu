using System.Collections;
using System.Collections.Generic;
// SampleCollector.cs
using UnityEngine;

public class SampleCollector : MonoBehaviour
{
    public int collectedSamples = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sample"))
        {
            collectedSamples++;
            Destroy(other.gameObject);
            Debug.Log("Collected Samples: " + collectedSamples);
        }
    }
}
