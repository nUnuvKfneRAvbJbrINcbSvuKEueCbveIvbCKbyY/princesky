using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dressing : MonoBehaviour
{
    [SerializeField] private List<GameObject> dresses;

    // Start is called before the first frame update
    void Start()
    {

        Object[] dressObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        foreach (Object obj in dressObjects)
        {
            GameObject dressObject = (GameObject)obj;
            if (dressObject.tag == "dress" && !dressObject.activeSelf)
            {
                dresses.Add(dressObject);
            }
        }

        for (int i = 0; i < dresses.Count; i++)
        {
            Debug.Log(dresses[i].name + " " + i);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

}
