using MyDiary.Data.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDiary.Business.Interfaces
{
    public interface INoteService
    {
        Task Add(Note note);
        Task Edit(int Id, Note note);
        Task<Note> Read(int Id);
        Task<bool> Delete(int Id);
        //Method Overload
        Task<List<Note>> Read();

    }
}
