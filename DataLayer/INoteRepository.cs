using System.Collections.Generic;

namespace DataLayer
{
    public interface INoteRepository
    {
        Note Find(int id);

        List<Note> GetForUser(int userId);

        Note Add(Note contact);

        Note Update(Note contact);

        void Remove(int id);

    }
}
