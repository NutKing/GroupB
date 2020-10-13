public class ResettableHealth : Health  {
    public void Revive() {
        m_IsDead = false;

        float healed = maxHealth - currentHealth;

        currentHealth = maxHealth;

        onHealed?.Invoke(healed);
    }
}
