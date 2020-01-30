using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private OnImpact m_onImpact;
    //public OnImpact OnImpact => m_onImpact;

    private UnityAction m_callback;


    [SerializeField]
    private GameObject m_bulletTemplate;

    [SerializeField]
    private float m_force = 1000;

    private float m_cooldown = 1.0f;

    private GameObject m_bullet;
    private Rigidbody m_bulletBody;

    [SerializeField]
    private ParticleSystem m_particleSystem;

    //public Rigidbody BulletBody
    //{
    //    get
    //    {
    //        if (m_bulletBody == null)
    //        {
    //            m_bulletBody = m_bullet.GetComponent<Rigidbody>();
    //        }
    //        return m_bulletBody;
    //    }
    //    set => m_bulletBody = value;
    //}

    private void Start()
    {
        m_callback = ActivateParticles;

        m_onImpact.AddListener(m_callback);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Bullet created");
            m_bullet = Instantiate(m_bulletTemplate, Camera.main.transform.position, Camera.main.transform.rotation);
            m_bulletBody = m_bullet.GetComponent<Rigidbody>();
            m_bulletBody.AddForce(Camera.main.transform.forward * m_force, ForceMode.Impulse);
            m_cooldown = 1.0f;
        }

        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Camera.main.transform.position += new Vector3(xMovement * 2, yMovement * 2);
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_onImpact.Invoke();
        Destroy(gameObject);
    }

    private void ActivateParticles()
    {
        m_particleSystem.Play();
        m_onImpact.RemoveListener(ActivateParticles);
    }
}

[Serializable]
public class OnImpact : UnityEvent
{

}