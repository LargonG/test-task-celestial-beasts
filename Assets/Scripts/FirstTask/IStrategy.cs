namespace FirstTask
{
    /**
     * Описывает стратегию поведения солдата
     */
    public interface IStrategy
    {
        public void Interact(Soldier soldier, Squad squad);
    }
}