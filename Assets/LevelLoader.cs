using System.Collections.Generic;
using TaskArcher.Prototype;
using TaskArcher.SceneModels;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TaskArcher
{
    public class LevelLoader : MonoBehaviour
    {

        public List<TextAsset> levels;
        private CurrentScene _scene;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        void Start()
        {
            _scene = JsonUtility.FromJson<CurrentScene>(levels[0].text);
            var operation = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Single);
            operation.completed += LevelLoaded;
        }

        private void LevelLoaded(AsyncOperation obj)
        {
            ProcessLevelFile();
        }

        private void ProcessLevelFile()
        {
            Physics.IgnoreLayerCollision(11, 4);
            Physics.IgnoreLayerCollision(12, 4);
            Physics.IgnoreLayerCollision(13, 11);
            Physics.IgnoreLayerCollision(12, 12);
            List<GameObject> loaded = new List<GameObject>();
            foreach (var item in _scene.SceneObjects)
            {
                var res = Resources.Load(item.Name);
                GameObject obj = GameObject.Instantiate(res, item.Position, item.Rotation) as GameObject;
                obj.layer = item.Layer;
                obj.name = item.Name;
                if (obj.transform.childCount > 0)
                {
                    for (int i = 0; i < obj.transform.childCount; i++)
                    {
                        var child = obj.transform.GetChild(i);
                        child.gameObject.layer = item.Layer;
                    }
                }
                loaded.Add(obj);
            }
           
          
        }
    }
}
