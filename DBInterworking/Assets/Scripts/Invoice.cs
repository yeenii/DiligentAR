using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; //추가 
using SimpleJSON;

public class Invoice : MonoBehaviour
{
    Action<string> _createItemsCallback;

    //Start is called before the first frame update
    void Start()
    {
        //json 통해 불러오기
        _createItemsCallback = (jsonArrayString) =>
        {
            StartCoroutine(CreateItemsRoutine(jsonArrayString));
        };
       
        //CreateItems();
    }

    //public void CreateItems()
    //{
    //    //id 받아오는 함수 
    //    string id = Main.Instance.UserInfo.ID;  //문제
    //    StartCoroutine(Main.Instance.Web.GetInvoiceID(id, _createItemsCallback));
        
    //}

    IEnumerator CreateItemsRoutine(string jsonArrayString)
    {
        //Parsing json array string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            //Create local variables
            bool isDone = false; //are we done downloading?
            string invoiceId = jsonArray[i].AsObject["invoiceId"];
            JSONObject itemInfoJson = new JSONObject();

            //Create a callback to get the information from Web.cs
            Action<string> getItemInfoCallback = (itemInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;
            };
            StartCoroutine(Main.Instance.Web.GetInvoice(invoiceId, getItemInfoCallback));

            //wait until the callback  is called from WEB (info finished downloading)
            yield return new WaitUntil(() => isDone == true);

            //Instantiate GameObject (item prefab)
            GameObject Invoice = Instantiate(Resources.Load("Prefabs/Invoice") as GameObject);
            Invoice.transform.SetParent(this.transform);
            Invoice.transform.localScale = Vector3.one;
            Invoice.transform.localPosition = Vector3.zero;

            //Fill information
            //item.transform.Find("id").GetComponent<Text>().text = itemInfoJson["id"];
            Invoice.transform.Find("Name").GetComponent<Text>().text = itemInfoJson["username"];
            Invoice.transform.Find("Address").GetComponent<Text>().text = itemInfoJson["address"];
            

            //continue to the next  item

        }

    }
}
