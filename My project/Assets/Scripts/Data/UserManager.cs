using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    [SerializeField] InputField usernameInput;
    [SerializeField] Canvas usernamePrompt;
    public Text[] scores;

    public void Update() {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
            ScoreManager.instance.DisplayHighscores(this);
    }
    public void TriggerUsernamePrompt() {
        usernamePrompt.gameObject.SetActive(true);
        Debug.Log(usernamePrompt.isActiveAndEnabled);
        GameManager.instance.lvl = this.gameObject.name;
    }

    public void SetUsername() {
        if (usernameInput.text != null) {
            ScoreManager.instance.username = usernameInput.text;
            GameManager.instance.ChangeScene("Level1");
        }
    }
}