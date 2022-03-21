using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TourManager : MonoBehaviour
{
    [SerializeField] private SongInfo[] informationList;
    [SerializeField] private AudioSource soundPlayer;
    private int currSong;

    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI producers;
    [SerializeField] private TextMeshProUGUI artists;
    [SerializeField] private TextMeshProUGUI BGM;

    void Start()
    {
        title.text = informationList[0].GetName();
        producers.text = informationList[0].GetProd();
        artists.text = informationList[0].GetSinger();
        BGM.text = "" + informationList[0].GetBGM();
        soundPlayer.clip = informationList[0].GetSong();
        soundPlayer.Play();
    }


    public void ChangeMusic(int songNum)
    {
        if (currSong != songNum)
        {
            soundPlayer.clip = informationList[songNum].GetSong();
            title.text = informationList[songNum].GetName();
            producers.text = informationList[songNum].GetProd();
            artists.text = informationList[songNum].GetSinger();
            BGM.text = "" + informationList[songNum].GetBGM();
            soundPlayer.Play();
            currSong = songNum;
        }
    }

    public void PlaySong(int songNum)
    {
        GameMaster.GM.currentSong = informationList[songNum];
        SceneManager.LoadScene("Test");
    }
}
