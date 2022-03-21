using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Responsible for updating the screen according to the menu item, the player chooses.
public class MainMenu : MonoBehaviour
{
    // Menu items.
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject play;
    [SerializeField] private GameObject manage;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject backgroundMusic;
    private GameObject currentItem;

    private void Start()
    {
        currentItem = home;
    }

    public void Toggler(GameObject curr)
    {
        if (!currentItem.Equals(curr))
        {
            currentItem.SetActive(false);
            currentItem = curr;
            currentItem.SetActive(true);
        }
    }

    public void HomeOn()
    {
        backgroundMusic.SetActive(true);
        this.Toggler(home);
    }

    public void PlayOn()
    {
        backgroundMusic.SetActive(false);
        this.Toggler(play);
    }

    public void ManageOn()
    {
        this.Toggler(manage);
    }

    public void SettingsOn()
    {
        this.Toggler(settings);
    }
}
