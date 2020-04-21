using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        onPlayerJoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnPhotonPlayerConnected()
    {
            Debug.Log("Player Connected");
        onPlayerJoin();
    }

    void onPlayerJoin() {
        if (PhotonNetwork.player.NickName != "Master") {
            Vector3 sp;
            
            //Point d'apparition dans la scene
            sp = new Vector3(0, 2, 0);

            GameObject myPlayer;
            myPlayer = PhotonNetwork.Instantiate("player", sp, Quaternion.identity, 0);
            myPlayer.GetComponentInChildren<Camera>().enabled = true;
            myPlayer.GetComponentInChildren<Canvas>().enabled = true;
        }
    }
}
