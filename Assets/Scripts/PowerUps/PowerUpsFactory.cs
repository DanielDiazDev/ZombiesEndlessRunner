public class PowerUpsFactory
{
    private readonly PowerUpsConfiguration _powerUpsConfiguration;

    public PowerUpsFactory(PowerUpsConfiguration powerUpsConfiguration)
    {
        _powerUpsConfiguration = powerUpsConfiguration;
    }
    public PowerUp Create(string id)
    {
        var prefab = _powerUpsConfiguration.GetPowerUpPrefabBtId(id);
        return UnityEngine.Object.Instantiate(prefab);
    }
}
