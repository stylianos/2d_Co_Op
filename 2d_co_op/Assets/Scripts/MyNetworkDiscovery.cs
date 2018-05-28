using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkDiscovery : NetworkDiscovery
{

    int minPort = 10000;
    int maxPort = 10010;
    int defaultPort = 10000;
    bool initialised = false; 



    public void InitialiseBroadcast()
    {
        initialised = Initialize();

        if ( initialised)
        {
            this.GetComponent<MyNetworkDiscoveryUI>().setText("Initialised succesfully");
        }
    }

    public void startClient()
    {
        if (isServer)
        {
            StopBroadcast();
        }
        if ( isClient)
        {
            return;
        }
        
        bool start_listening = StartAsClient();
        if (start_listening && initialised )
        {
            this.GetComponent<MyNetworkDiscoveryUI>().setText("Client started succesfully");
        }
        
    }

    public void startServer()
    {

        bool server_started = StartAsServer();
        if (server_started && initialised)
        {
            this.GetComponent<MyNetworkDiscoveryUI>().setText("Server started succesfully"); 
            Debug.Log("Server made on port : ");
        }

       
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)

    {
        base.OnReceivedBroadcast(fromAddress, data);
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

