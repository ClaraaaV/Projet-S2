using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    public Transform[] SpawnPoints;

    void Start()
    {
        int avatarIndex = 0; // Valeur par défaut

        if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("playerAvatar", out object avatarIndexObj))
        {
            avatarIndex = (int)avatarIndexObj;
        }

        // Assurez-vous que avatarIndex est dans la plage valide des index pour playerPrefabs
        if (avatarIndex < 0 || avatarIndex >= playerPrefabs.Length)
        {
            Debug.LogError("Index de 'playerAvatar' invalide, utilisation du prefab par défaut.");
            avatarIndex = 0;
        }

        // Ici, SpawnPoints.Length doit être vérifié pour éviter des erreurs
        if (SpawnPoints.Length == 0)
        {
            Debug.LogError("Aucun SpawnPoint défini.");
            return;
        }

        int randomNumber = Random.Range(0, SpawnPoints.Length);
        Transform spawnPoint = SpawnPoints[randomNumber];

        if(spawnPoint == null)
        {
            Debug.LogError("Le SpawnPoint sélectionné est null.");
            return;
        }

        GameObject playerToSpawn = playerPrefabs[avatarIndex];
        PhotonNetwork.Instantiate(playerToSpawn.name, spawnPoint.position, Quaternion.identity);
    }

    
}