using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Play : MonoBehaviour
{
    public List<Sprite> SpriteList;

    public List<Image> ImageList;

    public List<Button> ButtonList;

    public Button SameButton;

    public List<int> Group1;
    public List<int> Group2;

    public Button _Exit;
    public Button _Back;
    public Button _Light;


    public bool Light;

    public GameObject Over;
    public GameObject Menu;
    public GameObject AddTime;

    public TextMeshProUGUI Time;
    public TextMeshProUGUI OverTime;

    public CanvasTimer canvasTimer;
    public Menu menu;
    public RewardedInterstitial rewardedInterstitial;



    //public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

        //Get Random number from 0 to SpriteList.count for ImageList create Group1 list        
        for (int i = 0; i < ImageList.Count; i++)
        {
            int n = Random.Range(0, SpriteList.Count);
            // Group1 number has not repetead number
            while (Group1.Contains(n))
            {
                n = Random.Range(0, SpriteList.Count);
            }
            Group1.Add(n);
        }

        //assign Sprite SpriteList to ImageList base on Group1
        for(int i=0; i < ImageList.Count; i++)
        {
            ImageList[i].sprite = SpriteList[Group1[i]];
            //set Random Rotetion for ImageList
            ImageList[i].transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        }
        
        //Get Random number from 0 to SpriteList.count for Buttonlist create Group2 list        
        for(int i= 0; i < ButtonList.Count; i++)
        {
            int n = Random.Range(0, SpriteList.Count);
            //Group2 number has not repetead number or number is not in Group1 List
            while (Group2.Contains(n) || Group1.Contains(n))
            {
                n = Random.Range(0, SpriteList.Count);
            }
            Group2.Add(n);
        }

        ////last element for buttonList is form Group1 which is same from Group1
        //ButtonList[ButtonList.Count - 1].image.sprite = SpriteList[Group1[Random.Range(0, Group1.Count)]];

        ////assign Sprite SpriteList to ButtonList base on Group2
        //for(int i = 0; i < ButtonList.Count - 1; i++)
        //{
        //    ButtonList[i].image.sprite = SpriteList[Group2[i]];
        //    //set random rotetion for ButtonList 0 to Second Last element
        //    ButtonList[i].transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        //}

        ////Get Last Button for ButtonList which has same Sprite from Group1
        //Button LastButton = ButtonList[ButtonList.Count - 1];

        ////Set Random rotetion for last element form ButtonList
        //LastButton.transform.Rotate(Vector3.forward, Random.Range(0f, 360f));

        ////Swap Last Button and Random button from ButtonList
        //Sprite Img = SameButton.image.sprite;
        //SameButton.image.sprite = LastButton.image.sprite;
        //LastButton.image.sprite = Img;

       
        for (int i = 0; i < ButtonList.Count ; i++)
        {           
            ButtonList[i].image.sprite = SpriteList[Group2[i]];
            //set random rotetion for ButtonList 0 to Second Last element
            ButtonList[i].transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        }

        // Get Random Image for same button
        //Get Random Image from ImageList 0 to Last Button
        Image SameImage = ImageList[Random.Range(0, ImageList.Count)];

        // Get Random button for same button
        //Get Random Button from ButtonList 0 to Last Button
        SameButton = ButtonList[Random.Range(0, ButtonList.Count)];

        //Same Button Sprite
        SameImage.sprite = SameButton.image.sprite;


        _Exit.onClick.AddListener(ExitButton);
        _Back.onClick.AddListener(BackButton);
        _Light.onClick.AddListener(LightButton);
    }



    // Update is called once per frame
    void Update()
    {
        //for Tutorial Button check Tutorial Button is Clicked or not
        if (menu._Tutorial)
        {
            SameButton.GetComponent<Animator>().enabled = true; //on animation for SameButton
        }
    }

    //Reset Image and Button 
    public void Retry()
    {
        Group1.Clear();

        //Tranform Group2 element to Group1 element
        for (int i = 0; i < Group2.Count; i++)
        {
            Group1.Add(Group2[i]);
        }
        Group2.Clear();
        SecondGroup();
    }
    public void SecondGroup()
    {
        //assign Sprite SpriteList to ImageList base on Group1
        for (int i = 0; i < ImageList.Count; i++)
        {
            ImageList[i].sprite = SpriteList[Group1[i]];
            //set Random Rotetion for ImageList
            //ImageList[i].transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        }

        //Get Random number from 0 to SpriteList.count for Buttonlist create Group2 list        
        for (int i = 0; i < ButtonList.Count; i++)
        {
            int n = Random.Range(0, SpriteList.Count);
            //Group2 number has not repetead number or number is not in Group1 List
            while (Group2.Contains(n) || Group1.Contains(n))
            {
                n = Random.Range(0, SpriteList.Count);
            }
            Group2.Add(n);
        }

        for (int i = 0; i < ButtonList.Count; i++)
        {
            ButtonList[i].image.sprite = SpriteList[Group2[i]];
            //set random rotetion for ButtonList 0 to Second Last element
            ButtonList[i].transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        }

        // Get Random Image for same Sprite
        //Get Random Image from ImageList 0 to Last Button
        Image SameImage = ImageList[Random.Range(0, ImageList.Count)];

        // Get Random button for same Sprite
        //Get Random Button from ButtonList 0 to Last Button
        SameButton = ButtonList[Random.Range(0, ButtonList.Count)];

        //Same Button Sprite
        SameImage.sprite = SameButton.image.sprite;
    }
    
     
    public void ExitButton()  //Exit Button
    {
        //false bool timer for EndLess and Timed
        canvasTimer.End = false;
        canvasTimer._Time = false;
        
        Light = false; //false Light bool 

        //false _Tutorial bool for Stoping Tutorial animation
        menu._Tutorial = false;
        TutorialOff(); //All Button Animation false

        Over.SetActive(true);
        gameObject.SetActive(false);
        AddTime.SetActive(false);
    }
    public void BackButton()  //Back Button
    {
        canvasTimer.End = false; //false bool timer for EndLess and Timed
        canvasTimer._Time = false;

        Light = false; //false Light bool 

        menu._Tutorial = false;  //false _Tutorial bool for Stoping Tutorial animation
        TutorialOff(); //All Button Animation false

        Menu.SetActive(true);
        gameObject.SetActive(false);
        AddTime.SetActive(false);
    }
    public void LightButton()
    {
        rewardedInterstitial.LoadRewardedInterstitialAd();
        rewardedInterstitial.ShowRewardedInterstitialAd();

        Light = true;  //Light Button Clicked
        SameButton.GetComponent<Animator>().enabled = true;  //set Animation for sameButtonn
    }


    //off All Animation in Tutorial Button when Exit or Back button click
    public void TutorialOff()
    {
        for (int i = 0; i < ButtonList.Count; i++)
        {
            ButtonList[i].GetComponent<Animator>().enabled = false;
        }
    }
}


//List<T> GetRendomElements<T>(List<T> InputList, int Count)
//{
//    List<T> OutputList = new List<T>();
//    for(int i = 0; i < Count; i++)
//    {
//        int index = Random.Range(0,InputList.Count);
//        OutputList.Add(InputList[index]);
//        InputList.Remove(InputList[index]);
//    }
//    return OutputList;
//}

//void Start()
//{

//    var RendomElement = GetRendomElements(SpriteList, ImageNumber);
//    Image0.sprite = RendomElement[0];
//    Image1.sprite = RendomElement[1];
//    Image2.sprite = RendomElement[2];
//    Image3.sprite = RendomElement[3];
//    Image4.sprite = RendomElement[4];

//    Button4.image.sprite = RendomElement[1];

//    var RendomSet = GetRendomElements(SpriteList, ButtonNumber);
//    Button0.image.sprite = RendomSet[0];
//    Button1.image.sprite = RendomSet[1];
//    Button2.image.sprite = RendomSet[2];
//    Button3.image.sprite = RendomSet[3];

//    //Add Element in SpriteList which is set in image
//    for (int i = 0; i < ImageNumber; i++)
//    {
//        SpriteList.Add(RendomElement[i]);
//    }

//    //Add Element in SpriteList which is set in Button
//    for (int i = 0; i < ButtonNumber; i++)
//    {
//        SpriteList.Add(RendomSet[i]);
//    }
//}