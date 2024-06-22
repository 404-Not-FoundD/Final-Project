// Generates random IPs 
// Set position of IPs and the goal colliders


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using System.ComponentModel.Design.Serialization;

public class randomIP : MonoBehaviour
{
    public Dictionary<string, string> dns_ip = new Dictionary<string, string>
    {
        { "ccu.edu.tw", "140.123.1.2" },
        { "dorm.ccu.edu.tw", "140.123.242.1" },
        { "cs.ccu.edu.tw", "140.123.13.215" }
    };
    public TMP_Text[] ips; // Correct is 0
    public  TMP_Text hint;
    public GameObject[] goals;

    private float[,] TextPositions =  {
        {112.23f, -2.05f},
        {112.23f, 0.8f},
        {112.23f, 3.88f},
        {112.23f, 6.91f},
        {112.23f, 9.88f},
    };
    private float[,] GoalPositions =  {
        {127.12f, -1.85f},
        {127.12f, 0.78f},
        {127.12f, 3.82f},
        {127.12f, 6.85f},
        {127.12f, 9.86f},
    };

    void Awake()
    {
        GenerateIp();
        RandomPos();
    }

    void GenerateIp()
    {
        int ipIndex = Random.Range(0, dns_ip.Count-1);
        ips[0].text = dns_ip.ElementAt(ipIndex).Value;
        hint.text = "Try to get the IP of this domain name!\n";
        hint.text = hint.text + dns_ip.ElementAt(ipIndex).Key;

        for (int i = 1; i <= 4; i++) {
            int bit = Random.Range(0, 255);
            string ip = bit.ToString();

            for (int j = 0; j < 3; j++) {
                ip = ip + ".";
                bit = Random.Range(0, 255);
                ip = ip + bit.ToString();
            }
            Debug.Log(ip);
            ips[i].text = ip;
        }
    }

    void RandomPos()
    {
        int index;
        Vector3 thispos;
        Vector3 goalpos;
        var arr = new int[] {0, 1, 2, 3, 4};
        reshuffle(arr);

        for (int i = 0; i < 5; i++) {
            index = arr[i];
            Debug.Log(index);
            thispos.x = TextPositions[index, 0];
            thispos.y = TextPositions[index, 1];
            thispos.z = 0;
            goalpos.x = GoalPositions[index, 0];
            goalpos.y = GoalPositions[index, 1];
            goalpos.z = 0;
            ips[i].rectTransform.position = thispos;
            goals[i].transform.position = goalpos; 
        }
    }

    void reshuffle(int[] arr)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < arr.Length; t++ ) {
            int tmp = arr[t];
            int r = Random.Range(t, arr.Length);
            arr[t] = arr[r];
            arr[r] = tmp;
        }
    }
}