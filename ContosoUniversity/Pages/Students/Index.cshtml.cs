using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Data.SchoolContext _context;

        public IndexModel(ContosoUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        //public IList<Student> Student { get;set; }

        //public async Task OnGetAsync()
        //{
        //    Student = await _context.Students.ToListAsync();
        //}
        //添加排序
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        //使用 PaginatedList 类获取 Student 实体。
        public PaginatedList<Student> Students { get; set; }

     
        //public IList<Student> Students { get; set; }

        //public async Task OnGetAsync(string sortOrder)
        //public async Task OnGetAsync(string sortOrder , string searchString)
        //{
        //    NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    DateSort = sortOrder == "Date" ? "date_desc" : "Date";

        //    CurrentFilter = searchString;

        //    //该方法使用 LINQ to Entities 指定要作为排序依据的列。 此代码会初始化 switch 语句前面的 IQueryable<Student>，并在 switch 语句中对其进行修改：

        //    IQueryable<Student> studentsIQ = from s in _context.Students
        //                                     select s;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
        //        || s.FirstMidName.Contains(searchString));
        //    }
        //    //创建或修改 IQueryable 时，不会向数据库发送任何查询。 将 IQueryable 对象转换成集合后才能执行查询。 
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
        //            break;
        //        case "Date":
        //            studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
        //            break;
        //        case "date_desc":
        //            studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
        //            break;
        //        default:
        //            studentsIQ = studentsIQ.OrderBy(s => s.LastName);
        //            break;
        //    }
        //    //创建或修改 IQueryable 时，不会向数据库发送任何查询。 将 IQueryable 对象转换成集合后才能执行查询。 通过调用 IQueryable 等方法可将 ToListAsync 转换成集合。 
        //    //因此，IQueryable 代码会生成单个查询，此查询直到出现以下语句才执行：
        //    Students = await studentsIQ.AsNoTracking().ToListAsync();
        //}

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
               || s.FirstMidName.Contains(searchString));

            }
            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            Students = await PaginatedList<Student>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);


        }
    }
}
