using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void saveUserData(GenerateExcercises generateExcercises)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "SaveFile.befit";
        FileStream stream = new FileStream(path, FileMode.Create);

        UserData userData = new UserData(generateExcercises);

        formatter.Serialize(stream, userData);
        stream.Close();
    }

    public static UserData loadUserData()
    {
        string path = Application.persistentDataPath + "SaveFile.befit";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            UserData userData = formatter.Deserialize(stream) as UserData;
            return userData;
            stream.Close();
        }
        else 
        {
            return null;
        }
    }

}
