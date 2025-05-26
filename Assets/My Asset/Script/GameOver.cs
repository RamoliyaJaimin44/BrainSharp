using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Button Home;
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        Home.onClick.AddListener(GoHome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoHome()
    {


        Menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
