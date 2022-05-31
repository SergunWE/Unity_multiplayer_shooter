using Photon.Pun;
using UnityEngine;

public static class PlayerSettings
{
    private const string NicknameKey = "Nickname";

    private static string _nickname;

    static PlayerSettings()
    {
        _nickname = PlayerPrefs.GetString(NicknameKey, 
            "Player" + Random.Range(0, 10000).ToString("00000"));
        SetNickname(_nickname);
    }

    public static void SetNickname(string nick)
    {
        _nickname = nick;
        PlayerPrefs.SetString(NicknameKey, _nickname);
        PhotonNetwork.NickName = _nickname;
        Debug.Log("Set nick: " + _nickname);
    }

    public static string GetNickname()
    {
        return _nickname;
    }
}