namespace DefaultNamespace
{
    public interface IHealable
    {
        public float HealthPoint { get; set; }
        public void Heal(float heal);
    }
}