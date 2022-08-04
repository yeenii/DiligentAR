using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GetInvoiceID(string invoiceId, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("invoiceId", invoiceId);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/GetInvoiceID.php", form))
        {

            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
                //Main.Instance.UserInfo.SetID(www.downloadHandler.text);

                string jsonArray = www.downloadHandler.text; //JSON

                //Call callback function to pass result 
                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetInvoice(string id, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", "1");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unityBackend/GetInvoice.php", form))
        {

            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
                //Main.Instance.UserInfo.SetID(www.downloadHandler.text);
              
                string jsonArray = www.downloadHandler.text; //JSON

                //Call callback function to pass result 
                callback(jsonArray);
            }
        }
    }

}
