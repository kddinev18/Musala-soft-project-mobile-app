using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    public static void saveUserData(GenerateExcercises generateExcercises)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = "Assets\\Save Files\\SaveFile.sf";
        FileStream stream = new FileStream(path, FileMode.Create);

        UserData userData = new UserData(generateExcercises);

        formatter.Serialize(stream, userData);
        stream.Close();
    }

    public static UserData loadUserData()
    {
        string path = "Assets\\Save Files\\SaveFile.sf";
        if(File.Exists(path))
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
