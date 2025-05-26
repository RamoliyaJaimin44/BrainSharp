using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasTimer : MonoBehaviour
{

    public Rewarded rewardedAd;
    public GameObject Over;
    public GameObject Play;

    public GameObject AddTime;
    public Button addButton;

    public Button EndLess;
    public Button Timed;
    public Button Tutorial;
    public TextMeshProUGUI _Timer;
    public TextMeshProUGUI OverTime;

    public bool End = false;
    public bool _Time = false;


    private float CurrentTime;
    private int IntTime;
    // Start is called before the first frame update
    void Start()
    {
        EndLess.onClick.AddListener(EndLes);
        Timed.onClick.AddListener(startTime);
        Tutorial.onClick.AddListener(tutorial);
        addButton.onClick.AddListener(Add_Time);
    }

    // Update is called once per frame
    void Update()
    {
        if (End) //for EndLess Button
        {
            CurrentTime = CurrentTime + Time.deltaTime; //Current Time
            IntTime = Mathf.RoundToInt(CurrentTime);
            _Timer.text = IntTime.ToString(); //Play Screen Time
            OverTime.text = IntTime.ToString(); //Game Over Screen Time
        }
       
        if (_Time)  //for Timed Button
        {
            CurrentTime = CurrentTime - Time.deltaTime;
            IntTime = Mathf.RoundToInt(CurrentTime);
            if(IntTime == 0)
            {
                Over.SetActive(true);
                Play.SetActive(false);
                _Time = false;
                OverTime.text = 60.ToString();
            }
            OverTime.text = (60 - IntTime).ToString(); //Game Over Screen Time
            _Timer.text = IntTime.ToString();  // Play Screen Time
        }
        

    }
    public void EndLes()
    {
        CurrentTime = 0;
        End = true; //EndLess Button 
    }
    public void startTime() //Timed button 
    {
        CurrentTime = 60;
        _Time = true; 
        AddTime.SetActive(true);
    }
    public void tutorial() //Tutorial Button
    {
        CurrentTime = 0;
        _Timer.text = CurrentTime.ToString();
        OverTime.text = 0.ToString();
    }
    public void Add_Time() // Add Time button 
    {
        rewardedAd.LoadRewardedAd();
        rewardedAd.ShowRewardedAd();
        CurrentTime = CurrentTime + 20; //Add 20 Second 
    }
}
