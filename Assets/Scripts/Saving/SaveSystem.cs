using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{ 
    public static void SaveSceneInfo(Player ply)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/sceneSave.fun";
        FileStream stream =  new FileStream(path, FileMode.Create);

        SceneData sd = new SceneData(ply, ply.GetComponent<ExperinceSystem>());
        binaryFormatter.Serialize(stream, sd);
        stream.Close();
    }

    public static SceneData LoadSceneInfo()
    {
        string path = Application.persistentDataPath + "/sceneSave.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            SceneData data = formatter.Deserialize(fileStream) as SceneData;
            fileStream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
