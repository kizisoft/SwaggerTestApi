namespace WebApplication1.Models
{
    public class Employee
    {
        public string EmployeeID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Title { get; set; }

        public string TitleOfCourtesy { get; set; }

        public DateTime BirthDate { get; set; }

        public string HireDate { get; set; }

        public Address Address { get; set; }
    }
}
