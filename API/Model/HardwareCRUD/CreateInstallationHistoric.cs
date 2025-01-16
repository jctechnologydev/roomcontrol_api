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
    public class CreateInstallationHistoric
    {
        public class InstallationHistoricDTO
        {
            #region Attributes
            private int idHardware;
            private int idRoom;
            #endregion

            #region Properties
            public int IdHardware
            {
                get => idHardware;
                set => idHardware = value;
            }

            public int IdRoom
            {
                get => idRoom;
                set => idRoom = value;
            }

            #endregion
        }
    }
}
