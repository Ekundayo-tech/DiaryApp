using Microsoft.EntityFrameworkCore;
using MyDiary.Business.Interfaces;
using MyDiary.Data.DataContext;
using MyDiary.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyDiary.Business.Services
{
    public class NoteService// : INoteService
    {
        private readonly MyDataContext _dbContext;
        public NoteService(MyDataContext Context)
        {
            _dbContext = Context;
        }
        public async Task Add(Note note)
        {
            if (note != null)
            {
                 _dbContext.Notes.Add(note);
                await _dbContext.SaveChangesAsync();
            }
  
        }

        public async Task<bool> Delete(int Id)
        {
            var delnote = await Read(Id);
            if (delnote != null)
            {
                _dbContext.Notes.Remove(delnote);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;


            //bool note = await Delete(Id: Id);
            //return note;

        }


        public  async Task Edit(int Id, Note note)
        {
            var Editnote = await Read(Id);
            if (Editnote.Id == note.Id)
            {
                Editnote.Title = note.Title;
                Editnote.DateModified = DateTime.Now;
                Editnote.Details = note.Details;
                _dbContext.Notes.Update(Editnote);
                await _dbContext.SaveChangesAsync();
            }
            


            //_dbContext.Notes.Find(Editnote);
            //if (Id != note.ID)
            //{
            //  _dbContext.Update(note);
            //await _dbContext.SaveChangesAsync();
            //}

        }

        public async Task<Note> Read(int Id)
        {
            var read = await _dbContext.Notes.FindAsync(Id);
            _dbContext.Notes.Find(read);
            await _dbContext.SaveChangesAsync();
            return read;
            //Note note = await Read(Id:Id);

            //return note;
             
        }

        public async Task<List<Note>> Read()
        {
            
            var read = await _dbContext.Notes.ToListAsync();
            return read;
            //List<Note> list = await Read();
            //return list;

        }

    }
}


 