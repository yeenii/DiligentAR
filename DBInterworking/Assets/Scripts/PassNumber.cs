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

            btn.onClick.AddListener(BtnClick);         //��ũ��Ʈ�� ��ư �̺�Ʈ ����

        }


    }

    void BtnClick()
    {
        //��ư Ŭ���Ǹ� ����

       Debug.Log(RealNum.text);
        Debug.Log(InputNum.text);

    }

}
