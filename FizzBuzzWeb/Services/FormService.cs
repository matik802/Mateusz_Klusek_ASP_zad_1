using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;
using FizzBuzzWeb.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace FizzBuzzWeb.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepo;
        public FormService(IFormRepository formRepo)
        {
            _formRepo = formRepo;
        }
        public IQueryable<Form> GetForms() 
        {
            return _formRepo.GetForms();
        }
        public ListFormForListVM GetFormsForList()
        {
            var forms = _formRepo.GetForms();
            ListFormForListVM result = new ListFormForListVM();
            result.Forms = new List<FormForListVM>();
            foreach (Form form in forms) 
            {
                var fVM = new FormForListVM()
                {
                    Id = form.Id,
                    Year = form.Year,
                    Name = form.Name,
                    Result = form.Result,
                    Created = form.Created
                };
                result.Forms.Add(fVM);
                result.Count = result.Forms.ToList().Count; 
            }
            
            return result;
        }
        public bool IsEmpty()
        {
            if (_formRepo.GetForms() == null) return true;
            return false;
        }
        public Form GetForm(int id)
        {
            return _formRepo.GetForms().ToList().FirstOrDefault(u => u.Id == id);
            /*
            var form = _formRepo.GetForms().ToList().FirstOrDefault(u => u.Id == id);
            var fVM = new FormForListVM()
            {
                Id = form.Id,
                Year = form.Year,
                Name = form.Name,
                Result = form.Result,
                Created = form.Created
            };
            return fVM;
            */
        }
        public bool FormExists(int id)
        {
            return (_formRepo.GetForms()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public void Attach(Form Form)
        {
            _formRepo.Attach(Form);
        }
        public void Save()
        {
            _formRepo.Save();
        }
        public void Remove(Form Form)
        {
            _formRepo.Remove(Form);
        }
        public void AddForm(Form Form)
        {
            _formRepo.AddForm(Form);
        }
    }
}
