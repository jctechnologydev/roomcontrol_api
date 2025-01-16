/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class InstallationHistoricDTO
    {
        #region Attributes
        private int idHardware;
        private int idRoom;
        private DateTime registrationDate;
        private int idUser;
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

        public DateTime RegistrationDate
        {
            get => registrationDate;
            set => registrationDate = value;
        }

        public int IdUser
        {
            get => idUser;
            set => idUser = value;
        }
        #endregion
    }
}
