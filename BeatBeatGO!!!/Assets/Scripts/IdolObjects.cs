using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Idols", menuName = "Idols/Create new Idol")]
public class IdolObjects : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private string agency;
    [SerializeField] private string birthInfo;
    [SerializeField] private string personality;
    [SerializeField] private string hobbies;
    [SerializeField] private string dateHired;
    [SerializeField] private List<Image> costumes;
}
