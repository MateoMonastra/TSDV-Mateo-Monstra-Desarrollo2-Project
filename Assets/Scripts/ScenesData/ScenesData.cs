using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScenesData
{
    [CreateAssetMenu(fileName = "ScenesData", menuName = "Models/SceneData/ScenesData")]
    public class ScenesData : ScriptableObject
    {
        [Tooltip("List of scene names.")]
        [SerializeField]private List<string> scenes;

        /// <summary>
        /// Checks if a scene exists in the list of scenes.
        /// </summary>
        /// <param name="sceneName">The name of the scene to check.</param>
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
