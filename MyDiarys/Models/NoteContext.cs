using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MyDiarys.Models;

namespace MyDiarys.Models
{
    public class NoteContext
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateModified { get; set; }
        public string Details { get; set; }
    }
    public class NoteDBContext : DbContext
    {
        public NoteDBContext(DbContextOptions<NoteDBContext> options)
            : base(options)
        { 
        }
        public DbSet<NoteContext> noteContexts { get; set; }

    }
}

