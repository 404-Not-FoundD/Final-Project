using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class DropdownController : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] TMP_InputField input_name;
    private string selectedOption;
    int number;

    void Start()
    {
        // Clear existing options
        dropdown.ClearOptions();
        dropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        number = int.Parse(LoadFromPlayerPrefs("number", "404"));

        if (number == 404) number = 0;
        List<string> optionTexts = new List<string>();

        for (int i = 0; i < number; i++) {
            optionTexts.Add(LoadFromPlayerPrefs(i.ToString(), "404"));
        }
        input_name.placeholder.GetComponent<TMP_Text>().text = optionTexts[0];
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();

        // Create OptionData objects
        foreach (string optionText in optionTexts) {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(optionText);
            options.Add(option);
        }

        // Add options to dropdown
        dropdown.AddOptions(options);
        dropdown.RefreshShownValue();

    }

    void Update()
    {
        // Check if Enter key is pressed
        /*if (Input.GetKeyDown(KeyCode.Return)) {
            OnInputFieldEndEdit(input_name.text);
        }*/
        if(Input.GetMouseButtonDown(0)){
            OnInputFieldEndEdit(input_name.text);
        }
    }

    // Called when InputField editing ends
    void OnInputFieldEndEdit(string input)
    {
        // Check if input is not empty
        if (!string.IsNullOrEmpty(input)) {
            AddOption(input);
            input_name.text = string.Empty; // Clear input field
            input_name.placeholder.GetComponent<TMP_Text>().text = input;
        }
    }

    // Add a new option
    public void AddOption(string newOption)
    {
        // Check if new option already exists
        bool optionExists = false;
        foreach (TMP_Dropdown.OptionData option in dropdown.options) {
            if (option.text == newOption) {
                optionExists = true;
                break;
            }
        }

        // If new option does not exist, add it
        if (!optionExists) {
            // Create new OptionData
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData(newOption);

            // Add new OptionData to dropdown options
            dropdown.options.Add(optionData);

            // Refresh dropdown display
            dropdown.RefreshShownValue();
            SaveByPlayerPrefs(number.ToString(), newOption);
            number++;
        }
    }

    // Save the number of options
    public void SaveNumber()
    {
        SaveByPlayerPrefs("number", number.ToString());
    }

    // Called when dropdown value changes
    void OnDropdownValueChanged(int index)
    {
        selectedOption = dropdown.options[index].text;
        // Update the TMP_InputField component with the selected option
        input_name.placeholder.GetComponent<TMP_Text>().text = selectedOption;
        Debug.Log("Selected Option: " + selectedOption);
    }

    // Save data to PlayerPrefs
    void SaveByPlayerPrefs(string player_data_key, string value)
    {
        PlayerPrefs.SetString(player_data_key, value);
        PlayerPrefs.Save();
    }

    // Load data from PlayerPrefs
    string LoadFromPlayerPrefs(string player_data_key, string Default)
    {
        return PlayerPrefs.GetString(player_data_key, Default);
    }
}