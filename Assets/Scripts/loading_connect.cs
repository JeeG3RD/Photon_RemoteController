using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loading_connect : MonoBehaviour
{
    public bool isMaster = false;
    private string roomName = "Room_Test";

    /**
    * Méthode Awake
    * 
    * Appelée dès l'initialisation du GameObject auquel le script est attaché
    */
    void Awake()
    {
        if(!PhotonNetwork.connected)
        {
            //Au lancement de la scène, on demande à Photon de se connecter
            PhotonNetwork.ConnectUsingSettings("PartyGo_RemoteControllerTest");
        }
        PhotonNetwork.JoinLobby();
    }

    /**
    * Méthode OnJoinedLobby
    *
    * Appelée lorsque le client est connecté au lobby photon
    */
    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
        /**
        * Définition des paramètres de la Room
        */
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 3; //On limite la partie à 2 joueurs max;
        roomOptions.CleanupCacheOnLeave = true;

        /**
        * Définition du nom du joueur en fonction de isMaster
        * 
        * Cela permettra de gérer quel membre de la room gère la partie (Écran de télé par ex.)
        */
        PhotonNetwork.playerName = (isMaster == true) ? "Master" : "Player";

        /**
        * Puis on appelle la création ou la connexion à une Room photon (salon de jeu)
        */
        Debug.Log("Try connecting to room...");
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    /**
    * Méthode OnJoinedRoom
    * 
    * Appelée lorsque le client à rejoin une Room photon
    *
    * On appelle le chargement de la scène de jeu
    */  
    void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        PhotonNetwork.LoadLevel("Game_Test");
    }
}
