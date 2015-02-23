using UnityEngine;
using System.Collections;

#if UNITY_METRO && !UNITY_EDITOR
using LegacySystem.IO;
#else
using System.IO;
using System.Collections.Generic;
#endif



public class TreeSaveDataLoading : MonoBehaviour {

    public TreeData GetLoadData()
    {
#if UNITY_METRO && !UNITY_EDITOR
        var folderPath = "Database/";
        var filePath = folderPath + name + ".json";

        if (!LibForWinRT.IsFileExistAsync(filePath).Result) return new TreeData(0,Vector3.zero,Vector3.zero);
        var jsonText = LibForWinRT.ReadFileText(filePath).Result;

#else

        var folderpath = Application.persistentDataPath + "/Database/";
        var filePath = folderpath + name + ".json";

        if (!File.Exists(filePath)) return new TreeData(-1,Vector3.zero,Vector3.zero);

        var jsonText = File.ReadAllText(filePath);
#endif
        var json = LitJson.JsonMapper.ToObject<TreeData>(jsonText);

        return json;
    }
}
