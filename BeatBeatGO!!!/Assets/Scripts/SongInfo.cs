using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "SongInfo", menuName = "SongInfo/Create new SongInfo")]

public class SongInfo : ScriptableObject
{
    [SerializeField] string songName;
    [SerializeField] string producedBy;
    [SerializeField] string singer;
    [SerializeField] int BGM;
    [SerializeField] string credits;
    [SerializeField] VideoClip videoClip;
    [SerializeField] string wavMap;
    [SerializeField] AudioClip songClip;
    [SerializeField] AudioClip fullSong;

    public VideoClip GetVideo()
    {
        return videoClip;
    }

    public AudioClip GetFullSong()
    {
        return fullSong;
    }

    public AudioClip GetSong()
    {
        return songClip;
    }

    public string GetName()
    {
        return songName;
    }

    public string GetProd()
    {
        return producedBy;
    }

    public string GetSinger()
    {
        return singer;
    }

    public int GetBGM()
    {
        return BGM;
    }

    public string GetWav()
    {
        return wavMap;
    }
}
