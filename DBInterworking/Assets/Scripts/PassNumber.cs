using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PassNumber : MonoBehaviour
{
    public InputField RealNum;
    public Text InputNum;
    Button btn;

    // Start is called before the first frame update

    void Start()
    {

        btn = this.transform.GetComponent<Button>();

        if (btn != null)

        {

            btn.onClick.AddListener(BtnClick);         //스크립트로 버튼 이벤트 수행

        }


    }

    void BtnClick()
    {
        //버튼 클릭되면 동작

       Debug.Log(RealNum.text);
        Debug.Log(InputNum.text);

    }

}
