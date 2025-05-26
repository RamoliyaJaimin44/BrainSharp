using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExitBack : MonoBehaviour
{
    public Button _Exit;
    public Button _Back;
    public Button _Light;

    public bool Light;

    public GameObject Over;
    public GameObject Menu;

    public TextMeshProUGUI Time;
    public TextMeshProUGUI OverTime;

    public CanvasTimer canvasTimer;
    public Play play;
    public Menu menu;
    // Start is called before the first frame update
    void Start()
    {
        //_Exit.onClick.AddListener(ExitButton);
        //_Back.onClick.AddListener(BackButton);
        //_Light.onClick.AddListener(LightButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void ExitButton()
    //{
    //    canvasTimer.End = false;
    //    canvasTimer._Time = false;

    //    Over.SetActive(true);
    //    gameObject.SetActive(false);

    //    menu._Tutorial = false;
    //    play.TutorialOff();
    //}
    //public void BackButton()
    //{
    //    canvasTimer.End = false;
    //    canvasTimer._Time = false;

    //    Menu.SetActive(true);
    //    gameObject.SetActive(false);

    //    menu._Tutorial = false;
    //    play.TutorialOff();
    //}
    //public void LightButton()
    //{
    //    Light = true;
    //    play.LightOn();
    //}
}
