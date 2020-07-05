using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace TaskArcher.SceneModels
{
    [Serializable]
    public class CurrentScene
    {
        public string Name;
        public List<SceneObject> SceneObjects;
    }
}
