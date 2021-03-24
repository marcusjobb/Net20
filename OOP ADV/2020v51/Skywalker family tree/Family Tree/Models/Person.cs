namespace FamilyTree.Models
{
    using System.Diagnostics;

    /// <summary>
    /// POCO for storing a person and the parents
    /// </summary>
    internal class Person
    {
        /// <summary>
        /// Father of the <see cref="Person"/>
        /// </summary>
        public Person Father { get; set; }

        /// <summary>
        /// Mother of the <see cref="Person"/>
        /// </summary>
        public Person Mother { get; set; }

        /// <summary>
        /// Name of the person in a <see cref="string"/>
        /// </summary>
        [DebuggerDisplay("{Name}")]
        public string Name { get; set; }
    }
}