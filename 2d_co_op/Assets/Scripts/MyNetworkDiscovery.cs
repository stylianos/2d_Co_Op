using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkDiscovery : NetworkDiscovery
{

    int minPort = 10000;
    int maxPort = 10010;
    int defaultPort = 10000;


    // Update is called once per frame
    void Update() {

    }

    public void startClient()
    {
        Initialize();
        StartAsClient();
    }

    public void startServer()
    {
        int serverPort = createServer();

        if (serverPort != - 1)
        {
            Debug.Log("Server made on port : " + serverPort);
            this.GetComponent<MyNetworkDiscoveryUI>().setText("Server made on port : " + serverPort);
            broadcastData = serverPort.ToString();
            Initialize();
            StartAsServer();
        }
        else
        {
            Debug.Log("Failed to create Server");
        }
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)

    {
        Debug.Log("Server found the data send is " + data);
        this.GetComponent<MyNetworkDiscoveryUI>().setText("Server found the data send is " + data);
    }

    private int createServer()
    {
        int serverPort = -1;
        //connect to the default port 
        bool serverCreated = NetworkServer.Listen(defaultPort);
        if ( serverCreated)
        {
            serverPort = defaultPort;
        }
        else
        {
            Debug.Log("Failed to create at the default port");

            for (int tempPort = minPort; tempPort <= maxPort ; tempPort++ )
            {
                if (NetworkServer.Listen(tempPort))
                {
                    serverPort = tempPort;
                    break;
                }
            }
            Debug.Log("Failed to create a server ");
        }
        return serverPort;
    }
}

