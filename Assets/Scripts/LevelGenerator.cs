using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int numberOfPanels = 10;
    [SerializeField] private List<GameObject> panels = new();
    private List<GameObject> currentPanels = new();

    private void Start()
    {
        SelectPanels();
    }

    public void SelectPanels()
    {
        var lastrand = 180;
        for (int i = 0; i < numberOfPanels; i++)
        {
            var random = Random.Range(0, panels.Count);
            if (random == lastrand)
                i--;
            else
            {
                lastrand = random;
                currentPanels.Add(panels[random]);

                Debug.Log(("added" + panels[random].name));
            }
        }
        Debug.Log("Level created with " + numberOfPanels + "panels");
        InstantiatePanels();
    }

    private void InstantiatePanels()
    {
        Vector3 pos = new Vector3(0, 10, 0);
        foreach (var panel in currentPanels)
        {
            Instantiate(panel, pos, Quaternion.identity);
            pos.y +=13;
            Debug.Log(pos.y);
        }
    }
}
