using UnityEngine;

public class Sample : MonoBehaviour
{
    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return; // already collected
        if (other.CompareTag("Player"))
        {
            collected = true; // prevent further triggers
            FindObjectOfType<SampleCollector>().CollectSample();
            Destroy(gameObject);
        }
    }
}
