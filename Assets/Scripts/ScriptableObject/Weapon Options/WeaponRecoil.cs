using UnityEngine;

[CreateAssetMenu(menuName = "Weapon Options/New Recoil")]
public class WeaponRecoil : ScriptableObject
{
    //отдача
    [SerializeField] private float baseRecoil;
    [SerializeField] private float maximumRecoil;

    [SerializeField] private AnimationCurve verticalChart;
    [SerializeField] private AnimationCurve horizontalChart;

}
