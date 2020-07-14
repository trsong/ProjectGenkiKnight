using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using LitJson;

//list of JSON file with path extensions
// Only NarrativeManager should be able to use this script
// Take in scene number, output NarrativeEvent - Black Box
// Validation and exception handling
namespace JSONFactory
{
    class JSONAssembly
    {
        private static Dictionary<int, string> _resourceList = new Dictionary<int, string> {
            {2,"/Resources/Tutorial.json"},
            {5,"/Resources/GameEnd.json"},
        };
        public static NarrativeEvent RunJSONFactoryForScene(int sceneNumber)
        {
            string resourcePath = PathForScene(sceneNumber);
            if (IsValidJSON(resourcePath) == true)
            {
                Console.WriteLine("Hello World");
                string jsonString = File.ReadAllText(Application.dataPath + resourcePath);
                
                NarrativeEvent narrativeEvent = JsonMapper.ToObject<NarrativeEvent>(jsonString);
                return narrativeEvent;
            }
            else
            {
                throw new Exception("The JSON is not valid. Please check the schema and file extension.");
            }
        }
        private static string PathForScene(int sceneNumber)
        {
            string resourcePathResult;
            if (_resourceList.TryGetValue(sceneNumber, out resourcePathResult))
            {
                return _resourceList[sceneNumber];
            }
            else
            {
                throw new Exception("The scene number you provided is not in the resource list. Please check the JSONFactory namespace.");
            }
        }

        private static bool IsValidJSON(string path)
        {
            return (Path.GetExtension(path) == ".json") ? true : false;
        }
    }
    }



      