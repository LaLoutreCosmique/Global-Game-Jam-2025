using System;
using System.Collections;
using UnityEngine;

public class EndScreenScript : MonoBehaviour
{
    [SerializeField] private Canvas canvasButton;
    [SerializeField] private Canvas gameWinCanvas;
    [SerializeField] private Canvas gameLoseCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvasButton.gameObject.SetActive(false);
        gameWinCanvas.gameObject.SetActive(false);
        gameLoseCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasButton.gameObject.SetActive(true);
            gameWinCanvas.gameObject.SetActive(true);
        }
    }

    public void LoseScreen()
    {
        StartCoroutine(losing());
    }

    IEnumerator losing()
    {
        yield return new WaitForSeconds(1f);

        canvasButton.gameObject.SetActive(true);
        gameLoseCanvas.gameObject.SetActive(true);
    }
}
