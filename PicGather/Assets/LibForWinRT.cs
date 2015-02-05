using UnityEngine;
using System.Collections;

#if UNITY_METRO && !UNITY_EDITOR
using System;
using LegacySystem.IO;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO;
using WinRTLegacy.Text;
using Windows.Storage.Pickers;
using System.Collections.Generic;
using Windows.Storage.Provider;
#else
#endif


/// <summary>
/// WinRTのライブラリー
/// </summary>
public class LibForWinRT 
{

#if UNITY_METRO && !UNITY_EDITOR
  
    /// <summary>
    /// 書き出す
    /// </summary>
    /// <param name="folderPath">Folderパス</param>
    /// <param name="fileName">ファイルパス</param>
    /// <param name="body">byte配列のデータ</param>
    public static async void WriteFile(string folderPath,string fileName, byte[] body)
    {
        // ローミングフォルダ
        StorageFolder folder = await ApplicationData.Current.RoamingFolder.CreateFolderAsync(folderPath, CreationCollisionOption.OpenIfExists);

        // ファイル（存在すれば上書き）
        StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

        // 書き込み
        using (IRandomAccessStream rStream = await file.OpenAsync(FileAccessMode.ReadWrite))
        using (IOutputStream oStream = rStream.GetOutputStreamAt(0))
        {
            DataWriter writer = new DataWriter(oStream);
            writer.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            writer.WriteBytes(body);
            await writer.StoreAsync();
        }

    }
    /// <summary>
    /// 書き出す
    /// </summary>
    /// <param name="folderPath">Folderパス</param>
    /// <param name="fileName">ファイルパス</param>
    /// <param name="body">byte配列のデータ</param>
    public static async void WriteSharePicture(string folderPath, string fileName, byte[] body)
    {
        // ローミングフォルダ
        StorageFolder folder = await KnownFolders.PicturesLibrary.CreateFolderAsync(folderPath, CreationCollisionOption.OpenIfExists);

        // ファイル（存在すれば上書き）
        StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

        // 書き込み
        using (IRandomAccessStream rStream = await file.OpenAsync(FileAccessMode.ReadWrite))
        using (IOutputStream oStream = rStream.GetOutputStreamAt(0))
        {
            DataWriter writer = new DataWriter(oStream);
            writer.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            writer.WriteBytes(body);
            await writer.StoreAsync();
        }

    }
    
    /// <summary>
    /// 書き出す
    /// </summary>
    /// <param name="folderPath">Folderパス</param>
    /// <param name="fileName">ファイルパス</param>
    /// <param name="body">stringの文字データ</param>
    public static async void WriteFile(string folderPath, string fileName, string body)
    {
        // ローミングフォルダ
        StorageFolder folder = await ApplicationData.Current.RoamingFolder.CreateFolderAsync(folderPath, CreationCollisionOption.OpenIfExists);

        // ファイル（存在すれば上書き）
        StorageFile file = await folder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

        // 書き込み
        using (IRandomAccessStream rStream = await file.OpenAsync(FileAccessMode.ReadWrite))
        using (IOutputStream oStream = rStream.GetOutputStreamAt(0))
        {
            DataWriter writer = new DataWriter(oStream);
            writer.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            writer.WriteString(body);
            await writer.StoreAsync();
        }

    }
#endif

}
