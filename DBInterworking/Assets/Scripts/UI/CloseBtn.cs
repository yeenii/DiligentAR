using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseBtn : MonoBehaviour
{

    public GameObject TargetUI;
  
    // Start is called before the first frame update
    void Start()
    {
 
    }

    void Update()
    {

    }

    // Update is called once per frame
    public void BtnClick()
    {
        
            TargetUI.SetActive(false);
    

    }

 
}
