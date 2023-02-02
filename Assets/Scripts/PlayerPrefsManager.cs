using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static PlayerPrefsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
    }

    public bool IsLevelOpened(Level levelName)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(levelName.ToString(), 0));
    }

    public void SetLevelOpen(Level levelName)
    {
        if (!IsLevelOpened(levelName))
        {
            PlayerPrefs.SetInt(levelName.ToString(), 1);
            PlayerPrefs.Save();
        }
    }

    public bool IsItemCollected(string itemName)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(itemName, 0));
    }

    public void CollectItem(string itemName)
    {
        if (!IsItemCollected(itemName))
        {
            PlayerPrefs.SetInt(itemName, 1);
            PlayerPrefs.Save();
        }
    }
}