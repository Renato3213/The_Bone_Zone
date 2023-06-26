using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour
{
    public static SaveGame instance { get; private set; }

    string path;

    SceneData sceneData;
    public SkeletonFactory factory;

    public List<IDataPersistance> persistentObjects= new List<IDataPersistance>();

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("mais de um save game na cena");
        }
        instance = this;
        path = Application.dataPath + "/save.txt";
    }

    private void Start()
    {
        Load();
    }

    public void NewGame()
    {
        sceneData = new SceneData();
    }


    public void Save()
    {
        NewGame();

        foreach(IDataPersistance obj in persistentObjects)
        {
            obj.SaveData(ref this.sceneData);
        }

        sceneData.resourceData = GameManager.instance.GetResources();

        string s = JsonUtility.ToJson(sceneData, true);    

        Debug.Log(s);
        File.WriteAllText(path, s);
    }

    public void SaveAndQuit()
    {
        Save();

        StartCoroutine(SaveQuit());
    }

    IEnumerator SaveQuit()
    {
        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Menu");
    }

    public void Load()
    {
        if(this.sceneData == null)
        {
            NewGame();
            //return;
        }

        string s = File.ReadAllText(path);

        SceneData data= JsonUtility.FromJson<SceneData>(s);

        GameManager.instance.SetResources(data);
        GameManager.instance.LoadStructures(data);

        foreach(LevelNodeData levelData in data.levelNodes)
        {
           LevelNode levelNode =  ControlaListas.instance.levels.Find((level) => level.fase == levelData.fase);
            levelNode.fase = levelData.fase;
            levelNode.Conquered = levelData.conquered;
        }

        foreach(SkeletonData skeleton in data.skeletons)
        {
            factory.CreateSkeleton(skeleton);
        }
    }

}
