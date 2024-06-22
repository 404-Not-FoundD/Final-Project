using UnityEngine;

public class random_man : MonoBehaviour
{
    public GameObject chosen;
    public GameObject[] shell;
    public GameObject[] man;

    void Start()
    {
        int index = Random.Range(0, man.Length);
        chosen = man[index];
        var manscript = chosen.GetComponent<man>();

        for (int i = 0; i < shell.Length; i++) {
            chosen = shell[i];
            var shellscript = chosen.GetComponent<shell_dif>();
            shellscript.setChosen(index);
        }

        manscript.setChosen(index);
    }
}