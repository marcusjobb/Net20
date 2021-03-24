//----------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Codic Education">
// By Marcus Medina, 2021 - http://MarcusMedina.Pro 
// This file is subject to the terms and conditions defined in file "license.txt"- GNU3, 
// which is part of this project. </copyright>
// ----------------------------------------------------------------------------------------------

using System;

namespace MoqTesting
{
    public interface IPerson
    {
        DateTime BirthDate { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}