

using System;
using UnityEngine;

namespace TaskArcher.SceneModels
{
    [Serializable]
    public class SceneObject
    {
        public Vector3 Position;
        public string Name;
        public Quaternion Rotation;
        public int Layer;
    }
}
