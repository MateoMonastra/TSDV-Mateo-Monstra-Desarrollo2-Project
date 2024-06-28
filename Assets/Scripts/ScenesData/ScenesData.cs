using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScenesData
{
    [CreateAssetMenu(fileName = "ScenesData", menuName = "Models/SceneData/ScenesData")]
    public class ScenesData : ScriptableObject
    {
        [SerializeField]private List<string> scenes;

        public bool CheckSceneExistence(string sceneName)
        {
            foreach (var scene in scenes)
            {
                if (scene == sceneName )
                {
                    return true;
                }
            }
            return false;
        }
    }
}
