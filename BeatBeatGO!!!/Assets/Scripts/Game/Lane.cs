using Melanchall.DryWetMidi.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    // Restricts notes to certain key.
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();         // time stamps of every note.
    [SerializeField] GameManager gameManager;

    int spawnIndex = 0;
    int inputIndex = 0;

    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach(var note in array)
        {
            if (note.NoteName == noteRestriction)
            {
                // COnvert midi time to real time.
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                // Convert minute to seconds then add to time stamps.
                timeStamps.Add((double)metricTimeSpan.Minutes * 60 + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f); 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Spawn notes.
        if (spawnIndex < timeStamps.Count)
        {
            // Ensure note spawns after x times after player taps.
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.instance.noteTime)
            {
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());
                note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;       // next note.
            }
        }

        if (inputIndex < timeStamps.Count)
        {
            double timeStamp = timeStamps[inputIndex];
            double marginOfError = SongManager.instance.marginOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.instance.inputDelayInMilliseconds / 1000.0);

            if (Input.GetKeyDown(input))
            {
                // Player hit the note.
                if (System.Math.Abs(audioTime - timeStamp) < marginOfError)
                {
                    Hit();
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else  // miss
                {
                    print($"Miss {inputIndex}");
                }
            }

            if (timeStamp + marginOfError <= audioTime) // Miss (passed)
            {
                Miss();
                inputIndex++;
            }
        }
    }

    private void Hit()
    {
        gameManager.SetHealth(1f);
        ScoreManager.Hit();
    }

    private void Miss()
    {
        gameManager.SetHealth(-12.5f);
        ScoreManager.Miss();
    }
}
