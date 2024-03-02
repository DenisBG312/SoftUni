﻿namespace BorderControl;

public class Pet : IIdentifiable
{
    public Pet(string name, string birthdate)
    {
        Name = name;
        Birthdate = birthdate;
    }
    public string Name { get; }
    public string Birthdate { get; }
}