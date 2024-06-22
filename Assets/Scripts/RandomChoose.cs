// This script includes:
// - choosing the random tree to generate 200
// - initializing all the status code text inactive


using System.IO;
using UnityEngine;

public class RandomChoose : MonoBehaviour
{
    public GameObject[] trees;
    public GameObject chosen;
    public GameObject uiobj;

    void Awake()
    {
        uiobj = GameObject.Find("200Text");
        uiobj.SetActive(false);
        uiobj = GameObject.Find("102Text");
        uiobj.SetActive(false);
        uiobj = GameObject.Find("404Text");
        uiobj.SetActive(false);
        uiobj = GameObject.Find("418Text");
        uiobj.SetActive(false);
        uiobj = GameObject.Find("500Text");
        uiobj.SetActive(false);
        uiobj = GameObject.Find("503Text");
        uiobj.SetActive(false);
        uiobj = GameObject.Find("530Text");
        uiobj.SetActive(false);
        uiobj = GameObject.Find("402Text");
        uiobj.SetActive(false);
    }

    void Start()
    {
        pickTree();
    }

    void pickTree()
    {
        int index = Random.Range(0, trees.Length);
        Debug.Log(trees.Length);
        chosen = trees[index];

        var targetscript = chosen.GetComponent<TreeHit>();
        targetscript.setChosen(true);
        Debug.Log(trees[index].name);
    }
}