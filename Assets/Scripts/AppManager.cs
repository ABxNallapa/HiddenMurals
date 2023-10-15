using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class AppManager : MonoBehaviour
{
    public static AppManager instance = null;

    public GameObject DrawingPrefab;

    // Awake is called before Start
    void Awake()
    {
        if (instance == null) {
            Debug.Log("Launched AppManager");
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject); // Enforce singleton pattern
        }
        DontDestroyOnLoad(gameObject); // Persist across scenes

        XRGeneralSettings.Instance.Manager.InitializeLoaderSync();
        Debug.Log("Initialized XRGeneralSettings");
    }

    // Start is called before the first frame update
    void Start()
    {
        XRGeneralSettings.Instance.Manager.StartSubsystems();
        Debug.Log("Started XRGeneralSettings");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadARScene() {
        XRGeneralSettings.Instance.Manager.StartSubsystems();
        Debug.Log("Stopped XRGeneralSettings");

        SceneManager.LoadScene("ARMode");
    }
}
