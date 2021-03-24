//----------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Codic Education">
// By Marcus Medina, 2021 - http://MarcusMedina.Pro 
// This file is subject to the terms and conditions defined in file "license.txt"- GNU3, 
// which is part of this project. </copyright>
// ----------------------------------------------------------------------------------------------

namespace MoqTesting
{
    using System;

    public class Person : IPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
