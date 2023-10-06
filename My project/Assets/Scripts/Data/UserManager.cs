using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    [SerializeField] InputField usernameInput;
    [SerializeField] Canvas usernamePrompt;
    public Text[] scores;
    private string lvlToLoad;

    public void Update() {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
            ScoreManager.instance.DisplayHighscores(this);
    }
    public void TriggerUsernamePrompt(string lvl) {
        lvlToLoad = lvl;
        usernamePrompt.gameObject.SetActive(true);
        GameManager.instance.lvl = this.gameObject.name;
    }

    public void SetUsername() {
        if (usernameInput.text != null) {
            ScoreManager.instance.username = usernameInput.text;
            Debug.Log(lvlToLoad);
            GameManager.instance.ChangeScene(lvlToLoad);
        }
    }
}