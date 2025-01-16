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
    public class HardwareModel
    {
        #region Attributes
        private int idHardware;
        private int idRoom;
        private int idHardwareType;
        private int idFuncionality;
        private string name;
        private int maxValue;
        private int minValue;



        #endregion

        #region Properties
        public int IdHardware
        {
            get => idHardware;
            set => IdHardware = value;
        }


        public int IdRoom
        {
            get => idRoom;
            set => idRoom = value;
        }

        public int IdHardwareType
        {
            get => idHardwareType;
            set => idHardwareType = value;
        }

        public int IdFuncionality
        {
            get => idFuncionality;
            set => idFuncionality = value;
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
