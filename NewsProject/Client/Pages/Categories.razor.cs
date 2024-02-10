using Microsoft.AspNetCore.Components;
using NewsProject.Client.Repo;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Pages
{
    public partial class Categories 
    {
        [Inject]
        public MainInterface<Category> services  { get; set; } 
        List<Category> _categories { get; set; } = new List<Category>();

        protected override  async  Task OnInitializedAsync()
        {
            _categories = await services.GetAllAsync("api/Categoryes/GetAllItems");
            
        }
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}
