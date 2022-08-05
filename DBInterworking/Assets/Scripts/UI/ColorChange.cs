using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChange : MonoBehaviour
{
    //길이에 따라 네이비 바 나타나게 하기
    string text;
    public InputField myInputField;
    public GameObject[] gameObjects;


    //int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        myInputField.onValueChange.AddListener(ValueChanged);

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void ValueChanged(string text) // string 매개변수는 기본으로 들어가는 매개변수이다
    {
       
        Debug.Log(text.Length+ " - 글자 길이");

        gameObjects[0].SetActive(false);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(false);
        gameObjects[3].SetActive(false);


        for (int i = 0; i < text.Length; i++)
        {
           
            gameObjects[i].SetActive(true);
     
        }
        
    }


    //void Function()
    //{
    //    MyString = text;
    //    result.text = MyString;
    //}

    //void ChangeColor() // string 매개변수는 기본으로 들어가는 매개변수이다
    //{
    //    if (result.Legth <= 1)
    //    {
    //        gameObjects[0].SetActive(true);
    //        gameObjects[1].SetActive(false);
    //        gameObjects[2].SetActive(false);
    //        gameObjects[3].SetActive(false);
    //    }
    //    else if (result.Length <= 2)
    //    {
    //        gameObjects[0].SetActive(true);
    //        gameObjects[1].SetActive(true);
    //        gameObjects[2].SetActive(false);
    //        gameObjects[3].SetActive(false);
    //    }
    //    else if (result.Length <= 3)
    //    {
    //        gameObjects[0].SetActive(true);
    //        gameObjects[1].SetActive(true);
    //        gameObjects[2].SetActive(true);
    //        gameObjects[3].SetActive(false);

    //    }
    //    else if (MyString.Length <= 4)
    //    {
    //        gameObjects[0].SetActive(true);
    //        gameObjects[1].SetActive(true);
    //        gameObjects[2].SetActive(true);
    //        gameObjects[3].SetActive(true);
    //    }


    //    Debug.Log(text + text.Length + " - 글자 입력 중");


    //    i++;

    //}

}
