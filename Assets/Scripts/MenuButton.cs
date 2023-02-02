using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Level levelName;

    [SerializeField] private Sprite playableImage;

    [SerializeField] private Sprite notPlayableImage;

    [SerializeField] private Color playableColor;

    [SerializeField] private Color notPlayableColor;

    private Image imageRenderer;

    private Button menuButton;

    private void Start()
    {
        imageRenderer = transform.GetChild(0).GetComponent<Image>();
        menuButton = GetComponent<Button>();

        Inactivate();

        if (levelName.Equals(Level.Level1) || PlayerPrefsManager.Instance.IsLevelOpened(levelName))
        {
            menuButton.interactable = true;
            imageRenderer.sprite = playableImage;
            imageRenderer.color = playableColor;
        }
    }

    public void Inactivate()
    {
        if (!levelName.Equals(Level.Level1))
        {
            menuButton.interactable = false;
            imageRenderer.sprite = notPlayableImage;
            imageRenderer.color = notPlayableColor;
        }
    }

    public void StartLevel()
    {
        SceneManager.LoadScene(levelName.ToString());
    }
}