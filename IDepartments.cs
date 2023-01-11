using ORM_and_Dapper_Exercise;

public interface IDepartmentRepository
{
	IEnumerable<Department> GetAllDepartments();
}
