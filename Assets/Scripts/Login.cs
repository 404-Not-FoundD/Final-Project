using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public void OnSubmitLogin() // Login button
    {
        SceneManager.LoadScene("NoInternet");
    }
}