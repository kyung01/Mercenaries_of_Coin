using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KNetworkManager : NetworkManager {
    public NetworkPrefabBank NETWORK_PREFAB_BANK;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);
        var playerTestCube = Instantiate(NETWORK_PREFAB_BANK.PLAYER_TEST_CUBE);
        NetworkServer.Spawn(playerTestCube.gameObject);
        playerTestCube.m_serverText = "Player " + conn.connectionId;
        playerTestCube.m_serverColor = new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)).normalized;
        playerTestCube.RpcSetText( playerTestCube.m_serverText);
        playerTestCube.RpcSetColor( playerTestCube.m_serverColor);
        //playerTestCube.RpcSetColor(new Vector3(1, 1, 1));
    }
    public override void OnServerReady(NetworkConnection conn)
    {
        base.OnServerReady(conn);
        foreach(var obj in NetworkServer.objects)
        {
            var cube = obj.Value.GetComponent<PlayerTestCube>();
            if (cube == null) continue;
            cube.TargetSetText(conn, cube.m_serverText);
            cube.TargetSetColor(conn, cube.m_serverColor);
        }
    }
}
