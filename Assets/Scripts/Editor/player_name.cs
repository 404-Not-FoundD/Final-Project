using UnityEngine;
using UnityEngine.UI;

namespace SaveSystemTutorial
{
    public class player_name : MonoBehaviour
    {
        [SerializeField] InputField input_name; // Save input bar


        #region Fields
        [SerializeField] string playerName = "Player Name";
        const string player_data_key = "PlayerData";
        #endregion


        #region Properties
        public string Name => playerName;
        #endregion

        #region Save and Load
        public void Save()
        {
            SaveByPlayerPrefs();
        }

        public void Load()
        {
            LoadFromPlayerPrefs();
        }
        #endregion


        #region PlayerPrefs
        void SaveByPlayerPrefs()
        {
            PlayerPrefs.SetString(player_data_key,playerName);
            PlayerPrefs.Save();
        }

        void LoadFromPlayerPrefs()
        {
            playerName =  PlayerPrefs.GetString(player_data_key,"404");
        }

        public void SetName(string newName)
        {
            playerName = newName;
        }

        [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]

        public static void DeletePlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
        #endregion
    }
}