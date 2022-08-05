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
       
        //Debug.Log(text.Length+ " - ���� ����");

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
