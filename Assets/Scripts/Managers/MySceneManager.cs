using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class MySceneManager : MonoBehaviour
    {
        
        [Tooltip("List of initial scenes to be loaded")]
        [SerializeField] private List<string> initScenes;
        
        [Tooltip("Reference to the ScenesData scriptable object that contains scene data")] 
        [SerializeField] private ScenesData.ScenesData scenesData;
        
        
        private List<string> _scenes = new List<string>();

        /// <summary>
        /// Called on the frame when a script is enabled just before any of the Update methods are called the first time.
        /// </summary>
        private void Start()
        {
            // Iterate through each scene in the initial scenes list and add them.
            foreach (var scene in initScenes)
            {
                AddScene(scene);
            }
        }

        /// <summary>
        /// Method to add a scene by its name.
        /// </summary>
        /// <param name="sceneName">Name of the scene to add.</param>
        public void AddScene(string sceneName)
        {
            if (!scenesData.CheckSceneExistence(sceneName)) return;
            
            if (_scenes.Any(scene => scene == sceneName)) return;
            
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            
            _scenes.Add(sceneName);
        }

        /// <summary>
        /// Method to remove a scene by its name.
        /// </summary>
        /// <param name="sceneName">Name of the scene to remove.</param>
        public void RemoveScene(string sceneName)
        {
            if (!scenesData.CheckSceneExistence(sceneName)) return;
            
            if (_scenes.All(scene => scene != sceneName)) return;
            
            SceneManager.UnloadSceneAsync(sceneName);
            
            _scenes.Remove(sceneName);
        }
    }
}