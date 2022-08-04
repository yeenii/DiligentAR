using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvoiceSelect : MonoBehaviour
{
    string URL = "http://localhost/unityBackend/InvoiceSelect.php";

    public string[] InvoiceData;
    public int id; //user 지정

    public Text Sname;
    public Text Sphonenumber;
    public Text Saddress;

    public Text Rname;
    public Text Rphonenumber;
    public Text Raddress;

    public Text Contents;

    IEnumerator Start()
    {
        WWW invoice = new WWW(URL);
        yield return invoice;
        string invoiceDataString = invoice.text;
        InvoiceData = invoiceDataString.Split(';');

        Sname.text = GetValueData(InvoiceData[id], " Sname : ");
        Sphonenumber.text = GetValueData(InvoiceData[id], "Sphonenumber : ");
        Saddress.text = GetValueData(InvoiceData[id], "Saddress : ");

        Rname.text = GetValueData(InvoiceData[id], "Rname : ");
        Rphonenumber.text = GetValueData(InvoiceData[id], "Rphonenumber : ");
        Raddress.text = GetValueData(InvoiceData[id], "Raddress : ");

        Contents.text = GetValueData(InvoiceData[id], "Contents : ");
    }


    string GetValueData(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|")); // 구분했던 | 없애기
        }
        return value;
    }
}
