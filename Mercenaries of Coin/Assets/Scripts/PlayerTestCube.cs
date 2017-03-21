using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerTestCube : SynchronizedObject
{
    [SerializeField]
    TextMesh m_text;
    [SerializeField]
    Material m_mat;

    public string   m_serverText;
    public Vector3 m_serverColor;
	// Use this for initialization
	void Awake () {
        var meshRenderer = GetComponent<MeshRenderer>();
        m_mat = new Material(meshRenderer.material);
        meshRenderer.material = m_mat;

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        m_text.transform.position = this.transform.position + new Vector3(0, 1, 0);
    }
    [ClientRpc]
    public void RpcSetText(string text)
    {
        m_text.text = text;
    }
    [ClientRpc]
    public void RpcSetColor(Vector3 color)
    {
        m_mat.color = new Color(color.x,color.y,color.z);
    }
    [TargetRpc]
    public void TargetSetText(NetworkConnection conn,string text)
    {
        m_text.text = text;
    }
    [TargetRpc]
    public void TargetSetColor(NetworkConnection conn, Vector3 color)
    {
        m_mat.color = new Color(color.x, color.y, color.z);
    }
}
