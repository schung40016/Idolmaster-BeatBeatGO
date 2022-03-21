using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;
    public float assignedTime;
    public float horizontalShift = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.instance.noteTime * 2));

        GetComponent<SpriteRenderer>().enabled = true;

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localScale += new Vector3(.4f, .4f, 0) * Time.deltaTime;

            // Lerp(Start pos, End pos, duration)
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.instance.noteSpawnY, new Vector3(horizontalShift, SongManager.instance.noteDespawnY, 0), t);
        }
    }
}
