using System;
using System.Collections.Generic;
using System.IO;
using SimpleJSON;
using UnityEditor;


//public static class JsonLoader
//{   
//    public static void Load(string folderPath)
//    {
//        string[] jsons = Directory.GetFiles(folderPath, "*.json");

//        foreach (string json in jsons)
//        {
//            string content = File.ReadAllText(json);
//            JSONNode node = JSON.Parse(content);
//            JSONNode enemiesNode = node["enemies"];

//            if ( enemiesNode != null )
//            {
//                ParseEnemies(enemiesNode);
//            }
//        }
//    }

//    private static void ParseEnemies(JSONNode node)
//    {
//        Dictionary<string, List<Enemy>> enemies = new Dictionary<string, List<Enemy>>();

//        foreach (var character in node)
//        {
//            var value = character.Value;
//            string[] locations = ParseStringVector(value["locations"]);

//            foreach (var loc in locations)
//            {
//                if (!enemies.ContainsKey(loc))
//                    enemies.Add(loc, new List<Enemy>());
                
//                enemies[loc].Add(new Enemy(character));
//            }
//        }
        
//        JsonObjectHandler.GetInstance().SetEnemies(enemies);
//    }

//    public static string[] ParseStringVector(JSONNode node)
//    {
//        string[] vec = new string[node.Count];
//        for (int i = 0; i < node.Count; i++)
//        {
//            vec[i] = node[i].ToString();
//            vec[i] = vec[i].Remove(vec[i].Length - 1);
//            vec[i] = vec[i].Remove(0, 1);
//        }

//        return vec;
//    }
//}
