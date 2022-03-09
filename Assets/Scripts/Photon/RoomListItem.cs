using Photon.Realtime;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomNameText;
    private RoomInfo _info;
    
    public void SetUp(RoomInfo info)
    {
        _info = info;
        roomNameText.text = info.Name;
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(_info);
    }

    public RoomInfo Info => _info;
}
