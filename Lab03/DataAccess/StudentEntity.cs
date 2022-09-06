using System.ComponentModel.DataAnnotations.Schema;

namespace Lab03.DataAccess
{
    [Table("Student")]
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}