using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sezonlukanimator : MonoBehaviour
{

    public Animator sezonluk;

    bool jump;

    ForwardMoment forwardMoment;
    // Start is called before the first frame update
    void Start()
    {
        forwardMoment = gameObject.GetComponent<ForwardMoment>();
    }

    // Update is called once per frame
    void Update()
    {
        jump = forwardMoment.jump;

        if (jump==true)
        {
            sezonluk.SetBool("isjump", true);
        }
        else
        {
            sezonluk.SetBool("isjump", false);
        }

    }

    private void OnTriggerEnter(Collider zipzip)
    {
        if (zipzip.gameObject.tag=="ziplatcam")
        {
            //Debug.Log("ziplatcam çalıştı");
            sezonluk.SetBool("isjump", true);
        }
        if (zipzip.gameObject.tag == "engel")
        {
            //Debug.Log("engel anim çalıştı");
            sezonluk.SetBool("isstop", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="zeminim")
        {
            //Debug.Log("zemindeyim");
            sezonluk.SetBool("isjump", false);
        }
        
    }
}
