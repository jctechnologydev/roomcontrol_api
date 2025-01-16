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
    public class Classroom
    {
        private int idClassroom;
        private int idSchool;
        private Position position;
        private string name;
        private int lotation;

        public int IdClassroom
        {
            get => idClassroom;
            set => idClassroom = value;
        }

        public int IdSchool
        {
            get => idSchool;
            set => idSchool = value;
        }

        public Position Position
        {
            get => position;
            set => position = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Lotation
        {
            get => lotation;
            set => lotation = value;
        }
    }
}