using UnityEngine;

public class Sample : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<SampleCollector>().CollectSample();
            Destroy(gameObject);
        }
    }
}
