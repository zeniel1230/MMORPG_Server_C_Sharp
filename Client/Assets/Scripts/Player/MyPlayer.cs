﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : Player
{
	NetworkManager m_network;

	void Start()
	{
		StartCoroutine("CoSendPacket");
		m_network = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
	}

	void Update()
	{

	}

	IEnumerator CoSendPacket()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.25f);

			C_Move movePacket = new C_Move();
			movePacket.posX = UnityEngine.Random.Range(-50, 50);
			movePacket.posY = 0;
			movePacket.posZ = UnityEngine.Random.Range(-50, 50);
			m_network.Send(movePacket.Write());
		}
	}
}
