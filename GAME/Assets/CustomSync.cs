using Photon.Pun;
using UnityEngine;

public class CustomSync : MonoBehaviour, IPunObservable
{
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Nous possédons cet objet : envoyons notre position aux autres
            stream.SendNext(transform.position);
        }
        else
        {
            // Position mise à jour reçue
            transform.position = (Vector3)stream.ReceiveNext();
        }
    }
}