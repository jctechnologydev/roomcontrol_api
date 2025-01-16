/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/
namespace IPCA.Model
{
    public class Building
    {
        private int idBuilding;
        private int idSchool;
        private string name;

        public int IdBuilding
        {
            get => idBuilding;
            set => idBuilding = value;
        }

        public int IdSchool
        {
            get => idSchool;
            set => idSchool = value;
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}