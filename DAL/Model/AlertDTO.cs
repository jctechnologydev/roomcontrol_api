/*
*	<copyright company="RJ2">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<authors> Joel Jonassi & Rui Alves</authors>
*   <date> 12/2022 1:06:59 AM</date>
*	<description></description>
**/

namespace DAL.Model
{
    public class AlertDTO
    {
        #region Attributes
        private int id;
        private string title;
        private int maxValue;
        private int minValue;
        private int actualValue;
        private string description;


        #endregion

        #region Properties
        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Title
        {
            get => title;
            set => title = value;
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
        public int ActualValue
        {
            get => actualValue;
            set => actualValue = value;
        }
        public string Description
        {
            get => description;
            set => description = value;
        }

        #endregion
    }
}
