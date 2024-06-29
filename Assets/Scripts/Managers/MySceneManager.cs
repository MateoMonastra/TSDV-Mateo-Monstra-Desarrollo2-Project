using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class MySceneManager : MonoBehaviour
    {
        [SerializeField] private List<string> initScenes;
        [SerializeField] private ScenesData.ScenesData scenesData;
        private List<string> _scenes = new List<string>();

        private void Start()
        {
            foreach (var scene in initScenes)
            {
                AddScene(scene);
            }
        }

        public void AddScene(string sceneName)
        {
            if (!scenesData.CheckSceneExistence(sceneName)) return;

            if (_scenes.Any(scene => scene == sceneName)) return;
            
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
            
            _scenes.Add(sceneName);
            
        }

        public void RemoveScene(string sceneName)
        {
            if (!scenesData.CheckSceneExistence(sceneName)) return;

            if (_scenes.All(scene => scene != sceneName)) return;

            SceneManager.UnloadSceneAsync(sceneName);
            
            _scenes.Remove(sceneName);
            
        }
    }
}