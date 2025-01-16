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
    public class School
    {
        private int idSchool;
        private string name;
        private string url;

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

        public string UrlToImage
        {
            get => url;
            set => url = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}