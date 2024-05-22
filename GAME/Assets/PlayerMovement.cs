using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MovePlayer : MonoBehaviourPun, IPunObservable
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 dir;
    Animator anim;
    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
    }


    void Update()
    {
        if (view.IsMine)
        {
            dir.x = Input.GetAxisRaw("Horizontal");
            dir.y = Input.GetAxisRaw("Vertical");

            if (Mathf.Approximately(dir.x, 0f) && Mathf.Approximately(dir.y, 0f))
            {
                dir = Vector2.zero;
            }

            SetParam();
        }
    }

    void FixedUpdate()
    {
        if (view.IsMine && dir != Vector2.zero)
        {
            rb.MovePosition(rb.position + dir * (speed * Time.fixedDeltaTime));
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Nous possédons cet objet: envoyons notre état d'animation aux autres
            stream.SendNext(anim.GetInteger("Dir"));
        }
        else
        {
            // Mise à jour de l'état d'animation reçu
            anim.SetInteger("Dir", (int)stream.ReceiveNext());
        }
    }

    void SetParam()
    {
        if (dir.x == 0 && dir.y == 0)
        {
            anim.SetInteger("Dir", 0);
        }
        else if (dir.y < 0)
        {
            anim.SetInteger("Dir", 1);
        }
        else if (dir.y > 0)
        {
            anim.SetInteger("Dir", 4);
        }
        else if (dir.x > 0)
        {
            anim.SetInteger("Dir", 3);
        }
        else if (dir.x < 0)
        {
            anim.SetInteger("Dir", 2);
        }
    }
}