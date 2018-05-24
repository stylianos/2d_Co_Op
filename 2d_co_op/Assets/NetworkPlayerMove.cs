using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerMove : NetworkBehaviour
{
    void Update()
    {
        
        if (!isLocalPlayer)
        {
            Debug.Log("This is not the local player!");
            return;
        }
    

        var x = Input.GetAxis("Horizontal_P1") * 0.1f;
        Debug.Log("This is the x " + x);
        var z = Input.GetAxis("Vertical_P1") * 0.1f;
        Debug.Log("I am moving the palyer");
        transform.Translate(x, 0, z);
    }
}