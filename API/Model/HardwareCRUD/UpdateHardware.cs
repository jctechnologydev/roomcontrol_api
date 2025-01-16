/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace Backend.Model.HardwareCRUD
{
    public class UpdateHardware
    {
        #region Attributes
        private int id;
        private string name;
        private int minValue;
        private int maxValue;
        #endregion

        #region Properties
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

        public int MaxValue
        {
            get => maxValue;
            set => maxValue = value;
        }

        public int MinValue
        {
            get => minValue;
            set => minValue = value;

        }
        #endregion
    }
}
