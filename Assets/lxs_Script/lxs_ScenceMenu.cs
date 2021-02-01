using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lxs_ScenceMenu : MonoBehaviour {

    // Use this for initialization
    public AudioSource asound;
    public Slider sli;
    bool isStop = true;
    public GameObject Option;

    public void Start()
    {
        sli.value = asound.volume;
    }

    public void Update()
    {
        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                Option.SetActive(true);
            }
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                isStop = true;
                Option.SetActive(false);
            }
        }




    }

    public void ReblackGame()
    {
        Time.timeScale = 1;
        isStop = true;
        Option.SetActive(false);
    }

    public void ReblackMenu()
    {
        SceneManager.LoadScene(0);

        Time.timeScale = 1;
        isStop = true;
        Option.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void VolumMundic()
    {

        asound.volume = sli.value;
    }

}
