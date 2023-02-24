namespace FirstTask.Characteristics
{
    public class HealthCharacteristic: Characteristic
    {
        private readonly float[] _value = new float[2];
        public float Value => _value[0];

        private float NowValue
        {
            get => _value[0];
            set => _value[0] = value;
        }
        
        private float NextValue
        {
            get => _value[1];
            set => _value[1] = value;
        }

        public void SwapBuffer()
        {
            (NowValue, NextValue) = (NextValue, NowValue);
        }

        public void DamageHealth(float damage)
        {
            NextValue -= damage;
        }
    }
}