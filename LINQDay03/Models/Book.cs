using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDay03.Models
{
    //Q1: Why did the property "Id" become a Primary Key without any explicit configuration?
    //Answer: In Entity Framework, a property named "Id" or "<ClassName>Id" is conventionally recognized as the primary key of the entity.
    // This convention allows EF to automatically configure the "Id" property as the primary key without requiring explicit configuration. 
    //Therefore, in this case, the "Id" property in the "Book" class is automatically treated as the primary key due to this naming convention.



    //Q2: Why is "Country" nullable in the database while "Price" is not?
    //Answer: The "Country" property is nullable in the database because it is defined as a string without the [Required] attribute, allowing it to accept null values.
    //On the other hand, the "Price" property is not nullable because it is defined as a decimal and is decorated with the [Required] attribute, which enforces that a value must be provided for it.

    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime? PublishedDate { get; set; }
}
}
