using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TerminalManager : MonoBehaviour
{
    public GameObject directoryLine;
    public GameObject responseLine;

    public InputField terminalInput;
    public GameObject InputLine;
    public ScrollRect scroll;
    public GameObject msgList;
    public GameObject terminal;
    public GameObject fixedCanvas;
    public GameObject lvText;
    private int index = 0;

    List<string> inputs = new List<string>();

    Event e = new Event();

    TerminalInterpreter interpreter;

    void Start()
    {
        interpreter = GetComponent<TerminalInterpreter>();
    }


    void OnGUI()
    {
        if (terminalInput.isFocused && Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Escape) {
            Time.timeScale = 1f;
            fixedCanvas.SetActive(true);
            lvText.SetActive(true);
            terminal.SetActive(false);
        }
        if (terminalInput.isFocused && Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.DownArrow && inputs.Count != 0 && index < inputs.Count-1) {
            index++;
            terminalInput.text = inputs[index];
            Debug.Log("down");
            Debug.Log(index);
        }
        if (terminalInput.isFocused && Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.UpArrow && index > 0) {
            index--;
            terminalInput.text = inputs[index];
            Debug.Log("up");
            Debug.Log(index);
        }
        if (terminalInput.isFocused && terminalInput.text != "" && Input.GetKeyDown(KeyCode.Return)) {
            string userInput = terminalInput.text;
            inputs.Add(userInput);
            index = inputs.Count;
            ClearInputField();

            // Instantiate a game object with a direrctory prefix
            AddDirLine(userInput);

            // Add interpretation lines
            int lines = AddInterpreterLines(interpreter.Interpret(userInput));

            // Scroll to bottom
            ScrollToBottom(lines);

            // Move to the end
            InputLine.transform.SetAsLastSibling();

            // Refocus input
            terminalInput.ActivateInputField();
            terminalInput.Select();
        }
    }

    void ClearInputField()
    {
        terminalInput.text = "";
    }

    void AddDirLine(string userInput)
    {
        // Resizing command line container
        Vector2 msgListSize = msgList.GetComponent<RectTransform>().sizeDelta;
        msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(msgListSize.x, msgListSize.y + 50.0f);

        GameObject msg = Instantiate(directoryLine, msgList.transform);
        msg.transform.SetSiblingIndex(msgList.transform.childCount - 1);
        msg.GetComponentsInChildren<Text>()[1].text = userInput;
    }

    int AddInterpreterLines(List<string> interpretation)
    {
        for (int i = 0; i < interpretation.Count; i++) {
            GameObject response = Instantiate(responseLine, msgList.transform);
            response.transform.SetAsLastSibling();

            // get size of message list and resize
            Vector2 listSize = msgList.GetComponent<RectTransform>().sizeDelta;
            msgList.GetComponent<RectTransform>().sizeDelta = new Vector2(listSize.x, listSize.y + 50.0f);

            // set text to the interpreter string
            response.GetComponentInChildren<Text>().text = interpretation[i];
        }
        return interpretation.Count;
    }

    void ScrollToBottom(int lines)
    {
        if (lines > 4) {
            scroll.velocity = new Vector2(0, 450);
        }
        else {
            scroll.verticalNormalizedPosition = 0;
        }
    }
}