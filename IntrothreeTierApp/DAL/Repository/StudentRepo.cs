using DAL.EF;
using DAL.EF.Tables;
using System.Collections.Generic;

namespace DAL.Repository
{
	public class StudentRepo
	{
		StudentMsBSp26Context db;
		public StudentRepo(StudentMsBSp26Context db)
		{
			this.db = db;
		}

		public List<Student> Get()
		{
			return db.Students.ToList();
		}

		public Student Get(int id)
		{
			return db.Students.Find(id);
		}

		public bool Create(Student s)
		{
			db.Students.Add(s);
			return db.SaveChanges() > 0;
		}

		public bool Update(Student s)
		{
			var exobj = Get(s.Id);
			db.Entry(exobj).CurrentValues.SetValues(s);
			return db.SaveChanges() > 0;
		}

		public bool Delete(int id)
		{
			var exobj = Get(id);
			db.Students.Remove(exobj);
			return db.SaveChanges() > 0;
		}
	}
}
