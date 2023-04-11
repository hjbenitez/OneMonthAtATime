using Fungus;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    GameManager gameManager;
    public GameObject blocker;
    public Flowchart menuFC;
    public GameObject optionsConfirmation;

    public GameObject dialogue;
    Text textExample;
    WriterAudio volumeExample;
    Writer writerExample;

    public AudioSource musicExample;
    bool startedMusic = false;

    int textSize;
    int textSpeed;

    public Slider textSizeSlider;
    public Slider textSpeedSlider;
    public Slider textVolumeSlider;
    public Slider musicVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;

        textExample = dialogue.GetComponentInChildren<Text>();
        volumeExample = dialogue.GetComponent<WriterAudio>();
        writerExample = dialogue.GetComponent<Writer>();
        musicExample = GetComponent<AudioSource>();

        textSize = (int)textSizeSlider.value;
        textSpeed = (int)textSpeedSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(musicExample.isPlaying);

        if (menuFC.GetIntegerVariable("block") == 1)
        {
            if (!startedMusic)
            {
                musicExample.Play();
                startedMusic = true;
            }

            textExample.fontSize = (int)textSizeSlider.value + gameManager.GetFontSize();
            writerExample.writingSpeed = ((int)textSpeedSlider.value * 10) + gameManager.GetWritingSpeed();
            volumeExample.volume = (float)textVolumeSlider.value / 10f;
            musicExample.volume = (float)musicVolumeSlider.value / 10f;
        }

        else
        {
            musicExample.Stop();
            startedMusic = false;
        }
    }

    private void LateUpdate()
    {
        /*
        if (musicExample == null)
        {
            try
            {
                musicExample = GameObject.Find("FungusManager").GetComponent<AudioSource>();
            }
            catch { Debug.Log("Could not find"); }
        }
        */
    }

    public void StartBlock()
    {
        menuFC.ExecuteBlock("Start");
        menuFC.StopBlock("Options");
    }
    public void StartGame()
    {
        menuFC.ExecuteBlock("Start Game");
        menuFC.StopBlock("Options");
    }

    public void Options()
    {
        menuFC.ExecuteBlock("Options");
    }

    public void Credits()
    {
        menuFC.ExecuteBlock("Credits");
        menuFC.StopBlock("Options");
    }
    public void Quit()
    {
        menuFC.ExecuteBlock("Quit");
        menuFC.StopBlock("Options");
    }

    public void Cancel()
    {

        if (textSizeSlider.value != textSize ||
            textSpeedSlider.value != textSpeed ||
            textVolumeSlider.value != gameManager.GetVolume() ||
            musicVolumeSlider.value != gameManager.GetMusicVolume())
        {
            optionsConfirmation.SetActive(true);
            blocker.SetActive(true);
        }

        else
        {
            CancelChanges();
        }
    }

    public void ApplyChanges()
    {
        gameManager.SetOptions(
            (int)textSizeSlider.value + gameManager.GetFontSize(),
            ((int)textSpeedSlider.value * 10) + gameManager.GetWritingSpeed(),
            (int)textVolumeSlider.value,
            (int)musicVolumeSlider.value);

        textSize = (int)textSizeSlider.value;
        textSpeed = (int)textSpeedSlider.value;

        optionsConfirmation.SetActive(false);
        blocker.SetActive(false);

        menuFC.ExecuteBlock("Start");
        menuFC.StopBlock("Options");
    }

    public void CancelChanges()
    {
        menuFC.ExecuteBlock("Start");
        menuFC.StopBlock("Options");

        optionsConfirmation.SetActive(false);
        blocker.SetActive(false);

        textSizeSlider.value = textSize;
        textSpeedSlider.value = textSpeed;
        textVolumeSlider.value = gameManager.GetVolume();
        musicVolumeSlider.value = gameManager.GetMusicVolume();
    }

}
