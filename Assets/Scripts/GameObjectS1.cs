using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectS1 : MonoBehaviour
{
    // Start is called before the first frame update

    public void ToggleGameObject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
