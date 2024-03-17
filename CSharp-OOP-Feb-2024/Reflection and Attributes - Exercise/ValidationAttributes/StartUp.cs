using System;
using System.ComponentModel.DataAnnotations;
using ValidationAttributes.Models;
using Validator = ValidationAttributes.Utils.Validator;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 "asd",
                 15
             );

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
