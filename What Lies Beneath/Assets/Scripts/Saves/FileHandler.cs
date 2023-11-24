using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEditor;

public class FileHandler : MonoBehaviour
{
    public static FileHandler Instance;

    [SerializeField] private bool isLocal = true;
    [SerializeField] private bool fileValidation;
    //[SerializeField] private string JSONFile = "images.json";
    [SerializeField] private string filePath = "/Scripts/Saves/";

    private void Awake()
    {
        Instance = this;
    }

    public string ReadFile(string JSONFile)
    {
        Debug.Log("aqui");
        string fullPath = string.Empty;
        
        string streamContent = "";
        if (!isLocal)
        {
            fullPath = Application.persistentDataPath + "/" + JSONFile;
        }
        else
        {
            fullPath = filePath + JSONFile;
        }

        fileValidation = File.Exists(Application.dataPath + fullPath);
        if (!fileValidation)
        {
            Debug.Log("file not found");
        }
        else
        {
            
            StreamReader fileReader = new StreamReader(Application.dataPath + fullPath, Encoding.Default);
            streamContent = fileReader.ReadToEnd();
            fileReader.Close();
        }
        RefreshEditorProjectWindow();
        Debug.Log(streamContent);
        return streamContent;
    }

    
    public void WriteFile(string objToStore, string JSONFile)
    {
        string fullPath = string.Empty;
        if (!isLocal)
        {
            fullPath = Application.persistentDataPath + "/" + JSONFile;
        }
        else
        {
            fullPath = filePath + JSONFile;
        }

        fileValidation = File.Exists(Application.dataPath + fullPath);
        if (!fileValidation)
        {

            Debug.Log(JSONFile);
            File.WriteAllBytes(Application.dataPath + fullPath, System.Text.Encoding.UTF8.GetBytes(objToStore));
        }
        else
        {
            File.Delete(Application.dataPath + fullPath);
            File.WriteAllBytes(Application.dataPath + fullPath, System.Text.Encoding.UTF8.GetBytes(objToStore));
        }
        RefreshEditorProjectWindow();

    }
    
    void RefreshEditorProjectWindow()
    {
#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
#endif
    }
}
