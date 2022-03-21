using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Randomizer : MonoBehaviour
{
    [SerializeField] private Sprite[] imageBank;
    private Image source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<Image>();
        this.GetRandomImage();
    }

    void GetRandomImage()
    {
        int temp = Random.Range(0, 11);
        Debug.Log(temp);
        source.sprite = imageBank[temp];
    }
}
