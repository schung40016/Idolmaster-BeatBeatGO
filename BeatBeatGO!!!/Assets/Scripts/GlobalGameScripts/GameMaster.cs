using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Video;
// Uses singleton design to 
public class GameMaster : MonoBehaviour
{
    public static GameMaster GM;

    // Data needed to be saved here.
    public int playerLevel = 0;
    public int budget = 0;
    public SongInfo currentSong;
    public float currVolume;
    public float currShader;
    public List<IdolObjects> idols;

    private void Awake()
    {
        if (GM != null)
        {
            Debug.Log(currentSong.name + " destroyed.");
            GameObject.Destroy(GM);
        }
        else
        {
            GM = this;
        }
       
        DontDestroyOnLoad(this);
    }
}
