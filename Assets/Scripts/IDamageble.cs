namespace DefaultNamespace
{
    public interface IDamageble
    {
        public float HealthPoint { get; set; }

        void TakeDamage(float takenDamage);
    }
}