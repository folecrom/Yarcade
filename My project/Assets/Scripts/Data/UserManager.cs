using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UserManager : MonoBehaviour
{
    [SerializeField] InputField usernameInput;
    [SerializeField] Canvas usernamePrompt;

    public void Update() {
        if (EventSystem.current.currentSelectedGameObject == this.gameObject)
            ScoreManager.instance.DisplayHighscores(this.name);
    }
    public void TriggerUsernamePrompt() {
        usernamePrompt.gameObject.SetActive(true);
        Debug.Log(usernamePrompt.isActiveAndEnabled);
    }

    public void SetUsername() {
        if (usernameInput.text != null) {
            ScoreManager.instance.username = usernameInput.text;
            GameManager.instance.ChangeScene("Niveau1");
        }
    }
}