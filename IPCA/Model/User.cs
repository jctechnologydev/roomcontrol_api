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
    public class User
    {
        private int idUser;
        private int idTypeUser;
        private string name;
        private string email;
        private string password;
        private string urlToImage;

        public int IdUser
        {
            get => idUser;
            set => idUser = value;
        }

        public int IdTypeUser
        {
            get => idTypeUser;
            set => idTypeUser = value;
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Email
        {
            get => email;
            set => email = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string UrlToImage
        {
            get => urlToImage;
            set => urlToImage = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}