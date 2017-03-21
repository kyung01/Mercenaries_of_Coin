using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public enum NETWORK_INSTANCE_TYPE {
    PLAYER
}

public class PlayerNetworkInstance : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    [TargetRpc]
    void TargetReceiveObject(NetworkConnection conn, NetworkInstanceId id, NETWORK_INSTANCE_TYPE type)
    {

    }
}
