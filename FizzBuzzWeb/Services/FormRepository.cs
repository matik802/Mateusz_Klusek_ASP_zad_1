using System;
using FizzBuzzWeb.Data;
using FizzBuzzWeb.Forms;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzWeb.Services
{
    public class FormRepository : IFormRepository
    {
        private readonly AppDbContext _context;
        public FormRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Form> GetForms()
        {
            return _context.Form;
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
