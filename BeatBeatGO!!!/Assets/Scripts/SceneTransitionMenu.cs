using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionMenu : MonoBehaviour
{
    
    public void Transition()
    {
        Invoke("SceneLoad", 1f);
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
