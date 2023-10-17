using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine.Networking;
using System.Text;
using System;

public class API
{
    class ImagePostRequest
    {
        public string location_id;
        public string data;
    }

   private const string baseurl = "http://35.227.98.64:5000";
   public IEnumerator GetImg(string locationId, Action<UnityEngine.Networking.UnityWebRequest> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(baseurl + "/retrieve/" + locationId))
        {
            yield return webRequest.SendWebRequest();
            callback(webRequest);
            Debug.Log(webRequest.result);
        }
    }
   
   public IEnumerator GetAllLocations(Action<UnityEngine.Networking.UnityWebRequest> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(baseurl + "/retrieveall"))
        {
            yield return webRequest.SendWebRequest();
            callback(webRequest);
            Debug.Log(webRequest.result);
        }
    }

    public IEnumerator UpdateImage(string locationId, string byteString) 
    {
        ImagePostRequest myObject = new ImagePostRequest();
        myObject.location_id = locationId;
        myObject.data = byteString;
        string jsonStringTrial = JsonUtility.ToJson(myObject);

        return Post(baseurl + "/update", jsonStringTrial);
    }

    public IEnumerator CreateImage(string locationId, string byteString)
    {
        ImagePostRequest myObject = new ImagePostRequest();
        myObject.location_id = locationId;
        myObject.data = byteString;
        string jsonStringTrial = JsonUtility.ToJson(myObject);

        return Post(baseurl + "/create", jsonStringTrial);
    }

    IEnumerator Post(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        Debug.Log("Status Code: " + request.responseCode);
    }
}
