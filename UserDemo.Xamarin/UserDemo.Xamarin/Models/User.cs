using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserDemo.Xamarin.Models
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(250)]
        public string AvatarUrl { get; set; }
    }
}
