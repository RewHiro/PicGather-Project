using UnityEngine;
using System.Collections;

#if UNITY_METRO && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
#endif

public struct FeverData
{
    public FeverData(int times)
        : this()
    {
        Times = times;
    }
    public int Times { get; set; }
}

public class FeverDataController : MonoBehaviour {

    FeverData Data;

    public FeverData GetLoadData()
    {
#if UNITY_METRO && !UNITY_EDITOR
        var folderPath = "Database/";
        var filePath = folderPath + name + ".json";

        if (!LibForWinRT.IsFileExistAsync(filePath).Result) return new TreeData(0,Vector3.zero,Vector3.zero);
        var jsonText = LibForWinRT.ReadFileText(filePath).Result;

#else

        var folderpath = Application.persistentDataPath + "/Database/";
        var filePath = folderpath + name + ".json";

        if (!File.Exists(filePath)) return new FeverData(-1);

        var jsonText = File.ReadAllText(filePath);
#endif
        var json = LitJson.JsonMapper.ToObject<FeverData>(jsonText);

        return json;
    }

    /// <summary>
    /// 書き込み
    /// </summary>
    /// <param name="times"></param>
    public void Write(int times)
    {
        Data = new FeverData(times);
        FileWrite();
    }

    /// <summary>
    /// ファイルに書き出す
    /// </summary>
    void FileWrite()
    {
        string json = LitJson.JsonMapper.ToJson(Data);

#if UNITY_METRO && !UNITY_EDITOR
        LibForWinRT.WriteFileText("Database",name + ".json",json);
#else
        var path = Application.persistentDataPath + "/Database/";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        File.WriteAllText(path + name + ".json", json);
#endif
    }
}
