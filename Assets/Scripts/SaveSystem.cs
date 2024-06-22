using UnityEngine;

namespace SaveSystemTutorial
{
    public static class SaveSystem
    {
        public static void SaveByPlayerPrefs(string key,object data) {
            var json = JsonUtility.ToJson(data);
            PlayerPrefs.SetString(key, json);
            PlayerPrefs.Save();
        }

        public static string LoadByPlayerFrebs(string key) {
            return PlayerPrefs.GetString(key, "404");
        }
    }
}