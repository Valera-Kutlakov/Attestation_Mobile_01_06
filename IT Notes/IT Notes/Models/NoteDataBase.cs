using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace IT_Notes.Models
{
    public class NoteDataBase
    {
        readonly SQLiteAsyncConnection connection;

        public NoteDataBase(string _connection)
        {
            connection = new SQLiteAsyncConnection(_connection);
            connection.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotes()
        {
            return connection.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNote(int idNote)
        {
            return connection.Table<Note>().FirstOrDefaultAsync(x => x.IDNote == idNote);
        }

        public Task<int> SaveNote(Note note)
        {
            if (note.IDNote != 0)
            {
                return connection.UpdateAsync(note);
            }
            else
            {
                return connection.InsertAsync(note);
            }
        }

        public Task<int> DeleteNote(Note note)
        {
            return connection.DeleteAsync(note);
        }
    }
}
