using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace FizzBuzzWeb.Services
{
    public class FormService : IFormService
    {
        private readonly AppDbContext _context;
        public FormService(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Form> GetForms()
        {
            return _context.Form;
        }
        public bool IsEmpty()
        {
            if (_context.Form == null) return true;
            return false;
            //return _context.Form.Any();
        }
        public Form GetForm(int id)
        {
            return _context.Form.Find(id);
        }
        public bool FormExists(int id)
        {
            return (_context.Form?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public void Attach(Form Form)
        {
            _context.Attach(Form).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Remove(Form Form)
        {
            _context.Form.Remove(Form);
        }
        public void AddForm(Form Form)
        {
            _context.Add(Form);
        }
    }
}
