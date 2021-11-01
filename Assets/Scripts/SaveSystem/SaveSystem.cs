using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //onde colocar os dados
    private static string playerDataPath = Application.persistentDataPath + "/player.fun";

    //pega dados do jogador e coloca no file
    public static void SavePlayer (PlayerSaveVariables player)
    {
        //cria o file
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerDataPath, FileMode.Create);
        
        //pega dados
        PlayerData data = new PlayerData(player);

        //coloca dados
        formatter.Serialize(stream, data);

        //fecha o file
        stream.Close();
    }

    //pega dados do file e devolve os dados
    public static PlayerData LoadPlayer()
    {
        //ve se tem algo salvado
        if(!File.Exists(playerDataPath))
        {
            Debug.LogError("File não existe no " + playerDataPath);
            return null;
        }

        //abre o file
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(playerDataPath, FileMode.Open);

        //le dados
        PlayerData data = formatter.Deserialize(stream) as PlayerData;

        //fecha o file
        stream.Close();

        //devolve dados
        return data;
    }
}
