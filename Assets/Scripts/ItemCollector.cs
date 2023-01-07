using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector : MonoBehaviour
{

    private int boxes = 0;

    [SerializeField] private TextMeshProUGUI boxesText;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.CompareTag("Box"))
        {
            collectionSoundEffect.Play();
            Destroy(collsion.gameObject);
            boxes++;
            boxesText.text = "Boxes: " + boxes;
        }
    }
}
