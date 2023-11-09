using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene : MonoBehaviour
{
    public void CloseScene()
    {
        Application.Quit();
    }

    public void StartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
