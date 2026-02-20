using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO12.Data;
using static System.Net.Mime.MediaTypeNames;

namespace TRPO12.Service
{
    public class GroupsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<Models.Group> Groups { get; set; } = new();
        public void GetAll()
        {
            var groups = _db.Groups.ToList();
            Groups.Clear();
            foreach (var group in groups)
                Groups.Add(group);
        }
        public int Commit() => _db.SaveChanges();
        public GroupsService()
        {
            GetAll();
        }
        public void Add(Models.Group group)
        {
            var _group = new Models.Group
            {
                Title = group.Title,
            };
            _db.Add<Models.Group>(_group);
            Commit();
            Groups.Add(_group);
        }
        public void Remove(Models.Group group)
        {
            _db.Remove<Models.Group>(group);
            if (Commit() > 0)
                if (Groups.Contains(group))
                    Groups.Remove(group);
        }
        public void LoadRelation(Models.Group group, string relation)
        {
            var entry = _db.Entry(group);
            var navigation = entry.Metadata.FindNavigation(relation)
            ?? throw new InvalidOperationException($"Navigation '{relation}' not found");
            if (navigation.IsCollection)
            {
                entry.Collection(relation).Load();
            }
            else
            {
                entry.Reference(relation).Load();
            }
        }
    }
}
