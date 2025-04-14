using UnityEngine;

public class SampleF : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Only notify Level F's collector
            SampleCollectorForLevelF collector = FindObjectOfType<SampleCollectorForLevelF>();
            if (collector != null)
            {
                collector.CollectSample();
            }
            // Don't call any other collectors
            Destroy(gameObject);
        }
    }
}