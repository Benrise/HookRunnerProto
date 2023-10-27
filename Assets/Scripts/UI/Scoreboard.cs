
using UnityEngine;
using TMPro;
using Dan.Main;
using Dan.Models;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _entryTextObjects;
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private Transform _entryDisplayParent;
    [SerializeField] private EntryDisplay _entryDisplayPrefab;

    private int highScore;

    private void Start()
    {
        LoadEntries();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        _highScoreText.text = highScore.ToString();

    }

    private void LoadEntries()
    {
        Leaderboards.HookRunnerScoreboard.GetEntries(OnLeaderboardLoaded, ErrorCallback);
    }

    private void OnLeaderboardLoaded(Entry[] entries)
    {
        foreach (Transform t in _entryDisplayParent) 
            Destroy(t.gameObject);

        foreach (var t in entries) 
            CreateEntryDisplay(t);
        
    }

    public void UploadEntry()
    {
        string username = _usernameInputField.text;
        if (_usernameInputField.text == "" || _usernameInputField.text == null){
            username = SystemInfo.deviceUniqueIdentifier;
        }
        Debug.Log(username);
        if (highScore != 0){
            Leaderboards.HookRunnerScoreboard.UploadNewEntry(username, highScore, isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
        }
    }

    private void CreateEntryDisplay(Entry entry)
    {
        var entryDisplay = Instantiate(_entryDisplayPrefab.gameObject, _entryDisplayParent);
        entryDisplay.GetComponent<EntryDisplay>().SetEntry(entry);
    }

    private void ErrorCallback(string error)
    {
        Debug.LogError(error);
    }
}
