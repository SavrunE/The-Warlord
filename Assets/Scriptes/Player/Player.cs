using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

[RequireComponent(typeof(PhotonView))]
[RequireComponent(typeof(PhotonTransformViewClassic))]
public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text nickName;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float minSpeed = 1f;
    public float Speed { get { return speed; } }
    public float MaxSpeed { get { return maxSpeed; } }

    private PhotonView view;

    private void Start()
    {
        speed = maxSpeed;
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
			SetName();
		}
    }

    private void Update()
    {
        if (view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = moveInput.normalized * speed * Time.deltaTime;
            transform.position += (Vector3)moveAmount;
        }
    }

    private void SetName()
	{
        PlayerProfile playerProfile = new PlayerProfile();
        nickName.text = playerProfile.Name();
    }
}
