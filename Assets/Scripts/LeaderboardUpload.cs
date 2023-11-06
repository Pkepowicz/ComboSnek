using UnityEngine;
using TMPro;

// NOTE: Make sure to include the following namespace wherever you want to access Leaderboard Creator methods
using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class LeaderboardUpload : MonoBehaviour
    {
        [SerializeField] private GameObject _activeText;
        [SerializeField] private GameObject _inActiveText;
        [SerializeField] private TMP_InputField _usernameInputField;

// Make changes to this section according to how you're storing the player's score:
// ------------------------------------------------------------
        [SerializeField] GameManager manager;

        private int Score => manager.score;
// ------------------------------------------------------------
        
        public void UploadEntry()
        {
            Leaderboards.ComboSnek.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
            {
                if (isSuccessful)
                    _activeText.SetActive(false);
                    _activeText.SetActive(true);
                    LeaderboardCreator.ResetPlayer();
            });
        }
    }
}