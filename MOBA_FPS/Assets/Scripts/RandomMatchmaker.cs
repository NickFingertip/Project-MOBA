using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings("0.5");
	}
	
	void OnGUI()
	{
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	
	void OnJoinedLobby()
	{
		PhotonNetwork.JoinRandomRoom();
	}
	
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Can't join random room!");
		PhotonNetwork.CreateRoom ("Room1");
	} 
	
	void OnJoinedRoom ()
	{
		Debug.Log ("Room Joined");
		
		//monster.GetComponent<myThirdPersonController>().isControllable = true;
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
}
