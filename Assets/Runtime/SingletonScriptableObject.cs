using UnityEditor;
using UnityEngine;

namespace Utilities
{
    public class SingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
    {
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
#if UNITY_EDITOR
                    string[] guid = AssetDatabase.FindAssets($"t:{typeof(T)}");
                    if (guid.Length == 0)
                    {
                        throw new System.Exception($"Asset {typeof(T)} not found");
                    }
                    else
                    {
                        string path = AssetDatabase.GUIDToAssetPath(guid[0]);
                        instance = AssetDatabase.LoadAssetAtPath(path, typeof(T)) as T;
                    }
#else
                    //To find this asset in build, make sure to include it in Player Settings->Other Settings->Preloaded Assets 
                    instance = FindObjectOfType<T>();
#endif
                }

                return instance;
            }
        }

        private static T instance;

        protected virtual void Awake()
        {
            instance = this as T;
        }
    }
}