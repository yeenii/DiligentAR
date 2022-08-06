using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrashBtn : MonoBehaviour
{

    public GameObject Popup; //PopUpUI
    public GameObject TargetUI; //Canvas
    //public GameObject TrashUI; //trash UI

    void Start()
    {
        //Popup.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(YesClick); //yes 버튼
        //Popup.transform.GetChild(2).GetComponent<Button>().onClick.AddListener(NoClick); // no 버튼
    }

    // Update is called once per frame
    public void BtnClick()
    {
   
        Popup.SetActive(true);
      
    }

    public void YesClick()
    {
        Debug.Log("success");
        Popup.SetActive(false);
        TargetUI.SetActive(false);
    
    }


    public void NoClick() //no 버튼
    {
       
        Popup.SetActive(false);
    
    }
}
