namespace Demo.Presentation.ViewModels.RoleViewModels
{
    public class RoleVM
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string RoleName { get; set; }
    }
}
