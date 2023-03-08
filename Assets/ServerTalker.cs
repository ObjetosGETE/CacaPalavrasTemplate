using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class ServerTalker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string address = "http://homologacao.senacead.com.br:82/user/";
        StartCoroutine(GetWebData(address, "UnityID"));
    }
  
    private IEnumerator GetWebData(string address, string id)
    {
        UnityWebRequest www = UnityWebRequest.Get(address + id);
        yield return www.SendWebRequest();

        if(www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Something went wrong " + www.error);
            yield break;
        }

        Debug.Log(www.downloadHandler.text);

        ProcessData(www.downloadHandler.text);
    }

    private void ProcessData(string rawResponse)
    {
        JSONNode node = SimpleJSON.JSON.Parse(rawResponse);

        Debug.Log("Name: " + node["username"]);

        Debug.Log("User wins: " + node["wins"]);
    }
}
