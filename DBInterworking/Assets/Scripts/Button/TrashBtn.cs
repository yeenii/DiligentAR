using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TrashBtn : MonoBehaviour
{
    private Button btn;

    public GameObject Popup;
    public GameObject TargetUI;

    public Button yesBtn;
    public Button noBtn;


    // Update is called once per frame
    public void BtnClick()
    {
   
        Popup.SetActive(true);
      
    }

    public void YesClick() //yes 버튼 누르면 
    {
        Popup.SetActive(false);

        //TargetUI = GameObject.FindGameObjectWithTag("AR");
        //TargetUI.GetComponent<ARTrackedImg>().placeablePrefabs[0] = null;
        //TargetUI.SetActive(false);
    }

    public void NoClick() //no 버튼 누르면 
    {
       
        Popup.SetActive(false);
    
    }
}
