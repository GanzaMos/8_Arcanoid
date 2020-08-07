using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColliderScript : MonoBehaviour
{
    private GameObject loseMenu;

    private void Awake()
    {
        loseMenu = FindObjectOfType<LoseMenuIdentifier>(true).gameObject;
        loseMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
