using Photon.Pun;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PhotonView))]
public class ChatManager : MonoBehaviour
{
	[SerializeField] private TMP_Text _lastMessage;
	[SerializeField] private InputField _messageField;

	private PhotonView _photonView;

	private void Start()
	{
		_photonView = GetComponent<PhotonView>();
	}

	public void SendButton()
	{
		_photonView.RpcSecure("SendData", RpcTarget.All, true, PhotonNetwork.NickName, _messageField.text);
	}

	[PunRPC]
	private void SendData(string nickName, string message)
	{
		string defaultMessage = " изрыгнул из себя мысль в виде: ";

		if (nickName == "SavrunE")
		{
			defaultMessage = " соблаговалил снизойти до вас и произнес : ";
		}

		_lastMessage.text = nickName + defaultMessage + message;
	}
}
