using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class I18n : MonoBehaviour {

    public static I18n instance;

    private Dictionary<string, string> localizedText;
    private bool isReady = false;
    private string missingTextString = "Localized text not found";

    // Use this for initialization
    void Awake () 
    {
        if (instance == null) {
            instance = this;
        } else if (instance != this)
        {
            Destroy (gameObject);
        }

        DontDestroyOnLoad (gameObject);
    }
    
    void Start(){
        var fileName = string.Format("{0}.json", GameManager.instance.Settings.AppLanguage.ToString().ToLower());
        Debug.Log (fileName);
        LoadLocalizedText(fileName);
    }

    public void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string> ();
        string filePath = Path.Combine (Application.streamingAssetsPath, fileName);
        Debug.Log (filePath);

        if (File.Exists (filePath)) {
            string dataAsJson = File.ReadAllText (filePath);
            LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++) 
            {
                localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);   
            }

            Debug.Log ("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        } else 
        {
            Debug.LogError ("Cannot find file!");
        }

        isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey (key)) 
        {
            result = localizedText [key];
        }

        return result;

    }

    public bool GetIsReady()
    {
        return isReady;
    }

}

[System.Serializable]
public class LocalizationData 
{
    public LocalizationItem[] items;
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}