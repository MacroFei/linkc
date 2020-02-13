using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public CreateModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentVM StudentVM { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //var emptyStudent = new Student();

            //if (await TryUpdateModelAsync<Student> (
            //        emptyStudent,
            //        "student",
            //        s => s.FirstMidName, s=> s.LastName, s=> s.EnrollmentDate)){
            //    _context.Students.Add(emptyStudent);
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}
            //return Page();

            //SetValues 方法通过从另一个 PropertyValues 对象读取值来设置此对象的值。 SetValues 使用属性名称匹配。
            //视图模型类型不需要与模型类型相关，它只需要具有匹配的属性。
            //使用 StudentVM 时需要更新 Create.cshtml 才能使用 StudentVM 而非 Student。

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            {

            }
        }
    }
}
