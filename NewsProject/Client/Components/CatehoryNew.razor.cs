using Microsoft.AspNetCore.Components;
using NewsProject.Client.Repo;
using NewsProject.Shared.Models;

namespace NewsProject.Client.Components
{
    public partial class CatehoryNew
    {

        
        [Inject]
        public MainInterface<Category> services  { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        public Category category = new Category();
        public async Task Creat() 
        {
            await services.AddRowAsync( category ,"api/Categoryes/AddRowe" );

            navigationManager.NavigateTo("/category");
        }
    }
}
