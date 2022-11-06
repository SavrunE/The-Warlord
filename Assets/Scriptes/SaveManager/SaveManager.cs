using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager 
{
    public static void Save<T>(string key, T saveData)
    {
        string jsonDataString = JsonUtility.ToJson(saveData, true);
        PlayerPrefs.SetString(key, jsonDataString);
    }

    public static T Load<T>(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string loadedString = PlayerPrefs.GetString(key);
            return JsonUtility.FromJson<T>(loadedString);
        }
        else
        {
            Debug.Log("On loaded SaveManager has no key, returned default");
            return default;
        }
    }
}
