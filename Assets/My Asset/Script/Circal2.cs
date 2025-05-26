using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Circal2 : MonoBehaviour
{

    public Play play;
    public Menu menu;

    public int Score = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI OverText;


    // Start is called before the first frame update
    void Start()
    {
        play.ButtonList[0].onClick.AddListener(() => ButtonClick(0));
        play.ButtonList[1].onClick.AddListener(() => ButtonClick(1));
        play.ButtonList[2].onClick.AddListener(() => ButtonClick(2));
        play.ButtonList[3].onClick.AddListener(() => ButtonClick(3));
        play.ButtonList[4].onClick.AddListener(() => ButtonClick(4));
        play.ButtonList[5].onClick.AddListener(() => ButtonClick(5));
        play.ButtonList[6].onClick.AddListener(() => ButtonClick(6));
        play.ButtonList[7].onClick.AddListener(() => ButtonClick(7));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClick(int Ind)
    {
        //Check Click Button Sprite and SameButton Sprite is same or not
        if(play.ButtonList[Ind].image.sprite == play.SameButton.image.sprite)
        {
            if (play.Light)
            {
                //for Light button Animator off
                play.SameButton.GetComponent<Animator>().enabled = false;
                play.Light = false;
            }
            if (menu._Tutorial)
            {
                play.SameButton.GetComponent<Animator>().enabled = false; //off animation 
            }

            Score += 1;
            play.Retry();
            ScoreText.text = Score.ToString(); //Play Screen Score
            OverText.text = ScoreText.text;  //Game Over Screen Score
            
        }
       
    }

   

    //public void Spawn()
    //{
    //    for (int i = 0; i < Play.Group2.Count; i++)
    //    {
    //        Button SpawnImage = Instantiate(Prefab, transform);
    //        SpawnImage.image.sprite = Play.SpriteList[Play.Group2[i]];
    //        //SpawnImage.transform.position = new Vector2(122f, 155f);
    //        if (i == 0) { SpawnImage.transform.position = new Vector2(-180f, 15f); }
    //        //if (i == 1) { SpawnImage.transform.position = new Vector2(363f - 200f, 1228f + 150f); }
    //        //if (i == 2) { SpawnImage.transform.position = new Vector2(363f - 130f, 1228f - 230f); }
    //        //if (i == 3) { SpawnImage.transform.position = new Vector2(363f - 20f, 1228f - 260f); }
    //        //if (i == 4) { SpawnImage.transform.position = new Vector2(363f + 250f, 1228f + 60f); }
    //        //if (i == 5) { SpawnImage.transform.position = new Vector2(363f - 110f, 1228f + 240f); }
    //        //if (i == 6) { SpawnImage.transform.position = new Vector2(363f - 260f, 1228f + 90f); }
    //    }
    //}
}
