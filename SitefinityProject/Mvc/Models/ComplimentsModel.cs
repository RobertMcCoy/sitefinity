using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitefinityWebApp.Mvc.Models
{
    public class ComplimentsModel
    {
        string _compliments;

        string[] _complimentsArray => _compliments.Split(',').Select(compliment => compliment.Trim()).ToArray();

        public ComplimentsModel()
        {
            _compliments = "You are as cool as you think";
        }

        public ComplimentsModel(string compliments)
        {
            _compliments = compliments;
        }
        public string ComplimentMe()
        {
            Random rnd = new Random();
            int r = rnd.Next(_complimentsArray.Count());
            return _complimentsArray[r];
        }
    }
}