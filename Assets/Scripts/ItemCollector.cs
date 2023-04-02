using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    uint count_melons = 0;

    [SerializeField] private Text melonsCount;
    [SerializeField] private AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            count_melons++;
            melonsCount.text = $"Watermelons{count_melons}";
        }
    }
}
