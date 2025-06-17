using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FileDataService : IDataService
{
    ISerializer _serializer;
    string dataPath;
    string fileExtension;

    public FileDataService(ISerializer serializer)
    {
        _serializer = serializer;
        this.dataPath = Application.persistentDataPath;
        this.fileExtension = "json";
    }

    string GetPathToFile(string fileName)
    {
        return Path.Combine(dataPath, $"{fileName}.{fileExtension}");
    }

    public void Save(GameData data, bool overwrite = true)
    {
        string fileLocation = GetPathToFile(data.Name);

        if(!overwrite && File.Exists(fileLocation))
        {
            throw new IOException($"File {fileLocation} already exists and cannot be overwritten");
        }

        File.WriteAllText(fileLocation, _serializer.Serialize(data));
    }
    public GameData Load(string name)
    {
        string fileLocation = GetPathToFile(name);

        if (!File.Exists(fileLocation))
        {
            throw new FileNotFoundException($"Save file {fileLocation} does not exist.");
        }

        return _serializer.Deserialize<GameData>(File.ReadAllText(fileLocation));
    }


    public void Delete(string name)
    {
        string fileLocation = GetPathToFile(name);

        if (File.Exists(fileLocation))
        {
            File.Delete(fileLocation);
        }
    }
    public void DeleteAll()
    {
        foreach(string filePath in Directory.GetFiles(dataPath))
        {
            if (Path.GetExtension(filePath) == $".{fileExtension}")
            {
                File.Delete(filePath);
            }
        }
    }

    public IEnumerable<string> ListSaves()
    {
        foreach (string filePath in Directory.EnumerateFiles(dataPath))
        {
            if (Path.GetExtension(filePath) == fileExtension)
            {
                yield return Path.GetFileNameWithoutExtension(filePath);
            }
        }
    }

}