public interface ITower
{
    /// <summary>
    /// Shoots an enemy
    /// </summary>
    /// <param name="enemy"></param>
    void Shoot(IEnemy enemy);

    /// <summary>
    /// Returns the current damage of the tower
    /// </summary>
    /// <returns></returns>
    float GetDamage();

    /// <summary>
    /// Adds a tower component that can be used to modify the tower
    /// </summary>
    /// <param name="towerComponent"></param>
    void AddTowerComponent(ITowerComponent towerComponent);

    bool Purchase(int money);
}