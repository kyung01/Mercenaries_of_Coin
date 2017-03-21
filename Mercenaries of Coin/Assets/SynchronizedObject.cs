using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SynchronizedObject : NetworkBehaviour
{
    Rigidbody m_rigidbody;
    [SerializeField]
    [SyncVar]
    Vector3
        m_position,
        m_rotation,
        m_velocityLinear,
        m_velocityAngular;
    [SerializeField]
    [SyncVar]
    float
        m_dragLinear, m_dragAngular;


    [SerializeField]
    Vector3
        m_positionOld,
        m_rotationOld,
        m_velocityLinearOld,
        m_velocityAngularOld;
    [SerializeField]
    float
        m_dragLinearOld, m_dragAngularOld;
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    
    public virtual void Update()
    {
        if (isServer) updateServer();
        else updateClient();

    }
    void updateClient()
    {
        if(m_positionOld != m_position)
        {
            m_positionOld = m_position;
            onNewPosition(m_positionOld);
        } 
        if(m_rotationOld != m_rotation)
        {
            m_rotationOld = m_rotation;
            onNewRotation(m_rotationOld);
        }
        if (m_rigidbody == null) return;
        if (m_velocityLinearOld != m_velocityLinear)
        {
            m_velocityLinearOld = m_velocityLinear;
            onNewVelocityLinear(m_velocityLinearOld);
        }
        if(m_velocityAngularOld != m_velocityAngular)
        {
            m_velocityAngularOld = m_velocityAngular;
            onNewVelocityAngular(m_velocityAngularOld);
        }
        if(m_dragLinearOld != m_dragLinear)
        {
            m_dragLinearOld = m_dragLinear;
            onNewDragLinear(m_dragLinearOld);
        }
        if(m_dragAngularOld != m_dragAngular)
        {
            m_dragAngular = m_dragAngularOld;
            onNewDragAngular(m_dragAngular);
        }
    }
    void updateServer()
    {

        if (this.transform.position != m_position)
        {
            m_position = this.transform.position;

        }
        if (this.transform.rotation.eulerAngles != m_rotation)
        {
            m_rotation = this.transform.rotation.eulerAngles;

        }
        if (m_rigidbody == null) return;
        if (m_rigidbody.velocity != m_velocityLinear)
        {
            m_velocityLinear = m_rigidbody.velocity;
        }
        if(m_rigidbody.angularVelocity != m_velocityAngular)
        {
            m_velocityAngular = m_rigidbody.angularVelocity;
        }
        if(m_rigidbody.drag != m_dragLinear)
        {
            m_dragLinear = m_rigidbody.drag;
        }
        if(m_rigidbody.angularDrag != m_dragAngular)
        {
            m_dragAngular = m_rigidbody.angularDrag;
        }
    }
    void onNewPosition(Vector3 position)
    {
        this.transform.position = position;
    }
    void onNewRotation(Vector3 eulerRotation)
    {
        this.transform.rotation = Quaternion.Euler(eulerRotation);
    }
    void onNewVelocityLinear(Vector3 velocity)
    {
        m_rigidbody.velocity = velocity;

    }
    void onNewVelocityAngular(Vector3 velocity)
    {
        m_rigidbody.angularVelocity = velocity;

    }
    void onNewDragLinear(float linear)
    {

    }
    void onNewDragAngular(float angular)
    {

    }
}
