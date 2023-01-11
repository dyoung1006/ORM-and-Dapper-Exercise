
namespace ORM_and_Dapper_Exercise
{
    public class Department
    {
        public Department() 
        {
            Name = string.Empty;
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
