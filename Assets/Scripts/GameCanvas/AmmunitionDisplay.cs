using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionDisplay : MonoBehaviour
{
    [SerializeField] private Text ammunitionLabel;

    private StringBuilder _stringBuilder;
    private const char ValueBaffle = '/';

    private void Awake()
    {
        _stringBuilder = new StringBuilder();
        Debug.Log("StringBuilder" + _stringBuilder.Capacity);
    }

    public void RefreshDisplay(int clip, int total)
    {
        _stringBuilder.Clear();
        _stringBuilder.Append(clip);
        _stringBuilder.Append(ValueBaffle);
        _stringBuilder.Append(total);
        ammunitionLabel.text = _stringBuilder.ToString();
    }
}
