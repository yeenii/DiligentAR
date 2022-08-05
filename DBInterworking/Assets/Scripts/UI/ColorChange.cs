using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorChange : MonoBehaviour
{
    //���̿� ���� ���̺� �� ��Ÿ���� �ϱ�
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

    void ValueChanged(string text) // string �Ű������� �⺻���� ���� �Ű������̴�
    {
       
        Debug.Log(text.Length+ " - ���� ����");

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

    //void ChangeColor() // string �Ű������� �⺻���� ���� �Ű������̴�
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


    //    Debug.Log(text + text.Length + " - ���� �Է� ��");


    //    i++;

    //}

}
