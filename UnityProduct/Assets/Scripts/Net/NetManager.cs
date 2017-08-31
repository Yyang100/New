using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;
using System;
using strange.extensions.dispatcher.eventdispatcher.api;

public class NetManager : MonoBehaviour {

	public static NetManager Instance;
	private SocketIOComponent socket;

	// Use this for initialization
	void Awake () {
		Instance = this;
		DontDestroyOnLoad (gameObject);
		socket = GetComponent<SocketIOComponent> ();
		socket.autoConnect = true;
//		socket.url = "";
	}
	void Start()
	{
		socket.On("open", SocketOpen);
		socket.On("error", SocketErr);
		socket.On("close", SocketClose);
		BindSignal ();
	}

	public void doConnect()
	{
		if (!socket.IsConnected) {
			socket.Connect ();
		}
	}
	void SocketOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
	void SocketErr(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + " " + e.data);
	}
 	void SocketClose(SocketIOEvent e)
	{	
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
	}

	//-------------注册监听----------------
	 void RegisterListener(int key, Action<SocketIOEvent> call)
	{
		socket.On(key.ToString(),call);
	}
	//-------------发送消息----------------
	public  void SendMessage(int key)
	{
		socket.Emit (key.ToString());
	}

	public  void SendMessage(int key,Action<JSONObject> call)
	{
		socket.Emit (key.ToString(),call);
	}

	public  void SendMessage(int key,JSONObject data)
	{
		socket.Emit (key.ToString(),data);
	}

	public  void SendMessage(int key,JSONObject data,Action<JSONObject> call)
	{
		socket.Emit (key.ToString(),data,call);
	}


	void BindSignal()
	{
		RegisterListener (ServerRsp.loginRsp,ServerCall);
	}
	public static IEventDispatcher dispatcher;
	void ServerCall(SocketIOEvent e)
	{
		int sigID;
		bool flag = int.TryParse (e.name,out sigID);
		switch (sigID) {
		case ServerRsp.loginRsp:
			dispatcher.Dispatch (AppCommandEvent.LoginRspCommand,e.data);
			break;
		default:
			break;
		}
	}
}
