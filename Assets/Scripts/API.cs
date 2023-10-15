using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine.Networking;

public class API : MonoBehaviour
{
    private const string baseurl = "http://35.227.98.64:5000/";
    public void dummy() {
        print("HI");
    }
   public IEnumerator GetImg(string locationId)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(baseurl + "/retrieve" + locationId))
        {
            yield return webRequest.SendWebRequest();
        }
    }
   
   public IEnumerator GetAllLocations()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(baseurl + "/retrieveall"))
        {
            yield return webRequest.SendWebRequest();
        }
    }

    public IEnumerator UpdateImage(string locationId, string byteString) 
    {
        WWWForm form = new WWWForm();
        form.AddField("locationId", locationId);
        form.AddField("byteString", byteString);
        form.AddField("Content-Type", "application/json");
        using (UnityWebRequest webRequest = UnityWebRequest.Post(baseurl + "/update", form))
        {
            yield return webRequest.SendWebRequest();
        }
    }

    public IEnumerator CreateImage(string locationId, string byteString)
    {
        WWWForm form = new WWWForm();
        form.AddField("locationId", locationId);
        form.AddField("byteString", byteString);
        form.AddField("Content-Type", "application/json");
        using (UnityWebRequest webRequest = UnityWebRequest.Post(baseurl + "/create", form))
        {
            yield return webRequest.SendWebRequest();
        }
    }
}
