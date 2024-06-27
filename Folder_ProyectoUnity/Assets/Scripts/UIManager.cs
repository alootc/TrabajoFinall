using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public SaveVolume save_volume;
    public GameObject popup_audio_settings;

    [SerializeField] private TextMeshProUGUI cronometro;

    [SerializeField] private GameObject go_Result;
    [SerializeField] private TextMeshProUGUI txt_Result;
    [SerializeField] private TextMeshProUGUI txt_TimerFinal;


    private float timerElapsed;

    private int minutes, seconds;

    private void Start()
    {
        Player3D.onGameOver += SetResultUi;
    }

    private void OnDestroy()
    {
        Player3D.onGameOver -= SetResultUi;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            bool active = popup_audio_settings.activeSelf;
            popup_audio_settings.SetActive(!active);


            timerElapsed += Time.deltaTime;

            minutes = (int)(timerElapsed / 60f);
            seconds = (int)(timerElapsed - minutes * 60f);

            string txt_timer = string.Format("{0:00} : {1:00}", minutes, seconds);
            cronometro.text = txt_timer;
        }


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene("Nivel-2");
        //}
    }

    public void SetResultUi(bool result)
    {
        go_Result.SetActive(true);

        txt_Result.text = result ? "GANASTE" : "PERDISTE";
        txt_TimerFinal.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddVolume(string id)
    {
        switch (id)
        {
            case "master-volumen":
                float vma = save_volume.master_volumen;
                save_volume.master_volumen = Mathf.Clamp(vma + 0.1f, 0.001f, 1f);
                break;

            case "music-volumen":
                float vmu = save_volume.music_volume;
                save_volume.music_volume = Mathf.Clamp(vmu + 0.1f, 0.001f, 1f);
                break;

            case "sfx-volumen":
                float vsf = save_volume.sfx_volume;
                save_volume.sfx_volume = Mathf.Clamp(vsf + 0.1f, 0.001f, 1f);
                break;

        }
    }

    public void LessVolume(string id)
    {
        switch (id)
        {
            case "master-volumen":
                float vma = save_volume.master_volumen;
                save_volume.master_volumen = Mathf.Clamp(vma - 0.1f, 0.001f, 1f);
                break;

            case "music-volumen":
                float vmu = save_volume.music_volume;
                save_volume.music_volume = Mathf.Clamp(vmu - 0.1f, 0.001f, 1f);
                break;

            case "sfx-volumen":
                float vsf = save_volume.sfx_volume;
                save_volume.sfx_volume = Mathf.Clamp(vsf - 0.1f, 0.001f, 1f);
                break;

        }
    }




}
