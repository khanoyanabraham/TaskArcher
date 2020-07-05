using TaskArcher.SceneModels;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class Saver
    {
        [MenuItem("TaskArcher/SaveScene")]
        private static void SaveScene()
        {
            var currentSceneObject = GameObject.FindObjectsOfType<GameObject>();
            var sceneName = SceneManager.GetActiveScene().name;
            var scene = new CurrentScene();
           
            scene.Name = sceneName;
            scene.SceneObjects = new List<SceneObject>();

            foreach (var gmo in currentSceneObject)
            {
                if (gmo.transform.parent != null)
                {
                    continue;
                }
                SceneObject scno = new SceneObject();
               
                if (gmo.name.Contains(" ("))
                {
                    gmo.name = gmo.name.Substring(0, gmo.name.IndexOf(" ("));
                }
                scno.Name = gmo.name;
                scno.Rotation = gmo.transform.rotation;
                scno.Position = gmo.transform.position;
                scno.Layer = gmo.layer;
                scene.SceneObjects.Add(scno);
            }
            var jsonfile = JsonUtility.ToJson(scene);
            SaveSceneFile(jsonfile, scene.Name);
            scene = null;
        }
        
        [MenuItem("TaskArcher/NewScene")]
        public static void NewScene()
        {
            EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        }
        private static void SaveSceneFile(string json, string sceneName)
        {
            string dataPath = "Assets/Levels";
            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
            dataPath += "/"+sceneName+".json";
            try
            {
                System.IO.File.WriteAllText(dataPath, json);
            }
            catch (System.Exception ex)
            {
                string ErrorMessages = "File Write Error\n" + ex.Message;
                Debug.LogError(ErrorMessages);
            }
        }
    }
}