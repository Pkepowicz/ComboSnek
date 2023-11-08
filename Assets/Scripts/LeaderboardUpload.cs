using UnityEngine;
using TMPro;

// NOTE: Make sure to include the following namespace wherever you want to access Leaderboard Creator methods
using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class LeaderboardUpload : MonoBehaviour
    {
        [SerializeField] private GameObject _saveButton;
        [SerializeField] private GameObject _inputField;
        [SerializeField] private TMP_InputField _usernameInputField;

// Make changes to this section according to how you're storing the player's score:
// ------------------------------------------------------------
        [SerializeField] GameManager manager;

        private int Score => manager.score;
// ------------------------------------------------------------
        
        public void UploadEntry()
        {
            if (_usernameInputField.text != string.Empty) {
                Leaderboards.ComboSnek.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
                {
                    if (isSuccessful) {
                        LeaderboardCreator.ResetPlayer();
                        _inputField.SetActive(false);
                        _saveButton.SetActive(false);
                    }
                });
            }
        }
    }
}