using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI boxesText;

    [SerializeField] private List<GameObject> collectibles;

    [SerializeField] private AudioSource collectionSoundEffect;

    private string sceneName;
    private int colectedItems = 0;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        collectibles.ForEach(c =>
        {
            if (PlayerPrefsManager.Instance.IsItemCollected(sceneName + c.name))
            {
                c.SetActive(false);
                colectedItems++;
            }
        });

        SetBoxesText();
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.gameObject.CompareTag("Box"))
        {
            PlayerPrefsManager.Instance.CollectItem(sceneName + collsion.gameObject.name);
            collectionSoundEffect.Play();
            Destroy(collsion.gameObject);
            colectedItems++;
            SetBoxesText();
        }
    }

    private void SetBoxesText()
    {
        boxesText.text = $"Boxes: {colectedItems}/{collectibles.Count}";
    }
}