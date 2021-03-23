using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace UI.Menus
{
    public class LoadGameWidget : MenuWidget
    {
        private GameDataList GameData;

        [Header("Scene to Load")]
        [SerializeField] string SceneToLoad;

        [Header("References")] 
        [SerializeField] private RectTransform LoadItemsPanel;

        [SerializeField] private TMP_InputField NawGameInputField;

        [Header("Prefabs")]
        [SerializeField] private GameObject SaveSlotPrefab;

        // Start is called before the first frame update
        private const string SaveFileKey = "FileSaveData";

        [SerializeField] private bool Debug;
        private void Start()
        {
            if (Debug) SaveDebugData();

            wipChildren();
            LoadGameData();

        }

        private void wipChildren()
        {
            foreach (RectTransform saveSlot in LoadItemsPanel)
            {
                Destroy(saveSlot.gameObject);
            }
            LoadItemsPanel.DetachChildren();
        }

        private static void SaveDebugData()
        {
            GameDataList dateList = new GameDataList();
            dateList.SaveFileNames.AddRange(new List<string> { "Save1", "Save2", "Save3" });
            PlayerPrefs.SetString(SaveFileKey, JsonUtility.ToJson(dateList));

        }

        private void LoadGameData()
        {
            if (!PlayerPrefs.HasKey(SaveFileKey)) return;

            string jsonString = PlayerPrefs.GetString(SaveFileKey);
            GameData = JsonUtility.FromJson<GameDataList>(jsonString);

            if (GameData.SaveFileNames.Count <= 0) return;

            foreach(string saveName in GameData.SaveFileNames)
            {
                SaveSlotWidget widget = Instantiate(SaveSlotPrefab, LoadItemsPanel).GetComponent<SaveSlotWidget>();
                widget.Initialize(this, saveName);
            }
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(SceneToLoad);
        }

        public void CreateNewGame()
        {
            if (string.IsNullOrEmpty(NawGameInputField.text)) return;
            GameManager.Instance.SetActiveSave(NawGameInputField.text);
            LoadScene();
        }
    }

    [Serializable]
    class GameDataList
    {
        public List<string> SaveFileNames = new List<string>();
    }

}

