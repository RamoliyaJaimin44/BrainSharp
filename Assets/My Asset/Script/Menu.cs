using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public Interstitial interstitial;
    public AppOpen appOpen;

    public Button EndLess;
    public Button Timed;
    public Button tutorial;
    public Button Quit;

    public TextMeshProUGUI Score;
    public Circal2 circal2;

    public GameObject Play;

    public Play play;
    public bool _Tutorial = false;


    private void Awake()
    {
        //appOpen.ShowAppOpenAd();
    }
    // Start is called before the first frame update
    void Start()
    {
        appOpen.ShowAppOpenAd();
        Quit.onClick.AddListener(QuitButton);

        EndLess.onClick.AddListener(EndLes);
        Timed.onClick.AddListener(startTime);
        tutorial.onClick.AddListener(Tutorial);
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndLes()
    {

        interstitial.LoadInterstitialAd();
        interstitial.ShowInterstitialAd();

        Play.SetActive(true);
        gameObject.SetActive(false);
        Score.text = 0.ToString();
        circal2.Score = 0;
    }
    public void startTime()
    {
        interstitial.LoadInterstitialAd();
        interstitial.ShowInterstitialAd();


        Play.SetActive(true);
        gameObject.SetActive(false);
        

        Score.text = 0.ToString();
        circal2.Score = 0;
    }
    public void Tutorial()
    {
        interstitial.LoadInterstitialAd();
        interstitial.ShowInterstitialAd(); 

        Play.SetActive(true);
        gameObject.SetActive(false);

        _Tutorial = true;


        Score.text = 0.ToString();
        circal2.Score = 0;
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
