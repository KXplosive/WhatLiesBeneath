using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaSave : MonoBehaviour
{
    public GameObject player;
    public GameObject inScreen;
    public int floor, level;
    public SaveData save;
    public string jsonFile = "save1.json";

    public void setSaveData()
    {
        save.player = player;
        save.floor = floor;
        save.level = level;
    }

    public void getData()
    {
        player = save.player;
        floor = save.floor;
        level = save.level;
    }

    public void writeJson()
    {
        setSaveData();
        FileHandler.Instance.WriteFile(JsonUtility.ToJson(save),jsonFile);
    }

    public void readJson()
    {
        save = JsonUtility.FromJson<SaveData>(FileHandler.Instance.ReadFile(jsonFile));
        getData();
        Destroy(inScreen);
        inScreen = Instantiate(player);
    }

    // Start is called before the first frame update
    void Start()
    {
        setSaveData();
        inScreen = Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
