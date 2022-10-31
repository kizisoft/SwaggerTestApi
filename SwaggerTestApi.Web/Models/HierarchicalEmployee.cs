namespace SwaggerTestApi.Web.Models
{
    public class HierarchicalEmployee
    {
        public int ID { get; set; }

        public DateTime HireDate { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public HierarchicalEmployee[]? Employees { get; set; }
    }
}
