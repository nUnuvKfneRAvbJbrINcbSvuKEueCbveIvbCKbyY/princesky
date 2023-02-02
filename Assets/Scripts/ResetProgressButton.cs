using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class ResetProgressButton : MonoBehaviour
{
    [SerializeField] private List<MenuButton> menuButtons;

    public void ResetProgress()
    {
        menuButtons.ForEach(mb => mb.Inactivate());
        PlayerPrefsManager.Instance.ResetProgress();
    }
}