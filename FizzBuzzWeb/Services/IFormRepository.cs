using FizzBuzzWeb.Forms;

namespace FizzBuzzWeb.Services
{
    public interface IFormRepository
    {
        IQueryable<Form> GetForms();
        public void Attach(Form Form);
        public void Save();
        public void Remove(Form Form);
        public void AddForm(Form Form);

    }
}
