
public class HealthShieldDisplay : HealthDisplay
{
    public override void RefreshDisplay(string newFirstValue)
    {
        if (newFirstValue.Length > 0 && newFirstValue[0] != '-')
        {
            base.RefreshDisplay(newFirstValue);
            return;
        }
        base.RefreshDisplay("0");
    }
}
