namespace Backend.Model
{
    public class StateHardware
    {
        #region attributes
        private int id;
        private string name;
        #endregion

        #region properties
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }
        #endregion
    }
}
