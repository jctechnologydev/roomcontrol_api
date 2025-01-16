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
    public class SubjectIPCA
    {
        private int _idSubject;
        private int _idUser;
        private string _subject;
        private int _ects;

        public int IdSubject
        {
            get => _idSubject;
            set => _idSubject = value;
        }

        public int IdUser
        {
            get => _idUser;
            set => _idUser = value;
        }

        public string Subject
        {
            get => _subject;
            set => _subject = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Ects
        {
            get => _ects;
            set => _ects = value;
        }
    }
}