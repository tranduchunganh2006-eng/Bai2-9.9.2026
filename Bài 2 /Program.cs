using System;
public class Person
{
    public string Id { get; init; }
    public string FullName { get; set; }
    public int BirthYear { get; set; }

    public Person(string id, string fullName, int birthYear)
    {
        Id = id;
        FullName = fullName;
        BirthYear = birthYear;
    }

    public int GetAge(int currentYear)
    {
        return currentYear - BirthYear;
    }
}

// 2. Lớp Employee kế thừa từ Person
public class Employee : Person
{
    public decimal BaseSalary { get; set; }

    public Employee(string id, string fullName, int birthYear, decimal baseSalary)
        : base(id, fullName, birthYear)
    {
        BaseSalary = baseSalary;
    }

    public virtual decimal CalculateIncome()
    {
        return BaseSalary;
    }
}
public sealed class Manager : Employee
{
    public decimal ResponsibilityAllowance { get; set; }

    public Manager(string id, string fullName, int birthYear, decimal baseSalary, decimal allowance)
        : base(id, fullName, birthYear, baseSalary)
    {
        ResponsibilityAllowance = allowance;
    }

    public override decimal CalculateIncome() => BaseSalary + ResponsibilityAllowance;
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== BÀI TẬP 2: QUẢN LÝ NHÂN VIÊN VÀ QUẢN LÝ ===");
        
        Employee emp = new Employee("EMP01", "Pham Van D", 1995, 10_000_000m);
        Manager mgr = new Manager("MGR01", "Hoang Thi E", 1988, 20_000_000m, 5_000_000m);

        int currentYear = DateTime.Now.Year;
        
        Console.WriteLine("\n--- Phiếu lương Nhân viên ---");
        Console.WriteLine($"Mã NV: {emp.Id} | Tên: {emp.FullName} | Tuổi: {emp.GetAge(currentYear)}");
        Console.WriteLine($"Lương cơ bản: {emp.BaseSalary:N0} VNĐ | Thu nhập thực lĩnh: {emp.CalculateIncome():N0} VNĐ");

        Console.WriteLine("\n--- Phiếu lương Quản lý ---");
        Console.WriteLine($"Mã QL: {mgr.Id} | Tên: {mgr.FullName} | Tuổi: {mgr.GetAge(currentYear)}");
        Console.WriteLine($"Lương cơ bản: {mgr.BaseSalary:N0} VNĐ | Phụ cấp: {mgr.ResponsibilityAllowance:N0} VNĐ | Thu nhập thực lĩnh: {mgr.CalculateIncome():N0} VNĐ");
    }
}