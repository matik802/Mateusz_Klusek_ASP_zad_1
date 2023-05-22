using FizzBuzzWeb.Forms;
using FizzBuzzWeb.ViewModels;

namespace FizzBuzzWeb.Services
{
    public interface IFormService
    {
        public IQueryable<Form> GetForms();
        public ListFormForListVM GetFormsForList();
        public bool IsEmpty();
        public Form GetForm(int id);
        public bool FormExists(int id);
        public void Attach(Form form);
        public void Save();
        public void Remove(Form Form);
        public void AddForm(Form Form);
    }
}
