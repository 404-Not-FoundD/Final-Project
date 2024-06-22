using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class TerminalInterpreter : MonoBehaviour
{
    public GameObject gameManager;
    
    List<string> response = new List<string>();
    private bool wah = false;

    void Awake()
    {
        wah = false;
    }

    public List<string> Interpret(string Input)
    {
        response.Clear();

        if(wah) response.Add("WAH!");
        string[] args = Input.Split();

        if (args[0] == "help") {
            //info, nighteatwhat, nslookup, wah, whoami
            response.Add("List of commands:");
            response.Add("info");
            response.Add("nslookup");
            response.Add("getmac");
            response.Add("whoami");
            response.Add("wah");
            response.Add("nighteatwhat");
            response.Add("press esc to exit.");
            //list of comands?
            return response;
        }

        if (args[0] == "nighteatwhat") {
            response.Add("idk either:(((((( EmOtIoNaL dAmAgE:((((((");
            return response;
        }
        if (args[0] == "whoami") {
            response.Add("GAY"); //or like, not found? idk, no one would actually type this ig.
            return response;
        }
        if (args[0] == "wah") {
            response.Add("WAH! is activated."); // yes you cannot turn it off ;)
            if(wah) {
                response.Add("Are you trying to turn it off?");
                response.Add("No way:):):)");
            }
            wah = true;
            return response;
        }
        if (args[0] == "info") {
            response.Add("Terminal with extremely limited commands available.");
            response.Add("(With most of them being completely useless.)");
            response.Add("For entertainment purposes only.");
            return response;
        }


        if (args[0] == "nslookup") {
            var targetscript = gameManager.GetComponent<randomIP>();
            if (args.Length == 1) {
                response.Add("Invalid input. Please enter a domain name with the command.");
            } 
            else if (targetscript.dns_ip.TryGetValue(args[1], out string ip)) {
                response.Add("Server: UnKnown");
                response.Add("Address: 404.404.404.404");
                response.Add("\n");
                response.Add("Non-authoritative answer:");
                response.Add("Name: " + args[1]);
                response.Add("Address(IPv4): " + ip);
            }
            else {
                response.Add("Yes, I know it's fun to play around with the terminal.");
                response.Add("But we are too weak to write a real terminal that works.");
                response.Add("So we cannot provide any ip's that are not stored in advance:(");  
            }    
            return response;
        }

        if (args[0] == "getmac") {
            if (args.Length == 1) {
                response.Add("Physical Address   Transport Name");
                response.Add("================== =====================================================");
                response.Add("30-13-27-96-AF-31  Media Disconnected");
                response.Add("00-04-12-41-00-73  Media Disconnected");
                response.Add("87-87-87-87-87-87  Media Disconnected");
                response.Add("0A-03-12-64-88-38  \\Device\\Tcpip_{9302E90E-18AA-21ED-A3F4-E18948C31001}");
                response.Add("00-04-12-41-00-51  Media Disconnected");
                response.Add("11-F3-1F-7E-68-53  \\Device\\Tcpip_{ABCAFFEG-ABGD-DCAB-CACD-BAGGDC000000}");
                response.Add("00-04-12-41-00-13  Media Disconnected");
                response.Add("00-04-12-41-00-20  Media Disconnected");
                response.Add("FB-71-35-44-64-86  Media Disconnected");
                response.Add("EE-EE-EE-EE-EE-EE  \\Device\\Tcpip_{EEEEEEEE-1111-EEEE-1111-EEEEEEEEEEEE}");
                response.Add("00-04-12-41-00-03  Media Disconnected");
            }
            else {
                response.Add("Connection Name  Network Adapter  Physical Address   Transport Name");
                response.Add("================ =============== ================== =====================================================");
                response.Add("wifi             Intel(R) Wi-Fi  30-13-27-96-AF-31  Media Disconnected");
                response.Add("wife             Y0uDontH@veLah  00-04-12-41-00-73  Media Disconnected");
                response.Add("network bridge   Microsoft Netwo 87-87-87-87-87-87  Media Disconnected");
                response.Add("iisaanetto       Innteruu iisane 0A-03-12-64-88-38  \\Device\\Tcpip_{9302E90E-18AA-21ED-A3F4-E18948C31001}");
                response.Add("wife 2           StopDreaming    00-04-12-41-00-51  Media Disconnected");
                response.Add("YeeTaiWangLoo    IngTaiErrYeeTai 11-F3-1F-7E-68-53  \\Device\\Tcpip_{ABCAFFEG-ABGD-DCAB-CACD-BAGGDC000000}");
                response.Add("wife 3           Naniiiiiiiiiii  00-04-12-41-00-13  Media Disconnected");
                response.Add("wife 4           Inaiiiiiiiiiii  00-04-12-41-00-20  Media Disconnected");
                response.Add("waifu?           NoWaifuFriend   FB-71-35-44-64-86  Media Disconnected");
                response.Add("eeeeeeeee        Yeeeeeeeeeeeeee EE-EE-EE-EE-EE-EE  \\Device\\Tcpip_{EEEEEEEE-1111-EEEE-1111-EEEEEEEEEEEE} ");
                response.Add("wife 5           Nooooooooooooo  00-04-12-41-00-03  Media Disconnected");
            }
            return response;
        }
        else {
            response.Add("<color=#ff0000ff>Error: </color>" + ColorString(Input, "#ff0000ff") + "<color=#ff0000ff> is not an internal command.</color>");
            response.Add("Type help if you need help.");
            return response;
        }
    }

    public string ColorString(string s, string color)
    {
        string leftTag = "<color=" + color + ">";
        string rightTag = "</color>";
        return leftTag + s + rightTag;
    }  
}