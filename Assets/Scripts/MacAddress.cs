using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MacAddress : MonoBehaviour
{
    public TMP_InputField MACInput;
    
    void OnGUI()
    {
        if (MACInput.isFocused && MACInput.text != "" && Input.GetKeyDown(KeyCode.Return)) {
            string userInput = MACInput.text;
            if (userInput == "0A-03-12-64-88-38") {
                SceneManager.LoadScene("Level5"); // to the next level
            }
            else {
                SceneManager.LoadScene("Level4"); // wrong input, restart the scene
            }
        }
    }
}