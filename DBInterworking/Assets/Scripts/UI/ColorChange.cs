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
       
        //Debug.Log(text.Length+ " - 글자 길이");

        gameObjects[0].SetActive(false);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(false);
        gameObjects[3].SetActive(false);


        for (int i = 0; i < text.Length; i++)
        {
           
            gameObjects[i].SetActive(true);
     
        }
        
    }


}
